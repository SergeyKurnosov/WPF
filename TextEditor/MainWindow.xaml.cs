using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace TextEditor
{
	public partial class MainWindow : Window
	{
		string path_current_file = "";
		public MainWindow()
		{
			InitializeComponent();
		}

		private void MenuItem_Click_Create(object sender, RoutedEventArgs e)
		{
			if (!string.IsNullOrEmpty(field_text.Text))
			{
				SaveFileDialog dialog = new SaveFileDialog();
				dialog.Filter = "Text Files (*.txt)|*.txt";
				dialog.ShowDialog();
				if ((!string.IsNullOrWhiteSpace(dialog.FileName)))
				{
					string filename = dialog.FileName;
					System.IO.File.WriteAllText(filename, field_text.Text);
				}
			}
		}

		private void MenuItem_Click_Open(object sender, RoutedEventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "Text Files (*.txt)|*.txt";
			dialog.ShowDialog();
			if ((!string.IsNullOrWhiteSpace(dialog.FileName)))
			{
				this.path_current_file = dialog.FileName;
				string fileContent = File.ReadAllText(dialog.FileName);
				field_text.Text = fileContent;
				save_.IsEnabled = true;
			}
		}

		private void MenuItem_Click_Save(object sender, RoutedEventArgs e)
		{
			if (!string.IsNullOrEmpty(field_text.Text))
			{
				try
				{
					File.WriteAllText(path_current_file, field_text.Text);
					MessageBox.Show("File saved successfully!");
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
				}
			}
		}

		private void field_text_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Tab)
			{
				e.Handled = true;
				int selectionStart = field_text.SelectionStart;
				field_text.Text = field_text.Text.Insert(selectionStart, "\t");
				field_text.SelectionStart = selectionStart + 1;
			}
		}

		private void field_text_MouseWheel(object sender, MouseWheelEventArgs e)
		{
			if (field_text.FontSize > 1)
			{
			e.Handled = true;
			if (e.Delta > 0)
				field_text.FontSize += 1;
			else
				field_text.FontSize -= 1;
			}
		}
	}
}

