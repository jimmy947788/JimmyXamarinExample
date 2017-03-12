using System;
using Xamarin.Forms;
using ListViewDemo.iOS.Renderer;
using Xamarin.Forms.Platform.iOS;
using ListViewDemo.Controls;

[assembly: ExportRenderer(typeof(ViewCell), typeof(MyViewCellRenderer))]
namespace ListViewDemo.iOS.Renderer
{
	public class MyViewCellRenderer : ViewCellRenderer
	{
		public override UIKit.UITableViewCell GetCell(Cell item, UIKit.UITableViewCell reusableCell, UIKit.UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
			if (cell != null)
			{
				cell.SelectionStyle = UIKit.UITableViewCellSelectionStyle.None;
			}
			
            return cell;
        }
	}
}
