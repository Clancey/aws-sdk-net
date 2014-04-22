// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace S3.Sample
{
	[Register ("S3SampleViewController")]
	partial class S3SampleViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton CreateButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton DeleteButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIProgressView ProgressBar { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel StatusLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton UploadButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CreateButton != null) {
				CreateButton.Dispose ();
				CreateButton = null;
			}

			if (UploadButton != null) {
				UploadButton.Dispose ();
				UploadButton = null;
			}

			if (DeleteButton != null) {
				DeleteButton.Dispose ();
				DeleteButton = null;
			}

			if (StatusLabel != null) {
				StatusLabel.Dispose ();
				StatusLabel = null;
			}

			if (ProgressBar != null) {
				ProgressBar.Dispose ();
				ProgressBar = null;
			}
		}
	}
}
