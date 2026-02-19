using SocialCasino.SaveLoadService;

namespace SocialCasino
{
    internal class Program
    {
        static void Main(string[] args)
        {
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

            saveLoad.SaveData("HP=12;Gold=420", "slot2.txt");

            string loaded = saveLoad.LoadData("slot2.txt");
            Console.WriteLine(loaded);

            Console.WriteLine("Saved in: " + savesDir);



            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }
}



