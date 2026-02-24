using SocialCasino.SaveLoadService;
using SocialCasino.GameItems;
using SocialCasino.CasinoGame;
using System.Text;

namespace SocialCasino
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.UTF8;

            var savesDir = Path.Combine(AppContext.BaseDirectory, "Saves");
            Console.WriteLine("Saves directory: " + savesDir);
            var saveLoad = new FileSystemSaveLoadService(savesDir);
            var blackjack = new Blackjack();
            var diceGame = new DiceGame(3, 1, 6);

            var casino = new Casino(saveLoad, blackjack, diceGame);
            casino.StartGame();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }
}



