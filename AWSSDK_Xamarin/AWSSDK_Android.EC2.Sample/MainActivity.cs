using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Amazon.EC2;
using Amazon.Runtime;

namespace AWSSDK_Android.EC2.Sample
{
	[Activity (Label = "AWSSDK_Android.EC2.Sample", MainLauncher = true)]
	public class MainActivity : Activity
	{
		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			var textView = FindViewById<TextView> (Resource.Id.textView1);

			var client = new AmazonEC2Client (new BasicAWSCredentials (ACCESS_KEY, SECRET_KEY), Amazon.RegionEndpoint.USEast1);
			var response = client.AllocateAddress ();

			textView.Text = response.PublicIp;
		}
	}
}


