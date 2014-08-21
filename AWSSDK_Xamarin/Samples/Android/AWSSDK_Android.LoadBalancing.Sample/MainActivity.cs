using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Amazon.ElasticLoadBalancing;

namespace AWSSDK_Android.LoadBalancing.Sample
{
	[Activity (Label = "AWSSDK_Android.LoadBalancing.Sample", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			const string ACCESS_KEY = "";
			const string SECRET_KEY = "";
			AmazonElasticLoadBalancingClient sLBClient = new AmazonElasticLoadBalancingClient(ACCESS_KEY, SECRET_KEY, Amazon.RegionEndpoint.USEast1);

			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				var request = new Amazon.ElasticLoadBalancing.Model.CreateLoadBalancerRequest ("newLoadBalancer");
				request.AvailabilityZones = new System.Collections.Generic.List<string>{ "us-east-1b", "us-east-1c" };
				var listener = new Amazon.ElasticLoadBalancing.Model.Listener ("HTTP", 80, 45);
				request.Listeners = new System.Collections.Generic.List<Amazon.ElasticLoadBalancing.Model.Listener>{ listener };

				var response = sLBClient.CreateLoadBalancer (request);
				var status   = FindViewById<EditText>(Resource.Id.status);
				status.Text = String.Format ("Load balancer {0} was created.", response.DNSName);
			};
		}
	}
}


