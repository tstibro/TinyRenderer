using System;

using AppKit;
using Foundation;
using TinyRendererLib;
using TinyRenderer.Rendering;
using GraphicsModelImporterLib.WavefrontOBJ;

namespace TinyRenderer
{
    public partial class ViewController : NSViewController
    {
		private Renderer renderer;
		private RendererSurface rendererSurface;
		private const int PIXEL_SCALE = 1;
		private const bool IMAGE_FLIP_X_COORD = false;
		private const bool IMAGE_FLIP_Y_COORD = true;

		private int FrameSizeWidth {
			get {
				return (int)ImageView.Frame.Size.Width;
			}
		}

		private int ScaledFrameSizeWidth {
			get {
				return (int)FrameSizeWidth / PIXEL_SCALE;
			}
		}

		private int FrameSizeHeight
        {
            get
            {
                return (int)ImageView.Frame.Size.Height;
            }
        }

		private int ScaledFrameSizeHeight
        {
            get
            {
				return (int)FrameSizeHeight / PIXEL_SCALE;
            }
        }
        
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			// Do any additional setup after loading the view.		         
        }

		public override void ViewDidAppear()
		{
			base.ViewDidAppear();

			rendererSurface = new RendererSurface(FrameSizeWidth, FrameSizeHeight, PIXEL_SCALE, IMAGE_FLIP_X_COORD, IMAGE_FLIP_Y_COORD);
			renderer = new Renderer(rendererSurface);

			rendererSurface.Clear();
			rendererSurface.SetPixelColor(255, 0, 0, 255);
			//drawLinesInCircle(25, 12);
			draw3Dmodel();
			RefreshImage();
        }

		public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
            }
        }

        public void RefreshImage()
		{
			NSApplication.SharedApplication.InvokeOnMainThread(delegate
            {
				ImageView.Image = rendererSurface.ToNSImage();
            });
		}    

        /// <summary>
        /// Divides circle into given number of lines and draws them from
		/// the circles center.
        /// </summary>
        /// <param name="radius">Radius.</param>
        /// <param name="numberOfLines">Number of lines.</param>
        private void drawLinesInCircle(double radius, int numberOfLines)
		{
			int centerX = ScaledFrameSizeWidth / 2;
			int centerY = ScaledFrameSizeHeight / 2;

			for (int line = 0; line < numberOfLines; line++)
			{
				int degreeAngle = 360 / numberOfLines * line;
				int endPointX = (int)(Math.Cos(degreeAngle * (Math.PI / 180.0)) * radius);
				int endPointY = (int)(Math.Sin(degreeAngle * (Math.PI / 180.0)) * radius);
				renderer.DrawLine(centerX, centerY, centerX + endPointX, centerY + endPointY);
			}         
		}

        /// <summary>
        /// Draws the 3D model.
        /// </summary>
		private void draw3Dmodel()
        {
			OBJmodel model = new OBJmodel("african_head.obj");
			renderer.Render(model);
        }
    }
}
