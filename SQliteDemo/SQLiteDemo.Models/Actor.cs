using System;
using SQLite;

namespace SQLiteDemo.Models
{
	public class Actor
	{
		public string Name { get; set; }
		public string Photo { get; set; }
		public string BreastType { get; set; }
		public string Cup { get; set; }
		public string Sign { get; set; }
		public string BodyType { get; set; }
		public string Bust { get; set; }
		public string Waist { get; set; }
		public string Hip { get; set; }
		public string BloodType { get; set; }
		public string Height { get; set; }
		[PrimaryKey]
		public int ID { get; set; }

	}
}
