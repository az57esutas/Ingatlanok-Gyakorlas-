using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlanok
{
	class Termofold: Ingatlan
	{
		#region Property-k

		public override string HelyrajziSzam 
		{
			protected set
			{
				if (!value.StartsWith("0"))
				{
					value = "0" + value;
					//throw new Exception("Termőföld hsz-nak 0-val kell kezdődnie!");
				}
				base.HelyrajziSzam = value;
			}
		}

		private MuvelesiAg tipus;

		public MuvelesiAg Tipus
		{
			get
			{
				return tipus;
			}
		}

		private double teruletNagysaga;

		public double TeruletNagysaga
		{
			get
			{
				return teruletNagysaga;
			}

			set
			{
				if (!(value >= 0))
					throw new Exception("Nem lehet negatív, vagy nulla!");

				teruletNagysaga = value;
			}
		}

		#endregion

		#region Konstruktor

		public Termofold(string helyrajziszam, int ar, MuvelesiAg tipus, double teruletNagysaga) : base(helyrajziszam, ar)
		{
			this.tipus = tipus;
			this.teruletNagysaga = teruletNagysaga;
		}

		#endregion

		#region Metódus

		public override void Dragit(int novekmeny)
		{
			base.Dragit((int)(teruletNagysaga * novekmeny));
		}

		//public void Dragit(int novekmeny,int ar, double teruletNagysaga)
		//{
		//	if (novekmeny <= 0)
		//		throw new Exception("A növekmény csak pozitív szám lehet");

		//	double hektaronkentiAr = ar / teruletNagysaga;
		//	hektaronkentiAr += novekmeny;
		//	//Ar = int.Parse(hektaronkentiAr);
		//}

		#endregion

	}
}
