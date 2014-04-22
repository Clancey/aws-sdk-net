using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace SNSExample
{
	[Activity(Label = "SNS Example", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";

		string topicName;
		string topicArn;

		Android.Widget.Button createTopic;
		Android.Widget.Button subscribe;
		Android.Widget.Button deleteTopic;
		Android.Widget.EditText emailText;
		Android.Widget.TextView statusText;

		IAmazonSimpleNotificationService snsClient = new AmazonSimpleNotificationServiceClient(ACCESS_KEY, SECRET_KEY, Amazon.RegionEndpoint.USWest1);

		protected override void OnSaveInstanceState(Bundle outState)
		{
			outState.PutString("topicName", topicName);
			outState.PutString("topicArn", topicArn);
		}

		protected override void OnRestoreInstanceState(Bundle savedInstanceState)
		{
			this.topicName = savedInstanceState.GetString("topicName");
			this.topicArn = savedInstanceState.GetString("topicArn");

			this.createTopic.Enabled = topicName == null;
			this.subscribe.Enabled = topicName != null;
			this.deleteTopic.Enabled = topicName != null;
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Create your application here
			Android.Widget.GridLayout layout = new Android.Widget.GridLayout(this);
			layout.ColumnCount = 1;
			layout.RowCount = 5;

			createTopic = new Android.Widget.Button(this);
			createTopic.Text = "Create Topic";
			createTopic.Click += createTopic_Click;
			layout.AddView(createTopic);

			emailText = new Android.Widget.EditText(this);
			emailText.Text = "";
			layout.AddView(emailText);

			subscribe = new Android.Widget.Button(this);
			subscribe.Enabled = false;
			subscribe.Text = "Subscribe to Topic";
			subscribe.Click += subscribe_Click;
			layout.AddView(subscribe);

			deleteTopic = new Android.Widget.Button(this);
			deleteTopic.Click += deleteTopic_Click;
			deleteTopic.Enabled = false;
			deleteTopic.Text = "Delete Topic";
			layout.AddView(deleteTopic);

			statusText = new Android.Widget.TextView(this);
			layout.AddView(statusText);


			SetContentView(layout);
		}

		async void createTopic_Click(object sender, EventArgs ex)
		{
			try
			{
				topicName = "ZamarinTopic" + DateTime.Now.Ticks;
				var response = await snsClient.CreateTopicAsync(new CreateTopicRequest() { Name = topicName });
				topicArn = response.TopicArn;

				createTopic.Enabled = false;
				subscribe.Enabled = true;
				deleteTopic.Enabled = true;

				statusText.Text = string.Format("Topic {0} created", this.topicName);
			}
			catch (Exception e)
			{
				this.statusText.Text = string.Format("Error creating topic: {0}", e.Message);
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
					TopicArn = this.topicArn,
					Protocol = "email",
					Endpoint = emailText.Text
				};

				await snsClient.SubscribeAsync(request);
				statusText.Text = "Subscription successful";
			}
			catch (Exception e)
			{
				this.statusText.Text = string.Format("Error subscribing to topic: {0}", e.Message);
			}
		}

		async void deleteTopic_Click(object sender, EventArgs ex)
		{
			try
			{
				await snsClient.DeleteTopicAsync(new DeleteTopicRequest() { TopicArn = this.topicArn });
				this.statusText.Text = string.Format("Topic {0} deleted", this.topicName);
				createTopic.Enabled = true;
				subscribe.Enabled = false;
				deleteTopic.Enabled = false;
				this.topicArn = this.topicName = null;
			}
			catch (Exception e)
			{
				this.statusText.Text = string.Format("Error deleting topic: {0}", e.Message);
			}
		}
	}
}

