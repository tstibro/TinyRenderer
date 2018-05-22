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

		// Current color
		private byte red;
		private byte green;
		private byte blue;
		private byte alpha;

        public RendererSurface(int width, int height)
        {
			this.width = width;
			this.height = height;
			this.data = new byte[width * height * 4];

			Clear();
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
			int index = 4 * (x + y * width);
			data[index] = (byte)red;
			data[++index] = (byte)green;
			data[++index] = (byte)blue;
			data[++index] = (byte)alpha;
		}

        public void Fill()
		{
			for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    DrawPixel(x, y);
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
	}
}
