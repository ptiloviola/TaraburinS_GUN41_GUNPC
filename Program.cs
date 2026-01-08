using System.Globalization;
using System.Runtime.Serialization.Formatters;
using System.Text;


class Program
{
    static void Main(string[] args)
    {

        // Task #1

        Console.WriteLine("Task #1");

        int[] arrayFib = new int[10];
        for (int i = 0; i < arrayFib.Length; i++)
        {
            if (i < 2)
            {
                arrayFib[i] = i;
            }
            else
            {
                arrayFib[i] = arrayFib[i - 1] + arrayFib[i - 2];
            }
            Console.WriteLine(arrayFib[i]);
        }


        // Task #2

        Console.WriteLine("Task #2");

        for (int i = 2; i <= 20; i+=2)
        {
            Console.WriteLine(i);
        }

        // Task #3

        Console.WriteLine("Task #3");

        for (int i = 1; i <= 5; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                Console.WriteLine("{0} * {1} = {2}", i, j, i * j);
            }
        }

        // Task #4

        Console.WriteLine("Task #4");

        string password = "qwerty";
        string input = "";

        Console.WriteLine("Enter password");

        do
        {
            if (input != "")
            {
                Console.WriteLine("Incorrect password. Try again!");
            }
            input = Console.ReadLine();
        } while (password != input);

        Console.WriteLine("Correct password!");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

    }
}