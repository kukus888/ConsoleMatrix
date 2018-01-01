using System;
using System.Threading;

namespace Matrix
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.CursorVisible = false;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.ForegroundColor = ConsoleColor.Green;
			int spaciDoba = 300;
			int vyskaKonzole = Console.LargestWindowHeight;
			int sirkaKonzole = Console.LargestWindowWidth;
			string[,] obrazovka = new string[sirkaKonzole,vyskaKonzole];
			Random rnd = new Random();
			int places = 0;
			int maximumPlaces = 750;
			maximumPlaces = ((obrazovka.GetLength (0) - 1) * (obrazovka.GetLength (1) - 1))-((obrazovka.GetLength (0) - 1) * (obrazovka.GetLength (1) - 1)/2);
			Console.Clear ();
			try{
			while (true) {
				places = 0;
				for (int i = 0; i <= obrazovka.GetLength (0) - 1; i++) {
					for (int a = 0; a <= obrazovka.GetLength (1) - 1; a++) {
						if (obrazovka [i, a] != null) {
							places++;
						}
					}
				}
				if (places >= maximumPlaces) {
					for (int i = 0; i <= obrazovka.GetLength (0) - 1; i++) {
						for (int a = 0; a <= obrazovka.GetLength (1) - 1; a++) {
							obrazovka [i, a] = null;
						}
					}
					Console.Clear ();
				}
				for (int i = 0; i <= obrazovka.GetLength (0) - 1; i++) {
					for (int a = 0; a <= obrazovka.GetLength (1) - 1; a++) {
						if (obrazovka [i, a] != null) {
							obrazovka [i, a] = rnd.Next (0,2).ToString();
						}
					}
				}
				if((vyskaKonzole != Console.LargestWindowHeight) || (sirkaKonzole != Console.LargestWindowWidth)){//RESIZE
					obrazovka = null;
					obrazovka = new string[Console.LargestWindowWidth,Console.LargestWindowHeight];
					vyskaKonzole = Console.LargestWindowHeight;
					sirkaKonzole = Console.LargestWindowWidth;
					maximumPlaces = ((obrazovka.GetLength (0) - 1) * (obrazovka.GetLength (1) - 1))-((obrazovka.GetLength (0) - 1) * (obrazovka.GetLength (1) - 1)/2);
					Console.Clear ();
				}
				int newLine = rnd.Next (0,100);
				if (newLine >= 0 && newLine <= 49) {//50% chance of new line being generated
					while (true) {
						int x = rnd.Next (0, Console.LargestWindowWidth);
						if (obrazovka [x, 0] == null) {
							obrazovka [x, 0] = rnd.Next (0, 2).ToString ();
							break;
						}
					}
				}
				for (int z = 0; z <= obrazovka.GetLength(0)-1; z++) {//for every place
					int evolveChance = rnd.Next (0,100);
					bool obs = false;
					if (obrazovka [z, 0] != null) {
						obs = true;
					}
					if ((evolveChance >= 0 && evolveChance <= 84) && obs == true) {//90% chance to evolve
						for(int m = 0;m<= obrazovka.GetLength(1)-1;m++){
							if (obrazovka [z, m] == null) {
								obrazovka[z,m]=rnd.Next(0,2).ToString();
								break;
							}
						}
					}
				}
				for (int i = 0; i <= obrazovka.GetLength (0) - 1; i++) {
					for (int a = 0; a <= obrazovka.GetLength (1) - 1; a++) {
						Console.SetCursorPosition (i, a);
						Console.Write (obrazovka[i,a]);
					}
				}
				if (Console.KeyAvailable == true) {
					ConsoleKeyInfo vstup = Console.ReadKey ();
					if (vstup.Key == ConsoleKey.Subtract) {
						spaciDoba = spaciDoba - 50;
					}
					if (vstup.Key == ConsoleKey.Add) {
						spaciDoba = spaciDoba + 50;
					}
					if (vstup.Key == ConsoleKey.Escape) {
						break;
					}
				}
				if (spaciDoba <= 0) {
					spaciDoba = 1;
				}
				Thread.Sleep (spaciDoba);
			}
			} catch {
				
			}
		}
	}
}
