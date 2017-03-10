using System;
namespace ScrollViewDemo.Controls
{
	public class HMenuItemSelectdEventArgs : EventArgs
	{
		public HMenuItemSelectdEventArgs(string text, string value)
		{
			this.text = text;
			this.value = value;
		}

		string text;
		public string Text
		{
			get { return this.text; }
		}

		string value;
		public string Value
		{
			get { return this.value; }
		}
	}
}
