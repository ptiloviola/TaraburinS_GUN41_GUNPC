using GamePrototype.Game;

namespace GamePrototype
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new GameLoop().StartGame();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}



