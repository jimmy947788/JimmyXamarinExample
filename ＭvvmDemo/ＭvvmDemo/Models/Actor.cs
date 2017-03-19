using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ＭvvmDemo.Models
{
	public class Actor
	{
		public Actor()
		{
		}

		public string Name { get; set; }
		public ImageSource Photo { get; set; }
		public string BreastType { get; set; }
		public string Cup { get; set; }
		public string Sign { get; set; }
		public string BodyType { get; set; }
		public string Bust { get; set; }
		public string Waist { get; set; }
		public string Hip { get; set; }
		public string BloodType { get; set; }
		public string Height { get; set; }
		public int ID { get; set; }
	}
}
