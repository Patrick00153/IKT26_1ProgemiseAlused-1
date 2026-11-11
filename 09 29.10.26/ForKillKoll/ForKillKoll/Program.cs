namespace ForKillKoll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //iga kord kui hakkab kordama siis naitab rea numbrit
            Console.Write("Mitu korda soovid väljundit korrata? ");
            int kordi = int.Parse(Console.ReadLine());

            for (int i = 0; i < kordi; i++)
            {
                Console.WriteLine("Kordus nr " + (i + 1));
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine("kill - koll");
                }
                Console.WriteLine("killadi - koll");
            }
        }
    }
}