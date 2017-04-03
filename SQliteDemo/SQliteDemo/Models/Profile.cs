using System;
namespace SQliteDemo.Models
{
	public class Profile
	{
		[SQLite.PrimaryKey]
		public int Key { get; set; }
		public string Value { get; set; }
		public string Display { get; set; }
	}
}
