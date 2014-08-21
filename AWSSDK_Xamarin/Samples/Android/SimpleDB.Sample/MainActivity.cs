using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Amazon.SimpleDB;

// http://aws.amazon.com/articles/SDKs/iOS/8829919029640036
namespace SimpleDB.Sample
{
	[Activity (Label = "SimpleDB.Sample", MainLauncher = true)]
	public class MainActivity : Activity
	{
		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";

		AmazonSimpleDBClient _simpleDBClient = new AmazonSimpleDBClient (ACCESS_KEY, SECRET_KEY, Amazon.RegionEndpoint.USWest1);

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
				try
				{
					var request = new Amazon.SimpleDB.Model.CreateDomainRequest ();
					request.DomainName = "HIGH_SCORE_DOMAIN";

					_simpleDBClient.CreateDomain (request);
				}
				catch (Exception e)
				{
					Console.WriteLine ("CreateDomain: " + e.Message);
				}
			};
				
		}
	}
}


