// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace CloudWatch.Sample
{
	[Register ("CloudWatch_SampleViewController")]
	partial class CloudWatch_SampleViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton GetCloudWatchData { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (GetCloudWatchData != null) {
				GetCloudWatchData.Dispose ();
				GetCloudWatchData = null;
			}
		}
	}
}
