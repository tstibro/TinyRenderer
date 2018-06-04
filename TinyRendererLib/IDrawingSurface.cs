using System;
namespace TinyRendererLib
{
    public interface IDrawingSurface
    {
		/// <summary>
        /// Surface width in pixels.
        /// </summary>
        /// <returns>The width.</returns>
		int Width();

        /// <summary>
        /// Surface height in pixels.
        /// </summary>
        /// <returns>The height.</returns>
		int Height();

        /// <summary>
        /// Draws pixel at given coordinates.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
		void DrawPixel(int x, int y);
    }
}
