using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Amazon.Kinesis.Model;
using Amazon.Kinesis;
using Amazon.Runtime;

namespace Kinesis.Droid.Sample
{
	[Activity (Label = "Kinesis.Droid.Sample", MainLauncher = true)]
	public class MainActivity : Activity
	{
		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";

		int count = 1;

		PutRecordResponse PutRecord (AmazonKinesisClient client)
		{
			var request = new PutRecordRequest ();
			request.StreamName = "Test1";
			request.Data = new System.IO.MemoryStream (new byte[] { 123 });
			request.PartitionKey = "p1337";

			return client.PutRecord (request);
		}

		GetRecordsResponse GetRecords (AmazonKinesisClient client, string shardId)
		{
			var siRequest = new GetShardIteratorRequest ();
			siRequest.ShardId = shardId;
			siRequest.StreamName = "Test1";
			siRequest.ShardIteratorType = "TRIM_HORIZON";

			var siResponse = client.GetShardIterator (siRequest);
			var request = new GetRecordsRequest ();
			request.ShardIterator = siResponse.ShardIterator;

			return client.GetRecords (request);
		}

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

			var client = new AmazonKinesisClient (new BasicAWSCredentials (ACCESS_KEY, SECRET_KEY), Amazon.RegionEndpoint.USEast1);

			var putResponse = PutRecord (client);

			var response = GetRecords (client, putResponse.ShardId);

			for (int i = 0; i < response.Records.Count; ++i)
			{
				Console.WriteLine ("Record: " + response.Records [i].Data.ReadByte ());
			}
		}
	}
}


