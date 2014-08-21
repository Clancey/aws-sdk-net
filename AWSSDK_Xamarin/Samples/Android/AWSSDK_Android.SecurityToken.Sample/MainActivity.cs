using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Amazon.SecurityToken;
using Amazon.Runtime;

namespace AWSSDK_Android.SecurityToken.Sample
{
	[Activity (Label = "AWSSDK_Android.SecurityToken.Sample", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;

		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";

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

			var client = new AmazonSecurityTokenServiceClient (new BasicAWSCredentials (ACCESS_KEY, SECRET_KEY), Amazon.RegionEndpoint.USEast1);
			var response = client.GetSessionToken ();

			Console.WriteLine (response.Credentials.AccessKeyId);
		}
	}
}


