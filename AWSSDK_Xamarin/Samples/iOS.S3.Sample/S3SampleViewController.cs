using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;

namespace S3.Sample
{
	public partial class S3SampleViewController : UIViewController
	{
		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";
		IAmazonS3 s3Client = new AmazonS3Client(ACCESS_KEY, SECRET_KEY, Amazon.RegionEndpoint.USWest1);

		string bucketName;

		public S3SampleViewController () : base ("S3SampleViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			StatusLabel.Text = "";
			ProgressBar.Hidden = true;
			CreateButton.Enabled = true;
			UploadButton.Enabled = false;
			DeleteButton.Enabled = false;
			CreateButton.TouchUpInside += CreateButtonClick; 
			UploadButton.TouchUpInside += UploadButtonClick;
			DeleteButton.TouchUpInside += DeleteButtonClick;
		}

		async void DeleteButtonClick (object sender, EventArgs e)
		{
			try
			{
				ProgressBar.Hidden = false;
				await System.Threading.Tasks.Task.Factory.FromAsync(
					AmazonS3Util.BeginDeleteS3BucketWithObjects(this.s3Client, bucketName, null, null),
					(result) => AmazonS3Util.EndDeleteS3BucketWithObjects(result as IAsyncCancelableResult));

				CreateButton.Enabled = true;
				UploadButton.Enabled = false;
				DeleteButton.Enabled = false;
				StatusLabel.Text = string.Format("Deleted bucket {0}", bucketName);
				bucketName = null;
			}
			catch (Exception ex)
			{
				StatusLabel.Text = string.Format("Error deleting bucket: {0}", ex.Message);
			}
			finally
			{
				ProgressBar.Hidden = true;
			}
		}

		void UploadButtonClick (object sender, EventArgs e)
		{
			try
			{
				var imagePicker = new UIImagePickerController ();
				imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
				imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);
				imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
				imagePicker.Canceled += Handle_Canceled;
				imagePicker.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;
				NavigationController.PresentViewController(imagePicker, true, null);
			}
			catch (Exception ex)
			{
				StatusLabel.Text = string.Format("Error uploading to bucket: {0}", ex.Message);
			}
		}

		async void CreateButtonClick (object sender, EventArgs e)
		{
			try
			{
				bucketName = "xamarin-bucket" + DateTime.Now.Ticks;
				ProgressBar.Hidden = false;
				var response = await s3Client.PutBucketAsync(new PutBucketRequest() { BucketName = bucketName });

				CreateButton.Enabled = false;
				UploadButton.Enabled = true;
				DeleteButton.Enabled = true;

				StatusLabel.Text = string.Format("Bucket {0} created", this.bucketName);
			}
			catch (Exception ex)
			{
				StatusLabel.Text = string.Format("Error creating bucket: {0}", ex.Message);
			}
			finally
			{
				ProgressBar.Hidden = true;
			}
		}

		async void Handle_FinishedPickingMedia (object sender, UIImagePickerMediaPickedEventArgs e)
		{
			try
			{
				PutObjectRequest request = new PutObjectRequest()
				{
					BucketName = this.bucketName,
					Key = "Photo Library Image",
					ContentType = "image/jpg",
					InputStream = e.OriginalImage.AsJPEG().AsStream()
				};

				ProgressBar.Hidden =  false;
				var response = await this.s3Client.PutObjectAsync(request);

				StatusLabel.Text = string.Format("Uploaded image!");
			}
			catch (Exception ex)
			{
				StatusLabel.Text = string.Format("Error uploading to bucket: {0}", ex.Message);
			}
			finally
			{
				NavigationController.DismissViewController (false, null);
				ProgressBar.Hidden = true;
			}
		}

		void Handle_Canceled (object sender, EventArgs e)
		{
			NavigationController.DismissViewController (false, null);
		}
	}
}
