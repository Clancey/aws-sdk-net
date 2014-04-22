using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace AWSSDK_iOS.SnsSample
{
	public class EmailTextViewDelegate : UITextViewDelegate
	{
		public override bool ShouldChangeText (UITextView textView, NSRange range, string text)
		{
			if (!text.Contains ("\n"))
				return true;

			textView.ResignFirstResponder ();
			return false;
		}
	}

	public partial class AWSSDK_iOS_SnsSampleViewController : UIViewController
	{
		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";

		string _topicName;
		string _topicArn;

		UITextView _statusTextView;
		UITextView _emailTextView;
		UIButton _createTopicButton;
		UIButton _subscribeButton;
		UIButton _deleteTopicButton;

		IAmazonSimpleNotificationService snsClient = new AmazonSimpleNotificationServiceClient(ACCESS_KEY, SECRET_KEY, Amazon.RegionEndpoint.USWest1);

		public AWSSDK_iOS_SnsSampleViewController () : base ("AWSSDK_iOS_SnsSampleViewController", null)
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
			_statusTextView = new UITextView ();
			_emailTextView = new UITextView ();
			_createTopicButton = UIButton.FromType (UIButtonType.RoundedRect);
			_subscribeButton = UIButton.FromType (UIButtonType.RoundedRect);
			_deleteTopicButton = UIButton.FromType (UIButtonType.RoundedRect);

			_createTopicButton.SetTitle ("Create Topic", UIControlState.Normal);
			_subscribeButton.SetTitle ("Subscribe", UIControlState.Normal);
			_deleteTopicButton.SetTitle ("Delete Topic", UIControlState.Normal);

			_createTopicButton.TouchUpInside += createTopic_Click;
			_subscribeButton.TouchUpInside += subscribe_Click;
			_deleteTopicButton.TouchUpInside += deleteTopic_Click;

			_emailTextView.Delegate = new EmailTextViewDelegate ();

			_statusTextView.Frame = new RectangleF (0, 256, 256, 64);
			_emailTextView.Frame = new RectangleF (0, 0, 256, 64);
			_createTopicButton.Frame = new RectangleF (0, 64, 256, 64);
			_subscribeButton.Frame = new RectangleF (0, 128, 256, 64);
			_deleteTopicButton.Frame = new RectangleF (0, 192, 256, 64);

			this.View.AddSubview (_emailTextView);
			this.View.AddSubview (_createTopicButton);
			this.View.AddSubview (_subscribeButton);
			this.View.AddSubview (_deleteTopicButton);
			this.View.AddSubview (_statusTextView);
		}
			
		async void createTopic_Click(object sender, EventArgs ex)
		{
			try
			{
				_topicName = "ZamarinTopic" + DateTime.Now.Ticks;
				var response = await snsClient.CreateTopicAsync(new CreateTopicRequest() { Name = _topicName });
				_topicArn = response.TopicArn;

				_createTopicButton.Enabled = false;
				_subscribeButton.Enabled = true;
				_deleteTopicButton.Enabled = true;

				_statusTextView.Text = string.Format("Topic {0} created", _topicName);
			}
			catch (Exception e)
			{
				_statusTextView.Text = string.Format("Error creating topic: {0}", e.Message);
			}
		}

		/// <summary>
		/// By subscribe your email account should get a message confirming the topic
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		async void subscribe_Click(object sender, EventArgs ex)
		{
			try
			{
				var request = new SubscribeRequest()
				{
					TopicArn = _topicArn,
					Protocol = "email",
					Endpoint = _emailTextView.Text
				};

				await snsClient.SubscribeAsync(request);
				_statusTextView.Text = "Subscription successful";
			}
			catch (Exception e)
			{
				_statusTextView.Text = string.Format("Error subscribing to topic: {0}", e.Message);
			}
		}

		async void deleteTopic_Click(object sender, EventArgs ex)
		{
			try
			{
				await snsClient.DeleteTopicAsync(new DeleteTopicRequest() { TopicArn = _topicArn });
				_statusTextView.Text = string.Format("Topic {0} deleted", _topicName);
				_createTopicButton.Enabled = true;
				_subscribeButton.Enabled = false;
				_deleteTopicButton.Enabled = false;
				_topicArn = _topicName = null;
			}
			catch (Exception e)
			{
				_statusTextView.Text = string.Format("Error deleting topic: {0}", e.Message);
			}
		}
	}
}

