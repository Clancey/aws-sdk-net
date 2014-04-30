using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Amazon.SQS;

namespace AWSSDK_Android.SQS.Sample
{
	[Activity (Label = "AWSSDK_Android.SQS.Sample", MainLauncher = true)]
	public class MainActivity : Activity
	{
		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.createQueue);
			EditText createQueueResult = FindViewById<EditText> (Resource.Id.createQueueResult);

			button.Click += delegate {
				var sqsClient = new Amazon.SQS.AmazonSQSClient (ACCESS_KEY, SECRET_KEY, Amazon.RegionEndpoint.EUWest1);
				var request = new Amazon.SQS.Model.CreateQueueRequest ();
				request.QueueName = "newQueue";
				var response = sqsClient.CreateQueue (request);
				createQueueResult.Text = String.Format("Queue created at {0}.", response.QueueUrl);
			};
		}
	}
}
	
