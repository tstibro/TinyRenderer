﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TinyRendererLib.GeometryDataStructures.Vectors;
using TinyRendererLib.RenderObjects;

namespace GraphicsModelImporterLib.WavefrontOBJ
{
	public class OBJmodel : IModel
    {
		private const int OBJ_VERTEX_INDEX_OFFSET = 1; // OBJ vertex indices start at 1

		/// <summary>
        /// The vertices.
        /// </summary>
        private IList<Vector4f> vertices;

        /// <summary>
        /// The vertex normals.
        /// </summary>
        private IList<Vector3f> vertexNormals;

        /// <summary>
        /// List of faces.
        /// Face is defined as 3 vectors (X vector, Y vector, Z vector)
        /// Each vector is defined as (vertex index, texture coordinate index, vertex normal index)
        /// </summary>
        private IList<Tuple<Vector3i, Vector3i, Vector3i>> faces;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TinyRendererLib.ModelFileFormats.WavefrontOBJ.OBJmodel"/> class.
        /// </summary>
        /// <param name="filePath">File path to a Wavefront OBJ model.</param>
        public OBJmodel(string filePath)
        {
            vertices = new List<Vector4f>();
            vertexNormals = new List<Vector3f>();
            faces = new List<Tuple<Vector3i, Vector3i, Vector3i>>();

            loadModelFrom(filePath);
        }

		#region IModel
		public int Vertices()
        {
			return vertices.Count;
        }

        public Vector4f Vertex(int index)
        {
			return vertices[index];
        }

        public int Faces()
        {
			return faces.Count;
        }

        public Vector4f Vertex(int faceIndex, int nthVertex)
        {
			var face = faces[faceIndex];
            if (nthVertex == 0)
            {
                return Vertex(face.Item1.x - OBJ_VERTEX_INDEX_OFFSET);
            }
            else if (nthVertex == 1)
            {
                return Vertex(face.Item2.x - OBJ_VERTEX_INDEX_OFFSET);
            }
            else
            {
                return Vertex(face.Item3.x - OBJ_VERTEX_INDEX_OFFSET);
            }
        }
		#endregion
              
		private void loadModelFrom(string filePath)
		{
			using(StreamReader sr = new StreamReader(filePath))
			{
				string line;
				while(!sr.EndOfStream)
				{
					line = sr.ReadLine();
					string[] parts = line.Split(' ');
					if (!parts.Any())
					{
						continue;
					}

                    if (parts[0] == "v" && parts.Count() >= 4) // Read vertex
					{
						float x = float.Parse(parts[1]);
						float y = float.Parse(parts[2]);
						float z = float.Parse(parts[3]);
						float w = 1.0f;
                        if (parts.Count() == 5)
						{
							w = float.Parse(parts[4]);
						}

						vertices.Add(new Vector4f(x, y, z, w));
					}
					else if (parts[0] == "f" && parts.Count() == 4) // Read face
					{
                        // Read X Part
                        Vector3i faceX = new Vector3i();
						string[] xFaceParts = parts[1].Split('/');
                        faceX.x = int.Parse(xFaceParts[0]); // vertex index
						faceX.y = xFaceParts.Count() > 1 ? int.Parse(xFaceParts[1]) : -1; // texture coordinate index
						faceX.z = xFaceParts.Count() > 2 ? int.Parse(xFaceParts[2]) : -1; // vertex normal index

                        // Read Y Part
						Vector3i faceY = new Vector3i();
                        string[] yFaceParts = parts[2].Split('/');
						faceY.x = int.Parse(yFaceParts[0]); // vertex index
						faceY.y = yFaceParts.Count() > 1 ? int.Parse(yFaceParts[1]) : -1; // texture coordinate index
						faceY.z = yFaceParts.Count() > 2 ? int.Parse(yFaceParts[2]) : -1; // vertex normal index

                        // Read Z Part
						Vector3i faceZ = new Vector3i();
                        string[] zFaceParts = parts[3].Split('/');
						faceZ.x = int.Parse(zFaceParts[0]); // vertex index
						faceZ.y = zFaceParts.Count() > 1 ? int.Parse(zFaceParts[1]) : -1; // texture coordinate index
						faceZ.z = zFaceParts.Count() > 2 ? int.Parse(zFaceParts[2]) : -1; // vertex normal index

						faces.Add(new Tuple<Vector3i, Vector3i, Vector3i>(faceX, faceY, faceZ));
					}
				}
			}
		}      
	}
}
