using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using System.Collections.Generic;

namespace AWSSDK_Android.CloudWatch.Sample
{
	[Activity (Label = "AWSSDK_Android.CloudWatch.Sample", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.getcloudwatchdata);
			EditText cloudwatchdata = FindViewById<EditText> (Resource.Id.cloudwatchdata);

			button.Click += delegate {
				const string ACCESS_KEY = "";
				const string SECRET_KEY = "";
				IAmazonCloudWatch cw = Amazon.AWSClientFactory.CreateAmazonCloudWatchClient (ACCESS_KEY, SECRET_KEY, Amazon.RegionEndpoint.USWest1);

				string measureName = "CPUUtilization";

				GetMetricStatisticsRequest request = new GetMetricStatisticsRequest ();
				request.StartTime = DateTime.Now.AddDays (-1);
				request.Namespace = "AWS/EC2";
				request.Period = 5 * 60;
				var dimensions = new Dimension ();
				dimensions.Name = "InstanceType";
				dimensions.Value = "t1.micro";
				request.Dimensions = new List<Dimension>{ dimensions };
				request.MetricName = measureName;
				request.Statistics = new List<string>{"Average", "Maximum", "Minimum"};
				request.EndTime = DateTime.Now;

				List<Datapoint> datapoints = cw.GetMetricStatistics(request).Datapoints;
				datapoints.ForEach(d => cloudwatchdata.Text = String.Format("Min: {0} Max: {1} Average: {3} Unit: {4}\n", d.Minimum, d.Maximum, d.Average, d.Unit));
			};
		}
	}
}

