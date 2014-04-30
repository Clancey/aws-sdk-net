using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Amazon.SQS;

namespace SQS.Sample
{
	public partial class SQS_SampleViewController : UIViewController
	{
		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";

		public SQS_SampleViewController () : base ("SQS_SampleViewController", null)
		{
		}
			
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			CreateQueue.TouchUpInside += delegate(object sender, EventArgs e) {			
				var sqsClient = new Amazon.SQS.AmazonSQSClient (ACCESS_KEY, SECRET_KEY, Amazon.RegionEndpoint.EUWest1);
				var request = new Amazon.SQS.Model.CreateQueueRequest ();
				request.QueueName = "newQueue";
				var response = sqsClient.CreateQueue (request);
				CreateQueueResults.Text = String.Format("Queue created at {0}.", response.QueueUrl);
			};
		}
	}
}

