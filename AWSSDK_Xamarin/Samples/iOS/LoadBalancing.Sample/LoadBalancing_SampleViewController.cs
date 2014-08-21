using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Amazon.ElasticLoadBalancing;

namespace LoadBalancing.Sample
{
	public partial class LoadBalancing_SampleViewController : UIViewController
	{
		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";
		AmazonElasticLoadBalancingClient sLBClient = new AmazonElasticLoadBalancingClient(ACCESS_KEY, SECRET_KEY, Amazon.RegionEndpoint.USEast1);

		public LoadBalancing_SampleViewController () : base ("LoadBalancing_SampleViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			CreateLoadBalancer.TouchUpInside += HandleTouchUpInside;
		}

		void HandleTouchUpInside (object sender, EventArgs e)
		{
			var request = new Amazon.ElasticLoadBalancing.Model.CreateLoadBalancerRequest ("newLoadBalancer");
			request.AvailabilityZones = new System.Collections.Generic.List<string>{ "us-east-1b", "us-east-1c" };
			var listener = new Amazon.ElasticLoadBalancing.Model.Listener ("HTTP", 80, 45);
			request.Listeners = new System.Collections.Generic.List<Amazon.ElasticLoadBalancing.Model.Listener>{ listener };

			var response = sLBClient.CreateLoadBalancer (request);
			LoadBalancerStatus.Text = String.Format ("Load balancer {0} was created.", response.DNSName);
		}
	}
}

