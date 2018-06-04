using System;
using System.Collections.Generic;
using TinyRendererLib.GeometryDataStructures.Vectors;

namespace TinyRendererLib.RenderObjects
{
	/// <summary>
    /// Interface for accessing basic properties of a model
    /// </summary>
    public interface IModel
    {
		/// <summary>
        /// Returns total number of vertices.
        /// </summary>
        /// <returns>Number of vertices.</returns>
		int Vertices();

		/// <summary>
        /// Returns specified vertex.
        /// </summary>
        /// <returns>The vertex.</returns>
        /// <param name="index">Index starting at 0.</param>
		Vector4f Vertex(int index);
        
        /// <summary>
        /// Returns total number faces.
        /// </summary>
        /// <returns>Number of faces.</returns>
        int Faces();

        /// <summary>
        /// Returns a vertex in a face.
        /// </summary>
        /// <returns>The vertex.</returns>
        /// <param name="faceIndex">Face index.</param>
        /// <param name="nthVertex">Nth vertex starting at 0.</param>
        Vector4f Vertex(int faceIndex, int nthVertex);
    }
}
