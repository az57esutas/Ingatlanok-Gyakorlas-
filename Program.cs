using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ingatlanok
{
	internal class Program //Főprogram
	{
		static void Main(string[] args)
		{
			Foldhivatal hivatal = new Foldhivatal();

			#region Fájl-ból beolvasás és példányok létehozása!
			//Beolvasás Fájlból:
			StreamReader fajl = new StreamReader("nyilvantartas.txt");

			while (!fajl.EndOfStream)
			{
				string sor = fajl.ReadLine();
				string[] adatok = sor.Split(';');

				Ingatlan x;
				switch (adatok.Length)
				{
					case 1:
						x = new Ingatlan(adatok[0]);
						break;

					case 2:
						x = new Ingatlan(adatok[0], int.Parse(adatok[1]));
						break;

					case 3:
						x = new Lakoepulet(adatok[0], int.Parse(adatok[1]), adatok[2]);
						break;

					case 4: //TERMŐFÖLD PÉLDÁNY
						x = new Termofold(
							adatok[0],
							int.Parse(adatok[1]),
							(MuvelesiAg)Enum.Parse(typeof(MuvelesiAg), adatok[2]),
							double.Parse(adatok[3]));
						break;

					case 5:
						x = new Lakoepulet(
									adatok[0],
									int.Parse(adatok[1]),
									adatok[2],
									(LakoepuletTipus)Enum.Parse(typeof(LakoepuletTipus), adatok[3]),
									bool.Parse(adatok[4])
									);
						break;

					default:
						throw new Exception(string.Format("Nem lehet értelmezni ezt az inputot: {0}", sor));
				}
				hivatal.HozzaadIngatlan(x);

			}
			fajl.Close(); 
			#endregion

			#region Feladatok:

			//Mi a legdrágább ingatlan helyrajzi száma és ára:
			Console.WriteLine("A legdrágább ingatlan helyrajzi száma: {0}", hivatal.Legdragabb.HelyrajziSzam);
			Console.WriteLine("A legdrágább ingatlan ára: {0} Ft", hivatal.Legdragabb.Ar);

			//Az összes bontandó családi ház címe:
			Console.WriteLine();
			Console.WriteLine("Az összes bontandó családi ház címe:");
			foreach (string cim in hivatal.Bontandok(LakoepuletTipus.csaladi_haz))
				Console.WriteLine(cim);

			//Átlagosan hány hektárosak az erdők:
			Console.WriteLine();
			Console.WriteLine("Átlagosan {0} hektárosak az erdők az adatbázisban.", hivatal.AtlagMeret(MuvelesiAg.erdo));

			#endregion

			Console.ReadKey();
		}
	}
}
