using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Amazon.Kinesis;
using Amazon.Kinesis.Model;
using Amazon.Runtime;

namespace Kinesis.Sample
{
	public partial class Kinesis_SampleViewController : UIViewController
	{
		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";

		public Kinesis_SampleViewController () : base ("Kinesis_SampleViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

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

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
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

