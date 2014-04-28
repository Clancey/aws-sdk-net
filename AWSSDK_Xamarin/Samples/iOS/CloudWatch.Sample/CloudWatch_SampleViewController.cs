using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;
using System.Collections.Generic;

namespace CloudWatch.Sample
{
	public partial class CloudWatch_SampleViewController : UIViewController
	{
		public CloudWatch_SampleViewController () : base ("CloudWatch_SampleViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
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
			foreach (Datapoint point in datapoints)
			{
				Console.WriteLine("Min:{0} Max:{1} Average:{3} Unit: {4}", point.Minimum, point.Maximum, point.Average, point.Unit);
			}
		}
	}
}

