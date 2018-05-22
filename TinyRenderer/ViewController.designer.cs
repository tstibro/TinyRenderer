// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TinyRenderer
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSImageView ImageView { get; set; }

		[Outlet]
		AppKit.NSView WindowView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (WindowView != null) {
				WindowView.Dispose ();
				WindowView = null;
			}

			if (ImageView != null) {
				ImageView.Dispose ();
				ImageView = null;
			}
		}
	}
}
