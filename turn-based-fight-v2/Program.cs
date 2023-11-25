namespace turn_based_fight_v2;

class Program
{
    static void Main(string[] args)
    {
        // {ATK,DEF,HP} Max ATK is 100, Max DEF is 50 and Max HP is 400
        // DEF means that if you get hit damage will be absorbed as your DEF point.

        //int[,] stats = new int[4, 3];

        double[,] stats =
        
            {
                 { 60, 50, 350, 0.15 },
                 { 100, 30, 300, 0.35 },
                 { 60, 40, 400, 0.2 },
                 { 100, 35, 325, 0.3 }
            }
        ;



        //int[] Tank = { 60, 50, 350 };
        //int[] ADC = { 100, 30, 300 };
        //int[] Support = { 60, 40, 400 };
        //int[] APC = { 100, 35, 325 };

        
        double oyuncuATK = 0;
        double oyuncuDEF = 0;
        double oyuncuHP = 0;
        double oyuncuCrit = 0;
        string oyuncuKarakter = "";

        Random rnd = new Random();
        int npcSecim = rnd.Next(1, 5);
       
        double npcATK = 0;
        double npcDEF = 0;
        double npcHP = 0;
        double npcCrit = 0;
        string npcKarakter = "";

        // For turn-based games, we need a turn counter. Max turn number must up to be 10-100. If you can't calculate the turn number, give 100.

        int turn = 20;

        Console.WriteLine("----Character Selection----\n\n1. Braum (Tank)\nStats:\nHP: 350 \nATK: 60\nDEF: 50\n\n2. Vayne (ADC)\nStats:\nHP: 300 \nATK: 100\nDEF: 30\n\n3. Bard (Support)\nStats:\nHP: 400 \nATK: 60\nDEF: 40\n\n4. Amumu (APC)\nStats:\nHP: 325 \nATK: 100\nDEF: 35\n\n");
        Console.WriteLine("Select your champion!");

        int karakterSecim = int.Parse(Console.ReadLine());

        Random random = new Random();
        int baslangic = random.Next(1, 3);
        Console.WriteLine("Who's gonna first? Pick 1 or 2. This choice will be your fate!");
        int baslangicSecim = int.Parse(Console.ReadLine());

        while (karakterSecim == npcSecim)
        {
            npcSecim = rnd.Next(1, 5);
        }

        switch (karakterSecim)
        {
            case 1:
                oyuncuKarakter = "Braum";
                Console.WriteLine($"You picked {oyuncuKarakter}");
                oyuncuHP = stats[0,2];
                oyuncuATK = stats[0, 0];
                oyuncuDEF = stats[0, 1];
                oyuncuCrit = stats[0,3];
                break;
            case 2:
                oyuncuKarakter = "Vayne";
                Console.WriteLine($"You picked {oyuncuKarakter}");
                oyuncuHP = stats[1, 2];
                oyuncuATK = stats[1, 0];
                oyuncuDEF = stats[1, 1];
                oyuncuCrit = stats[1, 3];
                break;
            case 3:
                oyuncuKarakter = "Bard";
                Console.WriteLine($"You picked {oyuncuKarakter}");
                oyuncuHP = stats[2, 2];
                oyuncuATK = stats[2, 0];
                oyuncuDEF = stats[2, 1];
                oyuncuCrit = stats[2, 3];
                break;
            case 4:
                oyuncuKarakter = "Amumu";
                Console.WriteLine($"You picked {oyuncuKarakter}");
                oyuncuHP = stats[3, 2];
                oyuncuATK = stats[3, 0];
                oyuncuDEF = stats[3, 1];
                oyuncuCrit = stats[3, 3];
                break;


        }

        switch (npcSecim)
        {
            case 1:
                npcKarakter = "Braum";
                Console.WriteLine($"NPC picked {npcKarakter}");
                npcHP = stats[0, 2];
                npcATK = stats[0, 0];
                npcDEF = stats[0, 1];
                npcCrit = stats[0, 3];
                break;
            case 2:
                npcKarakter = "Vayne";
                Console.WriteLine($"NPC picked {npcKarakter}");
                npcHP = stats[1, 2];
                npcATK = stats[1, 0];
                npcDEF = stats[1, 1];
                npcCrit = stats[1, 3];
                break;
            case 3:
                npcKarakter = "Bard";
                Console.WriteLine($"NPC picked {npcKarakter}");
                npcHP = stats[2, 2];
                npcATK = stats[2, 0];
                npcDEF = stats[2, 1];
                npcCrit = stats[2, 3];
                break;
            case 4:
                npcKarakter = "Amumu";
                Console.WriteLine($"NPC picked {npcKarakter}");
                npcHP = stats[3, 2];
                npcATK = stats[3, 0];
                npcDEF = stats[3, 1];
                npcCrit = stats[3, 3];
                break;
        }

        if (baslangic == baslangicSecim)
        {

            while (oyuncuHP > 0 && npcHP > 0)
            {

                for (int tur = 1; tur <= turn; tur++)
                {
                    Console.WriteLine("For the next round press Enter");
                    Console.ReadLine();
                    if (oyuncuHP > 0 && npcHP > 0)
                    {
                        //npcHP = npcHP + npcDEF - oyuncuATK;

                        npcHP = DovusMekanik(oyuncuATK, npcHP, npcDEF,oyuncuCrit);

                        if (npcHP <= 0)
                        {
                            Console.WriteLine("\n----Game Over----");
                            Console.WriteLine($"You hit {oyuncuATK}! {npcKarakter}'s health is 0");
                            Console.WriteLine("You win!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"\n------Round {tur}------");
                            Console.WriteLine($"You hit {oyuncuATK}! {npcKarakter}'s health is {npcHP}. Hit harder!");
                        }

                    }
                    if (npcHP > 0 && oyuncuHP > 0)
                    {
                        //oyuncuHP = oyuncuHP + oyuncuDEF - npcATK;

                       oyuncuHP= DovusMekanik(npcATK, oyuncuHP, oyuncuDEF,npcCrit);

                        if (oyuncuHP <= 0)
                        {
                            Console.WriteLine("\n----Game Over----");
                            Console.WriteLine($"Aww! {npcKarakter} hit {npcATK}! Your health is 0");
                            Console.WriteLine("You died!");
                            break;
                        }
                        else
                        {

                            Console.WriteLine($"Aww! {npcKarakter} hit {npcATK}! Your health is {oyuncuHP}. Take a breath!");
                        }
                    }

                }
            }
        }
        else
        {
            while (oyuncuHP > 0 && npcHP > 0)
            {

                for (int tur = 1; tur <= turn; tur++)
                {
                    Console.WriteLine("For the next round press Enter");
                    Console.ReadLine();

                    if (npcHP > 0 && oyuncuHP > 0)
                    {
                        //oyuncuHP = oyuncuHP + oyuncuDEF - npcATK;

                        oyuncuHP = DovusMekanik(npcATK, oyuncuHP, oyuncuDEF,npcCrit);

                        if (oyuncuHP <= 0)
                        {
                            Console.WriteLine("\n----Game Over----");
                            Console.WriteLine($"Aww! {npcKarakter} hit {npcATK}! Your health is 0");
                            Console.WriteLine("You died!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"\n------Round {tur}------");
                            Console.WriteLine($"Aww! {npcKarakter} hit {npcATK}! Your health is {oyuncuHP}. Take a breath!");
                        }
                    }

                    if (oyuncuHP > 0 && npcHP > 0)
                    {
                        //npcHP = npcHP + npcDEF - oyuncuATK;

                       npcHP = DovusMekanik(oyuncuATK, npcHP, npcDEF,oyuncuCrit);

                        if (npcHP <= 0)
                        {
                            Console.WriteLine("\n----Game Over----");
                            Console.WriteLine($"You hit {oyuncuATK}! {npcKarakter}'s health is 0");
                            Console.WriteLine("You win!");
                            break;
                        }
                        else
                        {

                            Console.WriteLine($"You hit {oyuncuATK}! {npcKarakter}'s health is {npcHP}");
                        }

                    }

                }
            }
        }

         

    }
    public static double DovusMekanik(double atk, double hp, double def, double kritikDMG)
    {
        Random rnd1 = new Random();

        double kritikOran = rnd1.NextDouble();

        if (kritikDMG > kritikOran && hp > 0)
        {
            hp = hp + def - atk - (atk * kritikDMG);
            Console.WriteLine($"{atk*kritikDMG} Crit DMG! ");
        }else
            hp = hp + def - atk;



        return hp;
          
    }
}

