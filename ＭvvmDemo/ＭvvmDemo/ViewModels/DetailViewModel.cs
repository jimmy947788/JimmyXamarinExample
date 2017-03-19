using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using ＭvvmDemo.Models;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ＭvvmDemo.ViewModels
{
	public class DetailViewModel : MvvmHelpers.BaseViewModel
	{
		public DetailViewModel(string actorName)
		{
			Title = actorName;
			SaveCommand = new Command(async (obj) => {
				Debug.WriteLine("{0} was Saved.", this.Actor.Name);
				Debug.WriteLine("Total is {0}.", TotalPrice);

				IsBusy = true;
				await Task.Delay(5000);
				IsBusy = false;
			});
		}

		public Actor Actor { get; set; }

		public ICommand SaveCommand { get; private set; }

		bool isAggreeItem1 = false;
		public bool IsAggreeItem1
		{
			get { return isAggreeItem1; }
			set
			{
				SetProperty(ref isAggreeItem1, value);
				CalcTotalPrice();
			}
		}

		bool isAggreeItem2 = false;
		public bool IsAggreeItem2
		{
			get { return isAggreeItem2; }
			set
			{
				if (isAggreeItem2 != value)
				{
					isAggreeItem2 = value;
					OnPropertyChanged("IsAggreeItem2");
					CalcTotalPrice();
				}
			}
		}

		bool isAggreeItem3 = false;
		public bool IsAggreeItem3
		{
			get { return isAggreeItem3; }
			set
			{
				if (isAggreeItem3 != value)
				{
					isAggreeItem3 = value;
					OnPropertyChanged("IsAggreeItem3");
					CalcTotalPrice();
				}
			}
		}

		bool isAggreeItem4 = false;
		public bool IsAggreeItem4
		{
			get { return isAggreeItem4; }
			set
			{
				if (isAggreeItem4 != value)
				{
					isAggreeItem4 = value;
					OnPropertyChanged("IsAggreeItem4");
					CalcTotalPrice();
				}
			}
		}

		bool isAggreeItem5 = false;
		public bool IsAggreeItem5
		{
			get { return isAggreeItem5; }
			set
			{
				if (isAggreeItem5 != value)
				{
					isAggreeItem5 = value;
					OnPropertyChanged("IsAggreeItem5");
					CalcTotalPrice();
				}
			}
		}

		bool isAggreeItem6 = false;
		public bool IsAggreeItem6
		{
			get { return isAggreeItem6; }
			set
			{
				if (isAggreeItem6 != value)
				{
					isAggreeItem6 = value;
					OnPropertyChanged("IsAggreeItem6");
					CalcTotalPrice();
				}
			}
		}

		bool isAggreeItem7 = false;
		public bool IsAggreeItem7
		{
			get { return isAggreeItem7; }
			set
			{
				if (isAggreeItem7 != value)
				{
					isAggreeItem7 = value;
					OnPropertyChanged("IsAggreeItem7");
					CalcTotalPrice();
				}
			}
		}

		bool isAggreeItem8 = false;
		public bool IsAggreeItem8
		{
			get { return isAggreeItem8; }
			set
			{
				if (isAggreeItem8 != value)
				{
					isAggreeItem8 = value;
					OnPropertyChanged("IsAggreeItem8");
					CalcTotalPrice();
				}
			}
		}

		bool isAggreeItem9 = false;
		public bool IsAggreeItem9
		{
			get { return isAggreeItem9; }
			set
			{
				if (isAggreeItem9 != value)
				{
					isAggreeItem9 = value;
					OnPropertyChanged("IsAggreeItem9");
					CalcTotalPrice();
				}
			}
		}

		public decimal TotalPrice { get; private set; }

		private void CalcTotalPrice()
		{
			var total = 0;
			if (IsAggreeItem1)
				total += 2000;
			if (IsAggreeItem2)
				total += 4000;
			if (IsAggreeItem3)
				total += 8000;
			if (IsAggreeItem4)
				total += 3000;
			if (IsAggreeItem5)
				total += 1000;
			if (IsAggreeItem6)
				total += 5000;
			if (IsAggreeItem7)
				total += 20000;
			if (IsAggreeItem8)
				total += 30000;
			if (IsAggreeItem9)
				total += 10000;
			TotalPrice = total;
			OnPropertyChanged("TotalPrice");
		}
	}
}
