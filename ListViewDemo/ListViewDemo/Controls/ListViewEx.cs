using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListViewDemo.Controls
{
	public class ListViewExLoadMoreEventArgs : EventArgs
	{
		public ListViewExLoadMoreEventArgs(int currentIndex, int pageSize)
		{
			this.currentIndex = currentIndex;
			this.pageSize = pageSize;
		}

		int currentIndex;
		public int CurrentIndex { 
			get { return currentIndex; } 
		}

		int pageSize;
		public int PageSize { 
			get { return pageSize; }
		}

	}
	public class ListViewEx : ListView
	{
		public ListViewEx(ListViewCachingStrategy strategy) : 
			base(strategy)
		{
			this.ItemAppearing += ListViewEx_ItemAppearing;
		}

		void ListViewEx_ItemAppearing(object sender, ItemVisibilityEventArgs e)
		{
			var items = ItemsSource as IList;

			if (items != null && e.Item == items[items.Count - 1])
			{
				if (LoadMore != null)
				{
					var currentIndex = items.Count / PageSize;
					LoadMore(this, new ListViewExLoadMoreEventArgs(currentIndex, PageSize));
				}
			}
		}

		public event EventHandler<ListViewExLoadMoreEventArgs> LoadMore;
		public int PageSize { get; set; }
	}
}
