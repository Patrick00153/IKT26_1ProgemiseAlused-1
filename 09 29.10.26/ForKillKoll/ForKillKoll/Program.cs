namespace ArvamisMang
{
    internal class Program
    {
        static Random juhuslik = new Random();

        static int mangitud = 0;
        static int voidud = 0;
        static int koguPunktid = 0;
        static int parimTulemus = 0;
        static int voiduSeeria = 0;
        static int parimSeeria = 0;

        static void Main(string[] args)
        {
            Console.Write("Mis su nimi on? ");
            string nimi = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nimi))
            {
                nimi = "Mängija";
            }

            bool tootab = true;
            while (tootab)
            {
                Console.Clear();
                Pealkiri("ARVAMISMÄNG");
                Console.WriteLine("Tere, " + nimi + "!");
                Console.WriteLine();
                Console.WriteLine("1. Mängi");
                Console.WriteLine("2. Statistika");
                Console.WriteLine("3. Reeglid");
                Console.WriteLine("4. Välju");
                Console.WriteLine();

                int valik = KysiArv("Vali: ", 1, 4);

                switch (valik)
                {
                    case 1: Mang(); break;
                    case 2: NaitaStatistika(); break;
                    case 3: NaitaReeglid(); break;
                    case 4: tootab = false; break;
                }
            }

            Console.WriteLine("Aitäh mängimast, " + nimi + "! Punkte kokku: " + koguPunktid);
        }

        static void Mang()
        {
            Console.Clear();
            Pealkiri("VALI KEERUKUS");
            Console.WriteLine("1. Lihtne   (arv 1-20,  6 katset, punktid x1)");
            Console.WriteLine("2. Keskmine (arv 1-50,  7 katset, punktid x2)");
            Console.WriteLine("3. Raske    (arv 1-100, 7 katset, punktid x3)");
            Console.WriteLine();

            int tase = KysiArv("Vali: ", 1, 3);

            int max = 20;
            int katseid = 6;
            int kordaja = 1;
            if (tase == 2)
            {
                max = 50;
                katseid = 7;
                kordaja = 2;
            }
            else if (tase == 3)
            {
                max = 100;
                katseid = 7;
                kordaja = 3;
            }

            int arv = juhuslik.Next(1, max + 1);
            int eelmineVahe = -1;
            int kasutatud = 0;
            bool arvatud = false;

            Console.Clear();
            Pealkiri("MÄNG ALGAB");
            Console.WriteLine("Mõtlesin arvu 1 kuni " + max + ". Sul on " + katseid + " katset.");
            Console.WriteLine();

            for (int i = 1; i <= katseid; i++)
            {
                kasutatud = i;
                int pakkumine = KysiArv("Katse " + i + "/" + katseid + ": ", 1, max);

                if (pakkumine == arv)
                {
                    arvatud = true;
                    break;
                }

                int vahe = Math.Abs(pakkumine - arv);

                if (vahe <= max / 20 + 1)
                {
                    Joonda("KUUM! Oled väga lähedal.", ConsoleColor.Red);
                }
                else if (vahe <= max / 8 + 1)
                {
                    Joonda("Soe. Päris lähedal.", ConsoleColor.Yellow);
                }
                else
                {
                    Joonda("Külm. Oled kaugel.", ConsoleColor.Cyan);
                }

                if (eelmineVahe != -1)
                {
                    if (vahe < eelmineVahe)
                    {
                        Console.WriteLine("Lähenesid eelmisest pakkumisest.");
                    }
                    else if (vahe > eelmineVahe)
                    {
                        Console.WriteLine("Kaugenesid eelmisest pakkumisest.");
                    }
                    else
                    {
                        Console.WriteLine("Sama kaugel kui eelmine kord.");
                    }
                }
                eelmineVahe = vahe;

                if (pakkumine < arv)
                {
                    Console.WriteLine("Mõtlen suuremat arvu.");
                }
                else
                {
                    Console.WriteLine("Mõtlen väiksemat arvu.");
                }

                if (i == 3 && i < katseid)
                {
                    if (arv % 2 == 0)
                    {
                        Joonda("VIHJE: arv on paaris.", ConsoleColor.Magenta);
                    }
                    else
                    {
                        Joonda("VIHJE: arv on paaritu.", ConsoleColor.Magenta);
                    }
                }

                Console.WriteLine();
            }

            mangitud++;
            Console.WriteLine();

            if (arvatud)
            {
                voidud++;
                voiduSeeria++;
                if (voiduSeeria > parimSeeria)
                {
                    parimSeeria = voiduSeeria;
                }

                int punktid = (katseid - kasutatud + 1) * 100 * kordaja;
                int bonus = (voiduSeeria - 1) * 50;
                int kokku = punktid + bonus;

                koguPunktid += kokku;
                if (kokku > parimTulemus)
                {
                    parimTulemus = kokku;
                }

                if (kasutatud == 1)
                {
                    Joonda("ESIMESE KATSEGA! Oled nõid!", ConsoleColor.Green);
                }
                else
                {
                    Joonda("ÕIGE! Arvasid ära " + kasutatud + ". katsega.", ConsoleColor.Green);
                }

                Console.WriteLine("Punktid: " + punktid + " + seeria bonus " + bonus + " = " + kokku);
                Console.WriteLine("Võitude seeria: " + voiduSeeria);
            }
            else
            {
                voiduSeeria = 0;
                Joonda("KAOTASID! Õige arv oli " + arv + ".", ConsoleColor.Red);
                Console.WriteLine("Võitude seeria nullitud.");
            }

            Ootan();
        }

        static void NaitaStatistika()
        {
            Console.Clear();
            Pealkiri("STATISTIKA");

            int protsent = 0;
            if (mangitud > 0)
            {
                protsent = voidud * 100 / mangitud;
            }

            Console.WriteLine("Mänge mängitud:   " + mangitud);
            Console.WriteLine("Võite:            " + voidud + " (" + protsent + "%)");
            Console.WriteLine("Punkte kokku:     " + koguPunktid);
            Console.WriteLine("Parim mäng:       " + parimTulemus + " punkti");
            Console.WriteLine("Pikim võiduseeria: " + parimSeeria);

            Ootan();
        }

        static void NaitaReeglid()
        {
            Console.Clear();
            Pealkiri("REEGLID");
            Console.WriteLine("1. Arvuti mõtleb arvu, sina arvad.");
            Console.WriteLine("2. Iga vale pakkumise järel saad vihje: kuum, soe või külm.");
            Console.WriteLine("3. Vähem katseid = rohkem punkte.");
            Console.WriteLine("4. Raskem tase annab rohkem punkte.");
            Console.WriteLine("5. Järjest võidud annavad lisapunkte (seeria bonus).");
            Console.WriteLine("6. Kolmanda katse järel saad vihje, kas arv on paaris või paaritu.");

            Ootan();
        }

        static int KysiArv(string kusimus, int min, int max)
        {
            while (true)
            {
                Console.Write(kusimus);
                string sisend = Console.ReadLine();

                if (int.TryParse(sisend, out int arv) && arv >= min && arv <= max)
                {
                    return arv;
                }

                Joonda("Sisesta täisarv vahemikus " + min + " kuni " + max + ".", ConsoleColor.Red);
            }
        }

        static void Pealkiri(string tekst)
        {
            Joonda("=== " + tekst + " ===", ConsoleColor.Yellow);
            Console.WriteLine();
        }

        static void Joonda(string tekst, ConsoleColor varv)
        {
            Console.ForegroundColor = varv;
            Console.WriteLine(tekst);
            Console.ResetColor();
        }

        static void Ootan()
        {
            Console.WriteLine();
            Console.Write("Vajuta Enter, et jätkata...");
            Console.ReadLine();
        }
    }
}