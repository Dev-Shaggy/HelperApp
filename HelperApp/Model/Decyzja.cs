using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace HelperApp.Model
{
	public class Decyzja
	{
		public string NazwaDecyzji { get; set; }
		public double KosztDecyzji { get; set; }
		public ObservableCollection<Model_Stan_Koszt> WartoscDecyzji { get; set; }

		public Decyzja()
		{
			NazwaDecyzji = "Bez nazwy";
			KosztDecyzji = 0.0;
			WartoscDecyzji = new ObservableCollection<Model_Stan_Koszt>();
		}
		public Decyzja(ObservableCollection<StanNatury> lista)
		{
			NazwaDecyzji = "Bez nazwy";
			KosztDecyzji = 0.0;
			WartoscDecyzji = new ObservableCollection<Model_Stan_Koszt>();
			foreach(StanNatury s in lista)
			{
				WartoscDecyzji.Add(new Model_Stan_Koszt(s.Nazwa));
			}
		}
		public double getMaxWithP(ObservableCollection<StanNatury> sn)
		{
			double max = 0;

			for (int i = 0; i < WartoscDecyzji.Count; i++)
			{
				double val = (WartoscDecyzji[i].Koszt - KosztDecyzji) * sn[i].Prawdopodobienstwo;
				if (max <= val)
				{
					max = val;
				}
			}
			return max;
		}

		public double getMax()
		{
			double max = 0;

			for(int i = 0; i < WartoscDecyzji.Count; i++)
			{
				double val = WartoscDecyzji[i].Koszt - KosztDecyzji;
				if(max <= val)
				{
					max = val;
				}
			}
			return max;
		}

		public double getMin()
		{
			double min = WartoscDecyzji[0].Koszt;

			for (int i = 0; i < WartoscDecyzji.Count; i++)
			{
				double val = WartoscDecyzji[i].Koszt - KosztDecyzji;
				if (min >= val)
				{
					min = val;
				}
			}
			return min;
		}

	}
}
