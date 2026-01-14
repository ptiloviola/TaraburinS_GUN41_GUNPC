using Classes;

class Program
{
    static void Main(string[] args)
    {

        var unit = new Unit();
        Console.WriteLine(unit.Name);
        unit.Armour = 15;
        Console.WriteLine(unit.Armour);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();

    }
}