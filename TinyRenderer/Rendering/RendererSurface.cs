using System;
using AppKit;
using CoreGraphics;
using TinyRendererLib;

namespace TinyRenderer.Rendering
{
	public class RendererSurface : IDrawingSurface
    {
        private byte[] data;
        private int width;
		private int height;
		private int pixelScale;
		// Maximum coordinate values after taking the pixelScale into account
		private int maxX;
		private int maxY;
		// Image flipping
		private bool flipX;
		private bool flipY;

		// Current color
		private byte red;
		private byte green;
		private byte blue;
		private byte alpha;

        public RendererSurface(int width, int height, int pixelScale = 1, bool flipX = false, bool flipY = false)
        {
			this.width = width;
			this.height = height;
			SetPixelScale(pixelScale);
			this.data = new byte[width * height * 4];
			this.flipX = flipX;
			this.flipY = flipY;

			Clear();
        }

        public void SetPixelScale(int pixelScale)
		{
			this.pixelScale = pixelScale;
            this.maxX = (width / pixelScale);
            this.maxY = (height / pixelScale);
		}

        public void SetPixelColor(byte red, byte green, byte blue, byte alpha)
		{
			this.red = red;
			this.green = green;
			this.blue = blue;
			this.alpha = alpha;
		}
		#region IDrawingSurface
        public int Width()
		{
			return this.maxX;
		}

        public int Height()
		{
			return this.maxY;
		}

		public void DrawPixel(int x, int y)
		{
			int safeX = x % maxX;
			int safeY = y % maxY;
			drawFlippedPixel(safeX, safeY);
		}
        #endregion

		public void Fill()
		{
			for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    drawPixel(x, y);
                }
            }
		}

        public void Clear()
		{
			SetPixelColor(255, 255, 255, 255);
			Fill();
		}
        
		public NSImage ToNSImage()
        {
            CGDataProvider provider = new CGDataProvider(data);
            CGColorSpace colorspace = CGColorSpace.CreateDeviceRGB();
            CGImage image = new CGImage(width, height, 8, 32, width * 4, colorspace, CGBitmapFlags.ByteOrder32Big | CGBitmapFlags.PremultipliedLast, provider, null, true, CGColorRenderingIntent.Default);
            return new NSImage(image, new CGSize(width, height));
        }

        /// <summary>
        /// Handles drawing when axis flipping is on.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
		private void drawFlippedPixel(int x, int y)
		{
            if (flipX)
            {
                x = maxX - 1 - x;
            }
            
            if (flipY)
            {
                y = maxY - 1 - y;
            }

			drawScaledPixel(x, y, pixelScale);
		}

        /// <summary>
		/// Handles drawing when pixels are scaled (zoomed in)
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <param name="scale">Scale.</param>
		private void drawScaledPixel(int x, int y, int scale)
        {
            for (int scaleX = 0; scaleX < scale; scaleX++)
            {
                for (int scaleY = 0; scaleY < scale; scaleY++)
                {
                    drawPixel(x * scale + scaleX, y * scale + scaleY);
                }
            }
        }

        private void drawPixel(int x, int y)
        {
            int index = 4 * (x + y * width);
            data[index] = (byte)red;
            data[++index] = (byte)green;
            data[++index] = (byte)blue;
            data[++index] = (byte)alpha;
        }
	}
}
