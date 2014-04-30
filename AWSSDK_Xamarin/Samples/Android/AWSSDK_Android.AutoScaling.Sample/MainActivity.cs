using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;
using Amazon.Runtime;

namespace AWSSDK_Android.AutoScaling.Sample
{
	[Activity (Label = "AWSSDK_Android.AutoScaling.Sample", MainLauncher = true)]
	public class MainActivity : Android.App.Activity
	{
		int count = 1;

		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";
		const string INSTANCE_ID = "";

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate
			{
				button.Text = string.Format ("{0} clicks!", count++);
			};
				
			var client = new AmazonAutoScalingClient (new BasicAWSCredentials (ACCESS_KEY, SECRET_KEY), Amazon.RegionEndpoint.USEast1);

			// Attach specified instance.
			var request = new AttachInstancesRequest ();
			request.AutoScalingGroupName = "TestGroup";
			request.InstanceIds = new System.Collections.Generic.List<string> { INSTANCE_ID };
			client.AttachInstances (request);
		}
	}
}


