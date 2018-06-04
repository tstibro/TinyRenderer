using System;
using TinyRendererLib.GeometryDataStructures.Vectors;
using TinyRendererLib.RenderObjects;

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
        /// Renders the specified model.
        /// </summary>
        /// <param name="model">Model.</param>
        public void Render(IModel model)
		{
			for (int face = 0; face < model.Faces(); face++)
			{
				for (int faceVertex = 0; faceVertex < 3; faceVertex++)
				{
					Vector4f v0 = model.Vertex(face, faceVertex);
					Vector4f v1 = model.Vertex(face, (faceVertex + 1) % 3);
					int x0 = (int)((v0.x+1.0) * drawingSurface.Width() / 2.0); 
                    int y0 = (int)((v0.y+1.0) * drawingSurface.Height() / 2.0); 
                    int x1 = (int)((v1.x+1.0) * drawingSurface.Width() / 2.0);  
                    int y1 = (int)((v1.y+1.0) * drawingSurface.Height() / 2.0);  
					DrawLine(x0, y0, x1, y1); 
				}            
			}
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
            int deltaY = p1y - p0y;
            int deltaX = p1x - p0x;

            double slope = (deltaX == 0)
                ? 0 // Handle vertical lines 
                : ((double)deltaY) / ((double)deltaX);

			// To calculate q (y-intercept) we can use either of the points
            double yIntercept = (double)p0y - slope * (double)p0x;

            // Iterate over axis with more points 
            int axisIncrement;
            int totalSteps;
			if (Math.Abs(deltaX) >= Math.Abs(deltaY))
            {
                axisIncrement = (p0x <= p1x ? 1 : -1); // Calculate positive or negative value which depends on the direction of the drawing
				totalSteps = Math.Abs(p0x - p1x); // Calculate total number of pixels needed to be drawn for the line
                for (int step = 0, x = p0x; step <= totalSteps; x += axisIncrement, step++)
                {
					double y = slope * (double)x + yIntercept;
					drawPixel(x, (int)Math.Round(y));
                }
            }
            else
            {
                axisIncrement = (p0y <= p1y ? 1 : -1); // Calculate positive or negative value which depends on the direction of the drawing
				totalSteps = Math.Abs(p0y - p1y); // Calculate total number of pixels needed to be drawn for the line
                for (int step = 0, y = p0y; step <= totalSteps; y += axisIncrement, step++)
                {
                    double x = (deltaX != 0)
						? ((double)y - yIntercept) / slope
                        : p0x; // handle vertical line 

					drawPixel((int)Math.Round(x), y);
                }
            }
        }

        private void drawPixel(int x, int y)
		{
			drawingSurface.DrawPixel(x ,y);
		}
    }
}
