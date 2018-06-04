using System;
using GeometryDataStructures.Vectors;
using GraphicsModelImporterLib.WavefrontOBJ;
using TinyRendererLib.RenderObjects;

namespace TinyRenderer.Rendering
{
	class OBJmodelAdapter : IModel
    {
		private OBJmodel model;
		private const int OBJ_VERTEX_INDEX_OFFSET = 1; // OBJ vertex indices start at 1

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TinyRenderer.Rendering.OBJmodelAdapter"/> class.
        /// </summary>
        /// <param name="model">Model.</param>
		public OBJmodelAdapter(OBJmodel model)
        {
			this.model = model;
        }

		/// <summary>
        /// Returns total number faces.
        /// </summary>
        /// <returns>Number of faces.</returns>
		public int Faces()
		{
			return model.Faces.Count;
		}

        /// <summary>
        /// Returns specified vertex.
        /// </summary>
        /// <returns>The vertex.</returns>
        /// <param name="index">Index starting at 0</param>
		public Vector4f Vertex(int index)
		{
			return model.Vertices[index];
		}

		/// <summary>
        /// Returns a vertex in a face.
        /// </summary>
        /// <returns>The vertex.</returns>
        /// <param name="faceIndex">Face index.</param>
        /// <param name="nthVertex">Nth vertex starting at 0.</param>
		public Vector4f Vertex(int faceIndex, int nthVertex)
		{
			var face = model.Faces[faceIndex];
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

		/// <summary>
        /// Returns total number of vertices.
        /// </summary>
        /// <returns>Number of vertices.</returns>
		public int Vertices()
		{
			return model.Vertices.Count;
		}
	}
}
