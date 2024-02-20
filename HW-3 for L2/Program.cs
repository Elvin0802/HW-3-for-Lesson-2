using Microsoft.VisualBasic.FileIO;


Console.WriteLine("1-st line\n");

int curQuest = 0, score = 0, secim1 = 0;

string[] suallar =
{
    "1","2","3","4","5","6","7","8","9","10"
};
string[,] cavablar=
{
    {"1","2","3" },
    { "1","2","3"},
    { "1","2","3"},
    { "1","2","3"},
    { "1","2","3"},
    { "1","2","3"},
    {"1","2","3" },
    { "1","2","3"},
    {"1","2","3" },
    { "1","2","3"}
};

string[] duzgunCavablar =
{
    "1","2","3","4","5","6","7","8","9","10"
};

int slen = suallar.Length;//sulallarin sayi
int clen = cavablar.Length;// cavablarin sayi
int sclen = (int)(clen/slen);// her sualin cavab sayi

while (true)
{
    Console.Clear();

    if (secim1==1) Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("\n\n\n\t\t\tStart Quiz\n");
    Console.ForegroundColor = ConsoleColor.White;
    if (secim1==0) Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("\n\n\n\t\t\tExit\n");
    Console.ForegroundColor = ConsoleColor.White;

    if (KeyCheck(ref secim1, 0, 1))
    {
        if (secim1==0) { return; }

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"Sual - {curQuest} :  {suallar[curQuest]} ?");
        Console.ForegroundColor = ConsoleColor.White;

        int secim2 = 0;

        while (true)
        {
            Console.Clear();

            for (int i = 0; i < sclen; i++)
            {
                if (i == secim2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\t\t{cavablar[curQuest,secim2]}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\t\t{cavablar[curQuest, secim2]}");
                }

            }

            if (KeyCheck(ref secim2, 0, 2))
            {
                if(cavablar[curQuest, secim2]== duzgunCavablar[curQuest])
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Sual - {curQuest} :  {suallar[curQuest]} ?");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1000);
                }

            }
        }
    }
}


bool KeyCheck(ref int option, int min, int max)
{
    ConsoleKeyInfo key = Console.ReadKey(true);

    if (key.Key == ConsoleKey.Enter)
    {
        return true;
    }
    else if (key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
    {
        option--;
        if (option < min) option = max;
    }
    else if (key.Key == ConsoleKey.DownArrow || key.Key == ConsoleKey.S)
    {
        option++;
        if (option > max) option = min;
    }
    else if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
    {
        option--;
        if (option < min) option = max;
    }
    else if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
    {
        option++;
        if (option > max) option = min;
    }

    return false;
}