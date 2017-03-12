using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace ListViewDemo.Controls
{
	public partial class ActorCell : ViewCell
	{
		public ActorCell()
		{
			InitializeComponent();
		}

		#region "ID BindableProperty"
		public static readonly BindableProperty IDProperty =
			BindableProperty.Create(
				"ID",
				typeof(int),
				typeof(ActorCell),
				-1);
		public int ID
		{
			get { return (int)GetValue(IDProperty); }
			set { SetValue(IDProperty, value); }
		}
		#endregion

		#region "Name BindableProperty"
		public static readonly BindableProperty NameProperty =
			BindableProperty.Create(
				"Name",
				typeof(string),
				typeof(ActorCell),
				null);
		public string Name
		{
			get { return (string)GetValue(NameProperty); }
			set { SetValue(NameProperty, value); }
		}
		#endregion

		#region "Photo BindableProperty"
		public static readonly BindableProperty PhotoProperty =
			BindableProperty.Create(
				"Photo",
				typeof(ImageSource),
				typeof(ActorCell),
				null);
		public ImageSource Photo
		{
			get { return (ImageSource)GetValue(PhotoProperty); }
			set { SetValue(PhotoProperty, value); }
		}
		#endregion

		#region "Sign BindableProperty"
		public static readonly BindableProperty SignProperty =
			BindableProperty.Create(
				"Sign",
				typeof(string),
				typeof(ActorCell),
				null);
		public string Sign
		{
			get { return (string)GetValue(SignProperty); }
			set { SetValue(SignProperty, value); }
		}
		#endregion

		#region "BloodType BindableProperty"
		public static readonly BindableProperty BloodTypeProperty =
			BindableProperty.Create(
				"BloodType",
				typeof(string),
				typeof(ActorCell),
				null);
		public string BloodType
		{
			get { return (string)GetValue(BloodTypeProperty); }
			set { SetValue(BloodTypeProperty, value); }
		}
		#endregion

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (BindingContext != null)
			{
				imgPhoto.Source = Photo;
				lblName.Text = Name;
				lblSign.Text = Sign;
				lblBloodType.Text = BloodType;
			}
		}

		public void OnMore_Click(object sender, EventArgs e)
		{
			Debug.WriteLine("OnMore_Click ID:{0}", ID);
		}

		public void OnDelete_Click(object sender, EventArgs e)
		{
			Debug.WriteLine("OnDelete_Click ID:{0}", ID);
		}
	}
}
