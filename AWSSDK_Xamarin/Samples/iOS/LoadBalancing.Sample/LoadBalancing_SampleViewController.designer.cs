// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace LoadBalancing.Sample
{
	[Register ("LoadBalancing_SampleViewController")]
	partial class LoadBalancing_SampleViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIButton CreateLoadBalancer { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel LoadBalancerStatus { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CreateLoadBalancer != null) {
				CreateLoadBalancer.Dispose ();
				CreateLoadBalancer = null;
			}

			if (LoadBalancerStatus != null) {
				LoadBalancerStatus.Dispose ();
				LoadBalancerStatus = null;
			}
		}
	}
}
