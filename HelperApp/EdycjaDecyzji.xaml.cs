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
using System.Windows.Shapes;

namespace HelperApp
{
	/// <summary>
	/// Interaction logic for EdycjaDecyzji.xaml
	/// </summary>
	public partial class EdycjaDecyzji : Window
	{
		private Decyzja decyzja;


		public EdycjaDecyzji(MainModel model)
		{
			InitializeComponent();
			decyzja = new Decyzja(model.listaStanowNatury);
			this.DataContext = decyzja;
		}
		public EdycjaDecyzji(MainModel model, int id)
		{
			InitializeComponent();
			decyzja = model.listaDecyzji[id];
			this.DataContext = decyzja;
		}

		private void Zapisz(object sender, RoutedEventArgs e)
		{
			this.DialogResult = true;
		}

		private void Anuluj(object sender, RoutedEventArgs e)
		{
			this.DialogResult = false;
		}

		public Decyzja GetDecyzja()
		{
			return decyzja;
		}
	}
}
