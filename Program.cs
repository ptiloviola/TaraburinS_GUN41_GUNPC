
using System.Text;

class Program
{

    // task #1
    public static string ConcatenateStrings(string str1, string str2)
    {
        return str1 + str2;
    }

    // task #2
    public static string GreetUser(string name, int age)
    {
        return $"Hello, {name}! \nYou are {age} years old.";
    }

    // task #3
    public static string StringInfo(string input)
    {
        return $"This string has {input.Length} characters.\n{input.ToUpper()}\n{input.ToLower()}";
    }

    // task #4
    public static string FistFiveChars(string input)
    {
        if (input.Length < 5)
        {
            return input;
        }
        return input.Substring(0, 5);
    }

    // task #5
    public static StringBuilder StringFromArray(string[] array)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var str in array)
        {
            sb.Append(str + " ");
        }
        return sb;
    }

    // task #6
    public static string ReplaceWords(string inputString, string wordToReplace, string replacementWord)
    {
        return inputString.Replace(wordToReplace, replacementWord);
    }

    static void Main(string[] args)
    {

        Console.WriteLine("Task #1");
        string result1 = ConcatenateStrings("Hello, ", "World!");
        Console.WriteLine(result1);

        Console.WriteLine("Task #2");   
        Console.WriteLine(GreetUser("Alice", 30));

        Console.WriteLine("Task #3");   
        Console.WriteLine(StringInfo("Hello C#"));

        Console.WriteLine("Task #4");
        Console.WriteLine(FistFiveChars("Programming"));
        Console.WriteLine(FistFiveChars("Pro"));

        Console.WriteLine("Task #5");
        string[] words = { "This", "is", "a", "test." };
        Console.WriteLine(StringFromArray(words));

        Console.WriteLine("Task #6");
        string originalString = "The quick brown fox jumps over the lazy dog.";
        string modifiedString = ReplaceWords(originalString, "fox", "cat");
        Console.WriteLine(modifiedString);
        string modifiedString1 = ReplaceWords(modifiedString, "lazy", "sleeping");
        Console.WriteLine(modifiedString1);
        string test2 = "bad bad not good. bad bad not good";
        string modifiedString2 = ReplaceWords(test2, "bad", "good");
        Console.WriteLine(modifiedString2);


        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }


}