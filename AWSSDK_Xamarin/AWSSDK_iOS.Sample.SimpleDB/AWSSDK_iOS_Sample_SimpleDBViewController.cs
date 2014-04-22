using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Amazon.SimpleDB;

// http://aws.amazon.com/articles/SDKs/iOS/8829919029640036
namespace AWSSDK_iOS.Sample.SimpleDB
{
	public partial class AWSSDK_iOS_Sample_SimpleDBViewController : UIViewController
	{
		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";

		AmazonSimpleDBClient _simpleDBClient = new AmazonSimpleDBClient (ACCESS_KEY, SECRET_KEY, Amazon.RegionEndpoint.USWest1);
		public AWSSDK_iOS_Sample_SimpleDBViewController () : base ("AWSSDK_iOS_Sample_SimpleDBViewController", null)
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
		}
	}
}

