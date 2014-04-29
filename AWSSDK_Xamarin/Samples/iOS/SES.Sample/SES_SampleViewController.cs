using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Amazon.SimpleEmail;

namespace SES.Sample
{
	public partial class SES_SampleViewController : UIViewController
	{
		public SES_SampleViewController () : base ("SES_SampleViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			SubmitButton.TouchUpInside += HandleTouchUpInside;
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt)
		{
			base.TouchesBegan (touches, evt);
			Comments.ResignFirstResponder ();
			Name.ResignFirstResponder ();
		}

		void HandleTouchUpInside (object sender, EventArgs e)
		{
			const string ACCESS_KEY = "";
			const string SECRET_KEY = "";
			const string YOUR_EMAIL = "";

			AmazonSimpleEmailServiceClient sesClient = new Amazon.SimpleEmail.AmazonSimpleEmailServiceClient (ACCESS_KEY, SECRET_KEY, Amazon.RegionEndpoint.USEast1);

			var messageBody = new Amazon.SimpleEmail.Model.Content (String.Format("Rating: {0}\n\nComments:\n{1}", Rating.SelectedSegment, Comments.Text));
			var body = new Amazon.SimpleEmail.Model.Body (messageBody);
			var subject = new Amazon.SimpleEmail.Model.Content (String.Format ("Feedback from {0}", Name.Text));

			var message = new Amazon.SimpleEmail.Model.Message (subject, body);
			var destination = new Amazon.SimpleEmail.Model.Destination (new System.Collections.Generic.List<string> (){ YOUR_EMAIL });

			var sendEmailRequest = new Amazon.SimpleEmail.Model.SendEmailRequest (YOUR_EMAIL, destination, message);

			sesClient.SendEmail (sendEmailRequest);
		}
	}
}

