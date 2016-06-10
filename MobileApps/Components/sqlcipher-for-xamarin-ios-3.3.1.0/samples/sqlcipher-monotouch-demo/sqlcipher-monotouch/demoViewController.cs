using System;
using System.IO;
using System.Text;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Mono.Data.Sqlcipher;

namespace demo
{
	public partial class demoViewController : UIViewController
	{
		public demoViewController () : base ("demoViewController", null)
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
			
			// Perform any additional setup after loading the view, typically from a nib.
			this.mainButton.TouchUpInside += (sender, e) => {
				Console.WriteLine ("button pressed");
				InitializeSQLCipher ();
			};
			
			this.clearButton.TouchUpInside += (sender, e) => {
				ClearSQLCipher();	
			};
		}
		
		private void InitializeSQLCipher ()
		{
			var buffer = new StringBuilder();
			outputDisplay.Text = "";
			using (var connection = GetConnection("demo.db", "test")) {
				connection.Open ();
				using (var command = connection.CreateCommand()) {
					var createTable = "create table if not exists t1(a,b)";
					var insertData = "insert into t1(a,b) values('one for the money', 'two for the show')";
					var query = "select * from t1";
					command.CommandText = createTable;
					command.ExecuteNonQuery ();
					command.CommandText = insertData;
					command.ExecuteNonQuery();
					command.CommandText = query;
					var reader = command.ExecuteReader();
					while(reader.Read())
					{
						var a = reader.GetString(0);
						var b = reader.GetString(1);
						buffer.Append(String.Format("a:{0} b:{1}{2}", a, b, Environment.NewLine));
					}
				}
				connection.Close();
			}
			outputDisplay.Text = buffer.ToString();
		}
		
		private void ClearSQLCipher()
		{
			using(var connection = GetConnection("demo.db", "test"))
			{
				connection.Open();
				using(var command = connection.CreateCommand())
				{
					command.CommandText = "delete from t1";
					command.ExecuteNonQuery();
				}
				connection.Close();
			}
			outputDisplay.Text = "";
		}
		
		private SqliteConnection GetConnection(String databaseName, String password)
		{
			var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseName);
			var conn =  new SqliteConnection(String.Format("Data Source={0}", databasePath));
			conn.SetPassword(password);
			return conn;
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}
	}
}

