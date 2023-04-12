using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlanok
{
	class Foldhivatal //Konténer Osztály
	{
		private List<Ingatlan> ingatlanok = new List<Ingatlan>();
		
		public void HozzaadIngatlan(Ingatlan ing)
		{
			/*
			foreach (var item in ingatlanok) 
			{
				if (item.HelyrajziSzam == ing.HelyrajziSzam)
					throw new Exception("A helyrajzi számoknak egyedinek kell lennie!");
			}
			ingatlanok.Add(ing);
			*/

			if(ingatlanok.Contains(ing)) 			
				throw new Exception("A helyrajzi számoknak egyedinek kell lennie!");
			
			ingatlanok.Add(ing);
		}

		public Ingatlan Legdragabb
		{
			get 
			{
				Ingatlan maxAr = null;
				foreach (Ingatlan ing in ingatlanok)
				{		
					if (maxAr == null)
						maxAr = ing;

					if (ing.Ar > maxAr.Ar)
					{
						maxAr = ing;								
					}					
				}
				return maxAr; 
			}
		}

		//átlagos földméret:
		public double AtlagMeret(MuvelesiAg tipus)
		{
			int szaml = 0;
			double sumTerulet = 0;
			double atlag;
			foreach (var ing in ingatlanok)
			{
				if (!(ing is Termofold))
					continue;
				Termofold tf = ing as Termofold;

				if (tipus != MuvelesiAg.erdo) continue;
				
				szaml++;
				sumTerulet += tf.TeruletNagysaga ;
			}
			atlag = sumTerulet / szaml;
			return atlag;
		}

		//Bontandó családiházak címének listája
		public List<string> Bontandok(LakoepuletTipus tipus)
		{
			List<string> cimek = new List<string>();
			
			foreach (var item in ingatlanok)
			{
				if(!(item is Lakoepulet)) continue;
				Lakoepulet ep = item as Lakoepulet;

				if (ep.Tipus != tipus) continue;
				
				if (!ep.BontandoE) continue;
				
				cimek.Add(ep.Cim);
			}
			return cimek;
		}

		 

	}
}
