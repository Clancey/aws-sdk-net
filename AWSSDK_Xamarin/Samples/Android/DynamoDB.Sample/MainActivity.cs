using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Linq;
using System.Collections.Generic;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using System.Collections;
using Amazon.DynamoDBv2.DocumentModel;

namespace DynamoDB.Sample
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
	[Activity (Label = "AWSSDK_Android.Sample.DynamoDB", MainLauncher = true)]
	public class MainActivity : Activity
	{
		const string ACCESS_KEY = "";
		const string SECRET_KEY = "";

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate
			{
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
			};
		}
	}
}


