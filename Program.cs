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

            //var x = "xxx";
            //Console.WriteLine(x);

            //string y = "yyy";

            //var saveLoadService = new FileSystemSaveLoadService("save.txt");
            //saveLoadService.SaveData(y);

            //Console.WriteLine(Directory.GetCurrentDirectory());

            //Console.WriteLine(saveLoadService.LoadData());


            var savesDir = Path.Combine(AppContext.BaseDirectory, "Saves");
            Console.WriteLine("Saves directory: " + savesDir);
            var saveLoad = new FileSystemSaveLoadService(savesDir);

            saveLoad.SaveData("HP=12;Gold=420", "slot2.doc");

            string loaded = saveLoad.LoadData("slot2.doc");
            Console.WriteLine(loaded);

            Console.WriteLine("Saved in: " + savesDir);

            //var dice = new Dice(1, 20);

            //Console.WriteLine("Rolling the dice...");
            //Console.WriteLine("You rolled a " + dice.Number);
            //Console.WriteLine("You rolled a " + dice.Number);
            //Console.WriteLine("You rolled a " + dice.Number);
            //Console.WriteLine("You rolled a " + dice.Number);


            //var bj = new Blackjack();

            //Console.WriteLine(bj);

            //bj.PlayGame();

            var diceGame = new DiceGame(3, 1, 6);
            diceGame.PlayGame();

            //foreach (var card in bj.GetCardList())
            //{
            //    Console.WriteLine(card.ToString());
            //}

            //Console.WriteLine("=======================");

            //foreach (var card in bj.GetCardQueue())
            //{
            //    Console.WriteLine(card.ToString());
            //}

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }
}



