using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Amazon.SimpleEmail;

namespace AWSSDK_Android.SES.Sample
{
	[Activity (Label = "AWSSDK_Android.SES.Sample", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				const string ACCESS_KEY = "";
				const string SECRET_KEY = "";
				const string YOUR_EMAIL = "";

				AmazonSimpleEmailServiceClient sesClient = new Amazon.SimpleEmail.AmazonSimpleEmailServiceClient (ACCESS_KEY, SECRET_KEY, Amazon.RegionEndpoint.USEast1);
				var Name   = FindViewById<EditText>(Resource.Id.name);
				var Rating = FindViewById<RatingBar>(Resource.Id.ratingBar);
				var Comments = FindViewById<EditText>(Resource.Id.comments);

				var messageBody = new Amazon.SimpleEmail.Model.Content (String.Format("Rating: {0}\n\nComments:\n{1}", Rating.Selected, Comments.Text));
				var body = new Amazon.SimpleEmail.Model.Body (messageBody);
				var subject = new Amazon.SimpleEmail.Model.Content (String.Format ("Feedback from {0}", Name.Text));

				var message = new Amazon.SimpleEmail.Model.Message (subject, body);
				var destination = new Amazon.SimpleEmail.Model.Destination (new System.Collections.Generic.List<string> (){ YOUR_EMAIL });

				var sendEmailRequest = new Amazon.SimpleEmail.Model.SendEmailRequest (YOUR_EMAIL, destination, message);

				sesClient.SendEmail (sendEmailRequest);
			};
		}
	}
}


