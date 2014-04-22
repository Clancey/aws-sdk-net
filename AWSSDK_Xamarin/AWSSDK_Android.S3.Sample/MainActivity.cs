using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;

namespace S3Example
{
	[Activity(Label = "S3 Example", MainLauncher = true, Icon = "@drawable/icon")]
	public class S3Example : Activity
	{
		private const int SELECT_PICTURE = 1;

		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";

		string bucketName;

		Android.Widget.Button createButton;
		Android.Widget.Button uploadButton;
		Android.Widget.Button deleteButton;
		Android.Widget.TextView statusText;
		Android.Widget.ProgressBar progressBar;

		IAmazonS3 s3Client = new AmazonS3Client(ACCESS_KEY, SECRET_KEY, Amazon.RegionEndpoint.USWest1);

		protected override void OnSaveInstanceState(Bundle outState)
		{
			outState.PutString("bucketName", this.bucketName);
		}

		protected override void OnRestoreInstanceState(Bundle savedInstanceState)
		{
			this.bucketName = savedInstanceState.GetString("bucketName");

			this.createButton.Enabled = bucketName == null;
			this.uploadButton.Enabled = bucketName != null;
			this.deleteButton.Enabled = bucketName != null;
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Create your application here
			Android.Widget.GridLayout layout = new Android.Widget.GridLayout(this);
			layout.ColumnCount = 1;
			layout.RowCount = 5;

			createButton = new Android.Widget.Button(this);
			createButton.Text = "Create Bucket";
			createButton.Click += createButton_Click;
			layout.AddView(createButton);

			uploadButton = new Android.Widget.Button(this);
			uploadButton.Text = "Upload Image";
			uploadButton.Click += uploadButton_Click;
			uploadButton.Enabled = false;
			layout.AddView(uploadButton);

			deleteButton = new Android.Widget.Button(this);
			deleteButton.Text = "Delete Bucket";
			deleteButton.Click += deleteButton_Click;
			deleteButton.Enabled = false;
			layout.AddView(deleteButton);

			statusText = new Android.Widget.TextView(this);
			layout.AddView(statusText);

			progressBar = new Android.Widget.ProgressBar(this);
			progressBar.Visibility = ViewStates.Invisible;


			layout.AddView(progressBar);


			SetContentView(layout);
		}

		async void createButton_Click(object sender, EventArgs ex)
		{
			try
			{
				bucketName = "xamarin-bucket" + DateTime.Now.Ticks;
				this.progressBar.Visibility = ViewStates.Visible;
				var response = await s3Client.PutBucketAsync(new PutBucketRequest() { BucketName = bucketName });

				createButton.Enabled = false;
				uploadButton.Enabled = true;
				deleteButton.Enabled = true;

				statusText.Text = string.Format("Bucket {0} created", this.bucketName);
			}
			catch (Exception e)
			{
				this.statusText.Text = string.Format("Error creating bucket: {0}", e.Message);
			}
			finally
			{
				this.progressBar.Visibility = ViewStates.Invisible;
			}
		}

		void uploadButton_Click(object sender, EventArgs ex)
		{
			try
			{
				Intent intent = new Intent();
				intent.SetType("image/*");
				intent.SetAction(Intent.ActionGetContent);
				StartActivityForResult(Intent.CreateChooser(intent, "Select Picture"), SELECT_PICTURE);
			}
			catch (Exception e)
			{
				this.statusText.Text = string.Format("Error uploading to bucket: {0}", e.Message);
			}
		}

		async protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			try
			{
				if (resultCode == Result.Ok)
				{
					if (requestCode == SELECT_PICTURE)
					{
						var selectedImageUri = data.Data;
						string path = GetPathToImage(selectedImageUri);
						PutObjectRequest request = new PutObjectRequest()
						{
							BucketName = this.bucketName,
							FilePath = path
						};

						progressBar.Visibility = ViewStates.Visible;
						await this.s3Client.PutObjectAsync(request);

						this.statusText.Text = string.Format("Uploaded {0}", path);
					}
				}
			}
			catch (Exception e)
			{
				this.statusText.Text = string.Format("Error uploading to bucket: {0}", e.Message);
			}
			finally
			{
				progressBar.Visibility = ViewStates.Invisible;
			}
		}

		async void deleteButton_Click(object sender, EventArgs ex)
		{
			try
			{
				this.progressBar.Visibility = ViewStates.Visible;
				await System.Threading.Tasks.Task.Factory.FromAsync(
					AmazonS3Util.BeginDeleteS3BucketWithObjects(this.s3Client, this.bucketName, null, null),
					(result) => AmazonS3Util.EndDeleteS3BucketWithObjects(result as IAsyncCancelableResult));

				this.createButton.Enabled = true;
				this.uploadButton.Enabled = false;
				this.deleteButton.Enabled = false;
				this.statusText.Text = string.Format("Deleted bucket {0}", this.bucketName);
				this.bucketName = null;
			}
			catch (Exception e)
			{
				this.statusText.Text = string.Format("Error deleting bucket: {0}", e.Message);
			}
			finally
			{
				this.progressBar.Visibility = ViewStates.Invisible;
			}
		}

		private string GetPathToImage(Android.Net.Uri uri)
		{
			string path = null;
			// The projection contains the columns we want to return in our query.
			string[] projection = new[] { Android.Provider.MediaStore.Images.Media.InterfaceConsts.Data };
			using (Android.Database.ICursor cursor = this.ManagedQuery(uri, projection, null, null, null))
			{
				if (cursor != null)
				{
					int columnIndex = cursor.GetColumnIndexOrThrow(Android.Provider.MediaStore.Images.Media.InterfaceConsts.Data);
					cursor.MoveToFirst();
					path = cursor.GetString(columnIndex);
				}
			}
			return path;
		}
	}
}
