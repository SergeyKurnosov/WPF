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

namespace Grid
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			System.Windows.Controls.Grid grid = GetGrid();
			this.Content = grid;

			this.Icon = new BitmapImage(new Uri("D:/ProjectHW/WPF/Grid/imgs/r_kompyuternaya-akademiya-step-11986691-pd1beb2fn4_1664886698.ico"));
		}


		public System.Windows.Controls.Grid GetGrid()
		{
			System.Windows.Controls.Grid resultGrid = new System.Windows.Controls.Grid();

            resultGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            resultGrid.RowDefinitions.Add(new RowDefinition());
            resultGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(25) });

            Rectangle top = new Rectangle();
            top.Fill = System.Windows.Media.Brushes.DarkBlue;
			System.Windows.Controls.Grid.SetRow(top, 0);
			resultGrid.Children.Add(top);

			System.Windows.Controls.Grid inner = new System.Windows.Controls.Grid();
			System.Windows.Controls.Grid.SetRow(inner,1);
			inner.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
			inner.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.6, GridUnitType.Star) });
			inner.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });

			Rectangle left = new Rectangle();
			left.Fill = System.Windows.Media.Brushes.Green;
			System.Windows.Controls.Grid.SetColumn(left, 0);
			inner.Children.Add(left);

			Rectangle middle = new Rectangle();
			middle.Fill = System.Windows.Media.Brushes.LightGray;
			System.Windows.Controls.Grid.SetColumn(left, 1);
			inner.Children.Add(middle);

			Rectangle right = new Rectangle();
			right.Fill = System.Windows.Media.Brushes.Gray;
			System.Windows.Controls.Grid.SetColumn(left, 2);
			inner.Children.Add(right);

			resultGrid.Children.Add(inner);


			return resultGrid;
		}

	}


}

/*
         <Grid.RowDefinitions>
            <RowDefinition Height="50"/>
            <RowDefinition />
            <RowDefinition  Height="25"/>
        </Grid.RowDefinitions>
        <Grid Grid.Row="1">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="100"/>
                <ColumnDefinition Width=".6*"/>
                <ColumnDefinition Width=".2*"/>
            </Grid.ColumnDefinitions>
            <Rectangle Fill="Green"/>
            <Rectangle Grid.Column="1" Fill="LightGray"/>
            <Rectangle Grid.Column="2" Fill="Gray"/>
        </Grid>
        <Rectangle Grid.Row="0" Fill="DarkBlue"/>
 */
