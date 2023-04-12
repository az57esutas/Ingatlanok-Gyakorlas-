using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlanok
{
	internal class Ingatlan
	{
		#region Mezők + property-k

		private string helyrajziSzam;

		public virtual string HelyrajziSzam //virtualissá kell tenni, hogy overrideolni lehessen!
		{
			get { return helyrajziSzam; }
			protected set
			{
				if (value.Length < 3)
					throw new Exception("Túl rövid a helyrajzi szám!");

				helyrajziSzam = value;
			}
		}

		private int ar;

		public int Ar
		{
			get { return ar; }
			set
			{
				if (value <= 0)
					throw new Exception("Az Ár nem lehet negatív, vagy nulla!");

				if (value % 100000 != 0)
					throw new Exception("Az Ár csak 100000-el osztható lehet!");

				ar = value;
			}
		}

        #endregion

        #region Konstruktorok
		//itt mindenképpen a PROPERTY-nek kell SETTELNI az Értékét!!
        public Ingatlan(string helyrajziSzam, int ar)
        {
			this.HelyrajziSzam = helyrajziSzam;
			this.Ar = ar;			
        }

		//konstruktor hívási lánccal:
        public Ingatlan(string helyrajziSzam): this(helyrajziSzam, 1000000000) //KONSTRUKTORHÍVÁSI LÁNC
        {  
        }

        #endregion

        #region Metódusok

		public virtual void Dragit(int novekmeny) //Override miatt kell virtuálissá tenni
		{
			if (novekmeny <= 0)
				throw new Exception("A növekmény csak pozitív szám lehet");

			Ar += novekmeny;
		}

		public override bool Equals(object obj)
		{
			//paraméterként kapott adat típus egyezésének vizsgálata:
			if (!(obj is Ingatlan))
				throw new Exception("Csak 2 ingatlant hasonlíthatsz össze!");

			//Átkonvertáljuk a technikai objektumot ingatlanba(technikai lépés)
			Ingatlan ing = obj as Ingatlan;

			//a konkrét vizsgálat:
			return this.helyrajziSzam == ing.helyrajziSzam;			
		}


		#endregion
	}
}
