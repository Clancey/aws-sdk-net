using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Linq;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using System.Collections;
using Amazon.DynamoDBv2.DocumentModel;

namespace AWSSDK_iOS.Sample.DynamoDB
{
	[DynamoDBTable("Movies")]
	public class Movie
	{
		public Movie (string title, DateTime releaseDate)
		{
			Title = title;
			ReleaseDate = releaseDate;

			Genres = new List<string> ();
			ActorNames = new List<string> ();
		}

		public Movie () {}

		[DynamoDBHashKey]
		public string Title { get; set; }

		[DynamoDBRangeKey]
		public DateTime ReleaseDate { get; set; }

		public List<string> Genres { get; set; }
		public List<string> ActorNames { get; set; }
	}

	[DynamoDBTable("Actors")]
	public class Actor
	{
		public Actor (string name)
		{
			Name = name;
		}

		public Actor () {}

		[DynamoDBHashKey]
		public string Name { get; set; }

		[DynamoDBProperty(AttributeName="Bio")]
		public string Biography { get; set; }

		public DateTime BirthDate { get; set; }

		[DynamoDBProperty(AttributeName="Height")]
		public float HeightInMeters { get; set; }

		public TimeSpan Age { get { return DateTime.Now - BirthDate; } }

		[DynamoDBIgnore]
		public string Comment { get; set; }
	}

	// http://aws.amazon.com/articles/SDKs/.NET/2790257258340776
	public partial class AWSSDK_iOS_Sample_DynamoDBViewController : UIViewController
	{
		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";

		public AWSSDK_iOS_Sample_DynamoDBViewController () : base ("AWSSDK_iOS_Sample_DynamoDBViewController", null)
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


			var client = new AmazonDynamoDBClient(ACCESS_KEY, SECRET_KEY, Amazon.RegionEndpoint.USEast1);
			var context = new DynamoDBContext(client);

			var actor = new Actor("John Doe");
			context.Save(actor);

			actor = context.Load<Actor>("John Doe");
			actor.Biography = "Current email: john.doe@example.net";
			context.Save(actor);

			context.Delete(actor);

			var movie = new Movie("Casablanca", new DateTime(1943, 1, 23));
			context.Save(movie);

			movie = context.Load<Movie>("Casablanca", new DateTime(1943, 1, 23));
			movie.Genres = new List<string> { "Drama", "Romance", "War" };
			context.Save(movie);

			DateTime date = new DateTime(1960, 1, 1);
			var queryResults = context.Query<Movie>("Casablanca", QueryOperator.LessThan, date).ToList ();

			foreach (var result in queryResults)
				Console.WriteLine(result.Title);
		}
	}
}

