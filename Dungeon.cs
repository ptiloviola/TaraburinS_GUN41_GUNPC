
namespace Game
{
    public class Dungeon
    {
        private Room[] Rooms;

        public void ShowRooms()
        {
            for (int i = 0; i < Rooms.Length; i++)
            {
                Console.WriteLine("Room {0}: Unit = {1}, Weapon = {2}", i + 1, Rooms[i].Unit.Name, Rooms[i].Weapon.Name);
                Console.WriteLine("        Unit Health = {0}. Unit Damage = {1}-{2}. Unit Armor = {3}.", Rooms[i].Unit.Health, Rooms[i].Unit.Damage.Min, Rooms[i].Unit.Damage.Max, Rooms[i].Unit.Armor);
                Console.WriteLine("        Weapon Damage = {0}-{1}. Weapon Durability = {2}.", Rooms[i].Weapon.Damage.Min, Rooms[i].Weapon.Damage.Max, Rooms[i].Weapon.Durability);
            }
        }


        //public Dungeon(Room[] rooms)
        //{
        //    Rooms = rooms;
        //}

        public Dungeon()
        {
            Rooms = new Room[]
            {
                new Room( new Unit("Goblin", 2, 5), new Weapon("Dagger", 2, 4) ),
                new Room( new Unit("Orc", 10, 5), new Weapon("Axe", 8, 4) ),
                new Room( new Unit("Troll", -3, -1), new Weapon("Club", -5, -5) ),
                new Room( new Unit("Mizu", 5, 8), new Weapon("Wakizashi", 15, 6) ),
                new Room( new Unit("Satori Hanzo", 6, 6), new Weapon("Katana", 9, 23) )
            };
        }
    }

    public struct Interval
    {
        public int Min;
        public int Max;
        private Random random = new Random();

        public int Get()
        {
            return random.Next(Min, Max);
        }

        public Interval(int minValue, int maxValue)
        {
            if (minValue < 0)
            {
                minValue = 0;
            }
            if (maxValue < 0)
            {
                maxValue = 0;
            }
            if (minValue == maxValue)
            {
                maxValue += 10;
                Console.WriteLine("Min and Max values cannot be equal. Setting Max value to Min + 10");
            }

            if (minValue > maxValue)
            {
                (Min, Max) = (maxValue, minValue);
                Console.WriteLine("Min value cannot be greater than Max value. Swapping the values.");
            }
            else
            {
                (Min, Max) = (minValue, maxValue);
            }
        }
    }

    public struct Room
    {
        public Unit Unit;
        public Weapon Weapon;
        public Room(Unit unit, Weapon weapon)
        {
            Unit = unit;
            Weapon = weapon;
        }

    }
}




