namespace loop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //teha for loopiga lõputu tsükkel
            //mis prindib konsooli: i väärtus on number

            //kui i väärtus on 10, siis stükkel lõpeb
            //for loopi tingimusi peab olema tühjaks jäetud, et see oleks lõputu 
            short i = 1;
            for (; ; i++)
            {
                Console.WriteLine("i väärtus on " + i);

                if (i == 10)
                {
                    break;
                }
            }
        }
    }
}
            
        
    

        
    

