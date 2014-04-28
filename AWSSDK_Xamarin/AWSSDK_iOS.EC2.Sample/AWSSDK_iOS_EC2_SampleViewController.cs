using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Amazon.EC2;
using Amazon.Runtime;

namespace AWSSDK_iOS.EC2.Sample
{
	public partial class AWSSDK_iOS_EC2_SampleViewController : UIViewController
	{
		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";

		public AWSSDK_iOS_EC2_SampleViewController () : base ("AWSSDK_iOS_EC2_SampleViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			var client = new AmazonEC2Client (new BasicAWSCredentials (ACCESS_KEY, SECRET_KEY), Amazon.RegionEndpoint.USEast1);
			var response = client.AllocateAddress ();

			var textView = new UITextView (new RectangleF (new PointF (64.0f, 64.0f), new SizeF (96.0f, 32.0f)));

			textView.Text = response.PublicIp;

			this.View.AddSubview (textView);
		}
	}
}

