using HelperApp.Model;
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

namespace HelperApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainModel mainModel;



		public MainWindow()
		{
			InitializeComponent();
			mainModel = new MainModel();
			this.DataContext = mainModel;
			mainModel.MOCK();
		}


		//CRUD Decyzji
		private void btn_DodajDecyzje(object sender, RoutedEventArgs e)
		{
			EdycjaDecyzji window = new EdycjaDecyzji(mainModel);

			if(window.ShowDialog() == true)
			{
				mainModel.listaDecyzji.Add(window.GetDecyzja());
			}
		}

		private void btn_EdytujDecyzje(object sender, RoutedEventArgs e)
		{
			if (lb_decyzje.SelectedIndex < 0) return;

			EdycjaDecyzji window = new EdycjaDecyzji(mainModel, lb_decyzje.SelectedIndex);

			if (window.ShowDialog() == true)
			{
				mainModel.listaDecyzji[lb_decyzje.SelectedIndex] = window.GetDecyzja();
			}
		}

		private void btn_UsunDecyzje(object sender, RoutedEventArgs e)
		{
			if (lb_decyzje.SelectedIndex < 0) return;
			mainModel.listaDecyzji.RemoveAt(lb_decyzje.SelectedIndex);
		}


		//CRUD Stanów natury
		private void btn_DodajStan(object sender, RoutedEventArgs e)
		{
			DodajEdytujStan window = new DodajEdytujStan();

			if(window.ShowDialog() == true)
			{
				mainModel.listaStanowNatury.Add(window.getName());
			}
		}

		private void btn_EdytujStan(object sender, RoutedEventArgs e)
		{
			if (lb_stany_natury.SelectedIndex < 0) return;


			DodajEdytujStan window = new DodajEdytujStan(mainModel.listaStanowNatury[lb_stany_natury.SelectedIndex]);
			if (window.ShowDialog() == true)
			{
				mainModel.listaStanowNatury[lb_stany_natury.SelectedIndex] = window.getName();
			}
		}

		private void btn_UsunStan(object sender, RoutedEventArgs e)
		{
			if (lb_stany_natury.SelectedIndex < 0) return;

			mainModel.listaStanowNatury.RemoveAt(lb_stany_natury.SelectedIndex);
		}


		private void przygotujTabelki()
		{
			t_zyski.Children.Clear();
			t_zyski.ColumnDefinitions.Clear();
			t_zyski.RowDefinitions.Clear();

			t_straty.Children.Clear();
			t_straty.ColumnDefinitions.Clear();
			t_straty.RowDefinitions.Clear();

			for (int i = 0; i < mainModel.listaStanowNatury.Count + 1; i++)
			{
				ColumnDefinition col = new ColumnDefinition();
				col.Width = new GridLength(80);
				t_zyski.ColumnDefinitions.Add(col);

				ColumnDefinition col1 = new ColumnDefinition();
				col1.Width = new GridLength(80);
				t_straty.ColumnDefinitions.Add(col1);
			}
			for (int i = 0; i < mainModel.listaDecyzji.Count + 1; i++)
			{
				RowDefinition row = new RowDefinition();
				row.Height = new GridLength(30);
				t_zyski.RowDefinitions.Add(row);

				RowDefinition row1 = new RowDefinition();
				row1.Height = new GridLength(30);
				t_straty.RowDefinitions.Add(row1);
			}
		}

		private void wypełnijZyski(string [,] zyski)
		{
			int c = mainModel.listaStanowNatury.Count;
			int r = mainModel.listaDecyzji.Count;


			for (int i = 0; i < r + 1; i++)
			{
				for (int j = 0; j < c + 1; j++)
				{

					Label label = new Label();
					label.Content = zyski[i, j];

					label.HorizontalContentAlignment = HorizontalAlignment.Center;
					label.VerticalContentAlignment = VerticalAlignment.Center;

					Grid.SetColumn(label, j);
					Grid.SetRow(label, i);
					t_zyski.Children.Add(label);
				}
			}
		}

		private void wypełnijStraty(string[,] straty)
		{
			int c = mainModel.listaStanowNatury.Count;
			int r = mainModel.listaDecyzji.Count;


			for (int i = 0; i < r + 1; i++)
			{
				for (int j = 0; j < c + 1; j++)
				{

					Label label = new Label();
					label.Content = straty[i, j];

					label.HorizontalContentAlignment = HorizontalAlignment.Center;
					label.VerticalContentAlignment = VerticalAlignment.Center;

					Grid.SetColumn(label, j);
					Grid.SetRow(label, i);
					t_straty.Children.Add(label);
				}
			}
		}
		private void Oblicz(object sender, RoutedEventArgs e)
		{
			przygotujTabelki();
			wypełnijZyski(mainModel.getZyski());
			wypełnijStraty(mainModel.getStraty());

			tb_hurowicz.Text = mainModel.hurowicz().NazwaDecyzji;
			tb_laplace.Text = mainModel.laplace(mainModel.listaStanowNatury).NazwaDecyzji;
			tb_savang.Text = mainModel.savaga().NazwaDecyzji;
			tb_wald.Text = mainModel.wald().NazwaDecyzji;
			tb_osm.Text = mainModel.osm().NazwaDecyzji;
			tb_ow.Text = mainModel.ow().NazwaDecyzji;
		}

	}
}
