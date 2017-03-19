
using System;
using System.Collections.Generic;
using System.Windows.Input;
using ＭvvmDemo.Models;
using Xamarin.Forms;

namespace ＭvvmDemo.Controls
{
	public partial class ActorCell : ViewCell
	{
		public ActorCell()
		{
			InitializeComponent();
		}

		#region "Actor BindableProperty"
		public static readonly BindableProperty ActorProperty =
			BindableProperty.Create(
				"Actor",
				typeof(Actor),
				typeof(ActorCell),
				null);
		public Actor Actor
		{
			get { return (Actor)GetValue(ActorProperty); }
			set { SetValue(ActorProperty, value); }
		}
		#endregion

		#region ItemTappedCommand BindableProperty
		public static readonly BindableProperty ItemTappedCommandProperty =
			BindableProperty.Create(
				"ItemTappedCommand",
				typeof(ICommand),
				typeof(ActorCell),
				null);
		public ICommand ItemTappedCommand
		{
			get { return (ICommand)GetValue(ItemTappedCommandProperty); }
			set { SetValue(ItemTappedCommandProperty, value); }
		}			
		#endregion

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();

			if (BindingContext != null)
			{
				imgPhoto.Source = Actor.Photo;
				lblName.Text = Actor.Name;
				lblSign.Text = Actor.Sign;
				lblBloodType.Text = Actor.BloodType;
			}
		}

		void ActorCell_Tapped(object sender, System.EventArgs e)
		{
			if (ItemTappedCommand != null)
			{
				ItemTappedCommand.Execute(Actor);
			}
		}
	}
}
