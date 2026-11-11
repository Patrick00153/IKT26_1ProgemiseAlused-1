namespace forloophello
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //teha konsoolirakendus, kus kasutad for loopi
            //kolm korda näidatakse Tere tulemast ja lõpus on reanumer
            //kasutaja ei tohi sisestada midagi

            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine("Tere tulemast " + i);
            }

        }
    }
}
