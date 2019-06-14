using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace HelperApp.Model
{
	public class MainModel
	{
		public ObservableCollection<StanNatury> listaStanowNatury { get; set; }
		public ObservableCollection<Decyzja> listaDecyzji { get; set; }

		private double[,] tabela_strat,tabela_zyskow;

		public MainModel()
		{
			listaDecyzji = new ObservableCollection<Decyzja>();
			listaStanowNatury = new ObservableCollection<StanNatury>();
		}
		public double[,] getTabelaZ()
		{
			return tabela_zyskow;
		}
		public double[,] getTabelaS()
		{
			return tabela_strat;
		}
		public void MOCK()
		{
			listaStanowNatury.Add(new StanNatury("200",0.1));
			listaStanowNatury.Add(new StanNatury("300", 0.1));
			listaStanowNatury.Add(new StanNatury("400", 0.6));
			listaStanowNatury.Add(new StanNatury("500", 0.2));

			

			Decyzja d1= new Decyzja(listaStanowNatury);
			d1.NazwaDecyzji = "200 koszulek";
			d1.KosztDecyzji = 2000;
			d1.WartoscDecyzji[0].Koszt = 2400;
			d1.WartoscDecyzji[1].Koszt = 2400;
			d1.WartoscDecyzji[2].Koszt = 2400;
			d1.WartoscDecyzji[3].Koszt = 2400;

			listaDecyzji.Add(d1);
			Decyzja d2 = new Decyzja(listaStanowNatury);

			d2.NazwaDecyzji = "400 koszulek";
			d2.KosztDecyzji = 3600;
			d2.WartoscDecyzji[0].Koszt = 3600;
			d2.WartoscDecyzji[1].Koszt = 4200;
			d2.WartoscDecyzji[2].Koszt = 4800;
			d2.WartoscDecyzji[3].Koszt = 4800;

			listaDecyzji.Add(d2);

			Decyzja d3 = new Decyzja(listaStanowNatury);

			d3.NazwaDecyzji = "600 koszulek";
			d3.KosztDecyzji = 5100;
			d3.WartoscDecyzji[0].Koszt = 4800;
			d3.WartoscDecyzji[1].Koszt = 5400;
			d3.WartoscDecyzji[2].Koszt = 6000;
			d3.WartoscDecyzji[3].Koszt = 6600;

			listaDecyzji.Add(d3);
		}

		public string[,] getZyski()
		{
			int c = listaStanowNatury.Count;
			int r = listaDecyzji.Count;

			string[,] zyski = new string[r + 1, c + 1];
			tabela_zyskow = new double[r,c];

			zyski[0, 0] = "Zamówienie";
			for (int i = 0; i < c; i++)
			{
				zyski[0, i + 1] = listaStanowNatury[i].Nazwa;
			}
			for (int i = 0; i < r; i++)
			{
				zyski[i + 1, 0] = listaDecyzji[i].NazwaDecyzji;
			}

			for (int i = 0; i < r; i++)
			{
				for (int j = 0; j < c; j++)
				{
					double val = listaDecyzji[i].WartoscDecyzji[j].Koszt - listaDecyzji[i].KosztDecyzji; //w razie czego usunąć koszt decyzji
					zyski[i + 1, j + 1] = val.ToString();
					tabela_zyskow[i, j] = val;
				}
			}
			return zyski;
		}
		public string[,] getStraty()
		{
			int c = listaStanowNatury.Count;
			int r = listaDecyzji.Count;

			string[,] straty = new string[r + 1, c + 1];
			tabela_strat = new double[r, c];

			straty[0, 0] = "Zamówienie";
			for (int i = 0; i < c; i++)
			{
				straty[0, i + 1] = listaStanowNatury[i].Nazwa;
			}
			for (int i = 0; i < r; i++)
			{
				straty[i + 1, 0] = listaDecyzji[i].NazwaDecyzji;
			}
			

			for(int i = 0; i < c; i++)
			{
				double max = 0, val = 0;

				for(int j = 0; j < r; j++)
				{
					val = listaDecyzji[j].WartoscDecyzji[i].Koszt - listaDecyzji[j].KosztDecyzji;
					if(max<= val)
					{
						max = val;
					}
				}
				for (int j = 0; j < r; j++)
				{
					val = listaDecyzji[j].WartoscDecyzji[i].Koszt - listaDecyzji[j].KosztDecyzji;
					straty[j + 1, i + 1] = (val - max).ToString();
					tabela_strat[j, i] = val - max;
				}

			}


			return straty;
		}


		//kryteria wyboru
		public Decyzja hurowicz()
		{
			double max = 0;
			Decyzja tmp = null;

			
			for(int i = 0; i < listaDecyzji.Count; i++)
			{
				if(max <= listaDecyzji[i].getMax())
				{
					max = listaDecyzji[i].getMax();
					tmp = listaDecyzji[i];
				}
			}

			return tmp;
		}

		public Decyzja wald()
		{
			Decyzja tmp=null;

			double max = listaDecyzji[0].getMin();
			for(int i = 0; i < listaDecyzji.Count; i++)
			{
				if(max <= listaDecyzji[i].getMin())
				{
					max = listaDecyzji[i].getMin();
					tmp = listaDecyzji[i];
				}
			}
			return tmp;
		}

		public Decyzja savaga()
		{
			Decyzja tmp = null;

			double min = tabela_strat[0,0];

			int minid = 0;

			for(int i = 0; i < listaDecyzji.Count; i++)
			{
				for(int j = 0;j<listaStanowNatury.Count; j++)
				{
					if (min >= tabela_strat[i, j])
					{
						min = tabela_strat[i, j];
						minid = i;
					}
				}
			}
			tmp = listaDecyzji[minid];

			return tmp;
		}

		public Decyzja laplace(ObservableCollection<StanNatury> sn)
		{
			double max = 0;
			Decyzja tmp = null;


			for (int i = 0; i < listaDecyzji.Count; i++)
			{
				if (max <= listaDecyzji[i].getMaxWithP(sn))
				{
					max = listaDecyzji[i].getMaxWithP(sn);
					tmp = listaDecyzji[i];
				}
			}

			return tmp;
		}

		public Decyzja ow()
		{
			double max = 0;
			Decyzja tmp = null;



			for (int i = 0; i < listaDecyzji.Count; i++)
			{
				if (max <= listaDecyzji[i].getMax())
				{
					max = listaDecyzji[i].getMax();
					tmp = listaDecyzji[i];
				}
			}

			return tmp;
		}

		public Decyzja osm()
		{
			Decyzja tmp = null;

			double min = tabela_strat[0, 0];

			int minid = 0;

			for (int i = 0; i < listaDecyzji.Count; i++)
			{
				for (int j = 0; j < listaStanowNatury.Count; j++)
				{
					if (min >= tabela_strat[i, j])
					{
						min = tabela_strat[i, j];
						minid = i;
					}
				}
			}
			tmp = listaDecyzji[minid];

			return tmp;
		}


		public double getMax(Decyzja d, int id)
		{
			double max = 0.0;

			for(int i = 0; i < listaStanowNatury.Count; i++)
			{
				if (max < listaDecyzji[id].WartoscDecyzji[i].Koszt - listaDecyzji[id].KosztDecyzji)
					max = listaDecyzji[id].WartoscDecyzji[i].Koszt - listaDecyzji[id].KosztDecyzji;
			}

			return max;
		}
	}
}
