using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperApp.Model
{
    public class StanNatury
    {
		public string Nazwa { get; set; }
		public double Prawdopodobienstwo { get; set; }

		public StanNatury()
		{
			Nazwa = "Bez nazwy";
			Prawdopodobienstwo = 0.0;
		}
		public StanNatury(string nazwa, double prawdopodobienstwo)
		{
			Nazwa = nazwa;
			Prawdopodobienstwo = prawdopodobienstwo;
		}
    }
}
