using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Amazon.AutoScaling;
using Amazon.Runtime;
using Amazon.AutoScaling.Model;

namespace AWSSDK_iOS.AutoScaling.Sample
{
	public partial class AWSSDK_iOS_AutoScaling_SampleViewController : UIViewController
	{
		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";
		const string INSTANCE_ID = "";

		public AWSSDK_iOS_AutoScaling_SampleViewController () : base ("AWSSDK_iOS_AutoScaling_SampleViewController", null)
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
			
			var client = new AmazonAutoScalingClient (new BasicAWSCredentials (ACCESS_KEY, SECRET_KEY), Amazon.RegionEndpoint.USEast1);

			// Attach specified instance.
			var request = new AttachInstancesRequest ();
			request.AutoScalingGroupName = "TestGroup";
			request.InstanceIds = new System.Collections.Generic.List<string> { INSTANCE_ID };
			client.AttachInstances (request);
		}
	}
}

