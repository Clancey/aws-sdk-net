using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;
using Amazon.Runtime;

namespace AWSSDK_iOS.SecurityToken.Sample
{
	public partial class AWSSDK_iOS_SecurityToken_SampleViewController : UIViewController
	{
		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";

		public AWSSDK_iOS_SecurityToken_SampleViewController () : base ("AWSSDK_iOS_SecurityToken_SampleViewController", null)
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
			
			var client = new AmazonSecurityTokenServiceClient (new BasicAWSCredentials (ACCESS_KEY, SECRET_KEY), Amazon.RegionEndpoint.USEast1);
			var response = client.GetSessionToken ();

			Console.WriteLine (response.Credentials.AccessKeyId);
		}
	}
}

