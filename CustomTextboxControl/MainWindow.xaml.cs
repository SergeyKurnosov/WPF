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
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		static int index_current_ClearableTextBox = 0;

		public MainWindow()
		{
			InitializeComponent();
	//		Window mainWin = Application.Current.MainWindow;
	//		List<ClearableTextBox> list = FindClearableTextBox(mainWin, element);
		}

		private void txtInput_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				ClearableTextBox element = (ClearableTextBox)sender;
				Window mainWin = Application.Current.MainWindow;
				List<ClearableTextBox> list = FindClearableTextBox(mainWin, element);

				if (index_current_ClearableTextBox >= 0 && index_current_ClearableTextBox < list.Count-1)
					list[index_current_ClearableTextBox+1].txtInput.Focus();

			}
		}


		public static List<ClearableTextBox> FindClearableTextBox(DependencyObject depObj, ClearableTextBox current_element)
		{
			List<ClearableTextBox> result = new List<ClearableTextBox>();
			if (depObj != null)
			{
				for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
				{

					var child = VisualTreeHelper.GetChild(depObj, i);
					Console.WriteLine(child.GetType().ToString());
					if (child != null && child is ClearableTextBox)
					{
						result.Add((ClearableTextBox)child);
						if ((ClearableTextBox)child == current_element)
							index_current_ClearableTextBox = result.Count() - 1;
					}
					result.AddRange(FindClearableTextBox(child, current_element));
				}
			}
			return result;
		}
	}
}
