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
	/// Interaction logic for DodajEdytujStan.xaml
	/// </summary>
	public partial class DodajEdytujStan : Window
	{
		StanNatury sn;
		public DodajEdytujStan()
		{
			InitializeComponent();
		}

		public DodajEdytujStan(StanNatury stanNatury)
		{
			InitializeComponent();
			sn = new StanNatury();
			sn.Nazwa= stanNatury.Nazwa;
			sn.Prawdopodobienstwo = stanNatury.Prawdopodobienstwo;

			tb_nazwaStanu.Text = sn.Nazwa;
			tb_prawdopodobienstwo.Text = sn.Prawdopodobienstwo.ToString();
		}

		private void Zapisz(object sender, RoutedEventArgs e)
		{
			sn.Nazwa = tb_nazwaStanu.Text;
			sn.Prawdopodobienstwo = Double.Parse(tb_prawdopodobienstwo.Text);
			this.DialogResult = true;
		}

		private void Anuluj(object sender, RoutedEventArgs e)
		{
			this.DialogResult = false;
		}
		public StanNatury getName()
		{
			return sn;
		}
	}
}
