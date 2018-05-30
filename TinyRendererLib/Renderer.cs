using System;

namespace TinyRendererLib
{
    public class Renderer
    {
		// Provided drawing surface where renderer will render
		private IDrawingSurface drawingSurface;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TinyRendererLib.Renderer"/> class.
        /// </summary>
        /// <param name="drawingSurface">Drawing surface.</param>
		public Renderer(IDrawingSurface drawingSurface)
        {
			this.drawingSurface = drawingSurface;
        }

        /// <summary>
        /// Draws the line using formula y = k * x + q
		/// where k is slope
		///       q is y-intercept
        /// </summary>
		/// <param name="p0x">Start point's X-Coordinate</param>
		/// <param name="p0y">Start point's Y-Coordinate</param>
		/// <param name="p1x">End point's X-Coordinate</param>
		/// <param name="p1y">End point's Y-Coordinate</param>
		public void DrawLine(int p0x, int p0y, int p1x, int p1y)
        {
            // swap points to make sure we draw from left to right
            if (p0x > p1x)
            {
                // swap X coordinates
                int tmp = p0x;
                p0x = p1x;
                p1x = tmp;
                // swap Y coordinates
                tmp = p0y;
                p0y = p1y;
                p1y = tmp;
            }

            int deltaY = p1y - p0y;
            int deltaX = p1x - p0x;

			// slope is the "k" in the formula
            double slope = (deltaX == 0)
                ? 0 // Handle vertical lines
                : ((double)deltaY) / ((double)deltaX);

			// To calculate q (y-intercept) we can use either of the points
			double yIntercept = (double)p0y - slope * (double)p0x;

            for (int x = p0x; x <= p1x; x++)
            {
				double y = slope * (double)x + yIntercept;
				drawPixel(x, (int)Math.Round(y));
            }
        }

        private void drawPixel(int x, int y)
		{
			drawingSurface.DrawPixel(x ,y);
		}
    }
}
