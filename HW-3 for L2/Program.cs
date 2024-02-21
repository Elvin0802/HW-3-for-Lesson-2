using System;
using System.Net.Sockets;

//-------------------------------------------------------------------------------

int curQuest = 0, score = 0, secim1 = 0;

string[] abc = { "A ) ", "B ) ", "C ) " };

string[,] suallar =
{
	{ "Quba hansi olkenin sheheridir","Turkiye","Qazaxistan","Azerbaycan","Azerbaycan" },
	{ "Manat neche olkede istifade olunur","1","2","3","2" },
	{ "Balina nedir","Heyvan","Qush","Surunen","Heyvan" },
	{ "Az-da max suret nechedir","110","120","90","110" },
	{ "Xezer nedir","Okean","Gol","Deniz","Gol" },
	{ "C# hansi ailedendir",".net",".NET",".Net",".NET" },
	{ "Italiyanin paytaxti haradir","Roma","San-Marino","Vatikan","Roma" },
	{ "Dollarin mezennesi nechedir","1.7","1.8","1.6","1.7" },
	{ "Azercell nedir","Mobil operator","Nomre","Shirket","Mobil operator" },
	{ "Pishiyin neche cani olur","7","9","1","1" },

};
// axrinci duzgun cavabin indexi dir.


int rlen = (suallar.Length) / 5;  //	sulallarin sayi
int clen = (suallar.Length) / rlen;  //	her sualin terkib sayi

while (true)
{
	Console.Clear();

	if (secim1==1) Console.ForegroundColor = ConsoleColor.DarkYellow;
	Console.WriteLine("\n\n\n\t\t\tStart Quiz");
	Console.ForegroundColor = ConsoleColor.White;
	if (secim1==0) Console.ForegroundColor = ConsoleColor.DarkYellow;
	Console.WriteLine("\n\t\t\tExit");
	Console.ForegroundColor = ConsoleColor.White;

	if (KeyCheck(ref secim1, 0, 1))
	{
		if (secim1==0)
		{ Thread.Sleep(800); return; }

		ShuffleArray(suallar,rlen,clen); // Shuffle variants

		int secim2 = 1; curQuest = 0; score = 0;

		while (curQuest<rlen)
		{
			Console.Clear();

			Console.ForegroundColor = ConsoleColor.Blue;
			Console.WriteLine($"\n\n\t\t\tSCORE  ~  {score}");

			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"\n\tSual - {curQuest+1} :  {suallar[curQuest, 0]} ?\n");
			Console.ForegroundColor = ConsoleColor.White;

			for (int i = 1; i < clen-1; i++)
			{
				if (i == secim2)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Write($"\t\t{abc[i-1]}");
					Console.ForegroundColor = ConsoleColor.Cyan;
					Console.WriteLine($"{suallar[curQuest, i]}");
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Gray;
					Console.Write($"\t\t{abc[i-1]}");
					Console.ForegroundColor = ConsoleColor.Yellow;
					Console.WriteLine($"{suallar[curQuest, i]}");
				}
			}

			if (KeyCheck(ref secim2, 1, clen-2))
			{
				if (suallar[curQuest, secim2] == suallar[curQuest, clen-1])
					score+=10;
				else
					score-=10;

				Thread.Sleep(200);
				curQuest++;
				secim2=1;
			}
		}

		if (score < 0) score=0;

		Console.Clear();

		Console.ForegroundColor = ConsoleColor.DarkRed;
		Console.WriteLine($"\n\n\t\t\tQuiz Bitdi.\n\n\t\tSizin Toplam Xaliniz : {score}\n\n"); 
		
		Console.ForegroundColor = ConsoleColor.White;
		Console.WriteLine("Davam etmek uchun enter basin...");

		Console.ReadKey();
	}
}


bool KeyCheck(ref int option, int min, int max)
{
	ConsoleKeyInfo key = Console.ReadKey(true);

	if (key.Key == ConsoleKey.Enter)
	{
		return true;
	}
	else if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W ||
		key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
	{
		option--;
		if (option < min) option = max;
	}
	else if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S ||
		key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
	{
		option++;
		if (option > max) option = min;
	}

	return false;
}

static void ShuffleArray<T>(T[,] arr,int l1,int l2) // Shuffle the my array
{
	Random random = new Random();
	int n = l2-1, rindex;

	for (int k = 0; k<l1; k++)
	{
		for (int i = n - 1; i > 1; i--)
		{
			rindex = random.Next(1, i + 1);

			T temp = arr[k,i];
			arr[k,i] = arr[k, rindex];
			arr[k, rindex] = temp;
		}
	}
}