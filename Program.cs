
using Game;

class Program
{
    static void Main(string[] args)
    {

        var unit = new Unit("Vasya");
        //Console.WriteLine(unit.Name);
        //Console.WriteLine(unit.Armor);
        //Console.WriteLine(unit.Damage.Max);
        //Console.WriteLine(unit.Health);
        //Console.WriteLine(unit.GetRealHealth());
        //Console.WriteLine(unit.SetDamage(15));

        //Console.WriteLine("-------------------------");

        var weapon = new Weapon("Sword", -2, 5);
        //Console.WriteLine(weapon.Name);
        //Console.WriteLine(weapon.Damage.Min);
        //Console.WriteLine(weapon.Damage.Max);
        //Console.WriteLine(weapon.GetDamage());

        //Console.WriteLine("-------------------------");


        var interval = new Interval(-4, -3);
        Console.WriteLine("Min = {0}", interval.Min);
        Console.WriteLine("Max = {0}", interval.Max);
        Console.WriteLine("get = {0}", interval.Get());

        Console.WriteLine("-------------------------");

        var room = new Room(unit, weapon);

        Console.WriteLine("Room has unit: {0} with health {1}", room.Unit.Name, room.Unit.Health);
        Console.WriteLine("Room has weapon: {0} with damage range {1}-{2}", room.Weapon.Name, room.Weapon.Damage.Min, room.Weapon.Damage.Max);

        Console.WriteLine("-------------------------");

        //var unit1 = new Unit("Petya", 0, -8);
        //var weapon1 = new Weapon("Axe", 3, 15);
        //var room1 = new Room(unit1, weapon1);
        //var room2 = new Room(new Unit("Mizu", 5, 8), new Weapon("Wakizashi", 15, 6));

        //Room[] rooms = new Room[] { room, new Room(new Unit("Brrrr"), new Weapon("Ughrrrrrr")), room1, room2, new Room(new Unit("Satori Hanzo", 6, 6), new Weapon("Katana", 9, 23)) };

        //var dungeon = new Dungeon(rooms);
        //dungeon.ShowRooms();

        var dungeon = new Dungeon();
        dungeon.ShowRooms();



        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static int ReadIntValue()
    {
        if (!Int32.TryParse(Console.ReadLine(), out var value))
        {
            Console.WriteLine("Not a number!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        return value;
    }


}