namespace forasterisk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Sisesta ridade arv: ");
            int read = int.Parse(Console.ReadLine());

            for (int i = 1; i <= read; i++)
            {
                Console.WriteLine("*");
            }
        }
    }
}