using CustomTextboxControl.View.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace CustomTextboxControl
{
	public partial class MainWindow : Window
	{
		bool init_list = false;
		static int index_current_ClearableTextBox = 0;
		List<ClearableTextBox> list;

		public MainWindow()=>InitializeComponent();
		

		private void txtInput_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				ClearableTextBox element = (ClearableTextBox)sender;
				foreach (ClearableTextBox item in list)
				{
					if (item == element)
						index_current_ClearableTextBox = list.IndexOf(item);
					break;
				}
				if (index_current_ClearableTextBox >= 0 && index_current_ClearableTextBox < list.Count - 1)
					list[++index_current_ClearableTextBox].txtInput.Focus();

			}
		}


		public static List<ClearableTextBox> FindClearableTextBox(DependencyObject depObj)
		{
			List<ClearableTextBox> result = new List<ClearableTextBox>();
			if (depObj != null)
			{
				Console.WriteLine("==============");
				for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
				{
					var child = VisualTreeHelper.GetChild(depObj, i);
					Console.WriteLine(child.GetType().ToString());
					if (child != null && child is ClearableTextBox)
						result.Add((ClearableTextBox)child);
					result.AddRange(FindClearableTextBox(child));
				}
			}
			return result;
		}

		private void Grid_MouseEnter(object sender, MouseEventArgs e)
		{
			if (!init_list)
			{
				Window mainWin = Application.Current.MainWindow;
				list = FindClearableTextBox(mainWin);
				init_list = true;
			}

		}
	}
}
