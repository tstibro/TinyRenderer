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
        /// <param name="p0x">P0x.</param>
        /// <param name="p0y">P0y.</param>
        /// <param name="p1x">P1x.</param>
        /// <param name="p1y">P1y.</param>
        public void DrawLine(int p0x, int p0y, int p1x, int p1y)
		{
			int deltaY = p1y - p0y;
            int deltaX = p1x - p0x;
            
            // slope is the "k" in the formula
            double slope = (deltaX == 0)
                ? 0 // Handle vertical lines 
                : ((double)deltaY) / ((double)deltaX);
            
			// To calculate q (y-intercept) we can use either of the points
            double q = (double)p0y - slope * (double)p0x;
            
            for (int x = p0x; x <= p1x; x++)
            {
                double y = slope * (double)x + q;
				drawingSurface.DrawPixel(x, (int)Math.Round(y));
            }
		}
    }
}
