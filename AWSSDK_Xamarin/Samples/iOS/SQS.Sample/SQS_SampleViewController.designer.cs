// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace SQS.Sample
{
	[Register ("SQS_SampleViewController")]
	partial class SQS_SampleViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton CreateQueue { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel CreateQueueResults { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CreateQueue != null) {
				CreateQueue.Dispose ();
				CreateQueue = null;
			}

			if (CreateQueueResults != null) {
				CreateQueueResults.Dispose ();
				CreateQueueResults = null;
			}
		}
	}
}
