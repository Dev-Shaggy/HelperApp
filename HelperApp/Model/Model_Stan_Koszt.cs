using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperApp.Model
{
	public class Model_Stan_Koszt
	{
		public string Stan { get; set; }
		public double Koszt { get; set; }

		public Model_Stan_Koszt(string s)
		{
			Stan = s;
			Koszt = 0.0;
		}
	}
}
