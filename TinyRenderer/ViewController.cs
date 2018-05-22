using System;

using AppKit;
using Foundation;
using TinyRendererLib;
using TinyRenderer.Rendering;

namespace TinyRenderer
{
    public partial class ViewController : NSViewController
    {
		private Renderer renderer;
		private RendererSurface rendererSurface;

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

			rendererSurface = new RendererSurface((int)ImageView.Frame.Size.Width, (int)ImageView.Frame.Size.Height);
			renderer = new Renderer(rendererSurface);

			rendererSurface.Clear();
			rendererSurface.SetPixelColor(255, 0, 0, 255);
			renderer.DrawLine(0, 0, 25, 25);
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
                // Update the view, if already loaded.
            }
        }

        public void RefreshImage()
		{
			NSApplication.SharedApplication.InvokeOnMainThread(delegate
            {
				ImageView.Image = rendererSurface.ToNSImage();
            });
		}    
    }
}
