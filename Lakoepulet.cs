using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlanok
{
	class Lakoepulet: Ingatlan	
	{
		#region Property-k
		private string cim;

		public string Cim
		{
			get { return cim; }
			set
			{
				if (value == null)
					throw new Exception("A cím nem lehet null!"); 

				if (value == "")
					throw new Exception("A cím nem lehet üres!");

				cim = value;
			}
		}

		private LakoepuletTipus tipus;

		public LakoepuletTipus Tipus
		{
			get
			{
				return tipus;
			}
		}

		private bool bontandoE;

		public bool BontandoE
		{
			get { return bontandoE; }
			set
			{
				if (bontandoE && !value)
					throw new Exception("Bontandót maradjon bontandó!");

				bontandoE = value;
			}
		}
		#endregion
		
		#region Konstruktorok
		public Lakoepulet(string helyrajziSzam, int ar, string cim, LakoepuletTipus tipus, bool bontandoE) : base(helyrajziSzam, ar) //base kulcsszó hivatkozik a szülő osztály konstruktorára
		{
			this.Cim = cim;
			this.tipus = tipus;
			this.BontandoE = bontandoE;
		}

        public Lakoepulet(string helyrajziSzam, int ar, string cim): this(helyrajziSzam, ar, cim, LakoepuletTipus.csaladi_haz, false)
        {      
        }
        #endregion
		
    }
}
