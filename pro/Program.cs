using System.ComponentModel.Design;

namespace Multiplicationtable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Korrutustabel");

            int j, i, n;

            Console.WriteLine("sisesta tabelisse number mis on viimane korrutis");
            n = int.Parse(Console.ReadLine());
            //kaks for loopi ja uks teise sees
            //peab kasutama if and else
            if (n < 1 )
            {
                Console.WriteLine("number peab olema vahemalt 1");
            }
            else
            {
                Console.WriteLine("korrutustabel ühest kuni " + n);
                Console.WriteLine();
                for (j = 1; j <= 10; j++)
                {
                    for (i = 1; i <= n; i++)
                    {
                        Console.Write(i + "x" + j + " = " + i * j + ", ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}