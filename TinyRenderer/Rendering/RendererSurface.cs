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

		// Current color
		private byte red;
		private byte green;
		private byte blue;
		private byte alpha;

        public RendererSurface(int width, int height, int pixelScale = 1)
        {
			this.width = width;
			this.height = height;
			SetPixelScale(pixelScale);
			this.data = new byte[width * height * 4];

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

		public void DrawPixel(int x, int y)
		{
			drawScaledPixel(x % maxX, y % maxY, pixelScale);         
		}

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
