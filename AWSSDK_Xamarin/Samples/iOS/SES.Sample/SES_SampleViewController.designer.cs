// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace SES.Sample
{
	[Register ("SES_SampleViewController")]
	partial class SES_SampleViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextView Comments { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField Name { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISegmentedControl Rating { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton SubmitButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Name != null) {
				Name.Dispose ();
				Name = null;
			}

			if (Comments != null) {
				Comments.Dispose ();
				Comments = null;
			}

			if (Rating != null) {
				Rating.Dispose ();
				Rating = null;
			}

			if (SubmitButton != null) {
				SubmitButton.Dispose ();
				SubmitButton = null;
			}
		}
	}
}
