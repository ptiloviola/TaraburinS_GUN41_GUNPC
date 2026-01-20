
namespace Game
{
    public class Weapon
    {

        public string Name { get; }

        public Interval Damage { get; private set;  }

        public float Durability { get; }


        public Weapon(string name)
        {
            Name = name;
            Durability = 1f;
            Damage = new Interval(0, 0);

        }
        public Weapon(string name, int minDamage, int maxDamage) : this(name)
        {
            SetDamageParams(minDamage, maxDamage);
        }

        public void SetDamageParams(int minDamage, int maxDamage)
        {
            if (minDamage < 1)
            {
                minDamage = 1;
                Console.WriteLine("Incorrect input params for minDamage. MinDamage forced to 1");
            }
            if (maxDamage <= 1)
            {
                maxDamage = 10;
                Console.WriteLine("Incorrect input params for maxDamage. MaxDamage forced to 10");
            }

            if (minDamage > maxDamage)
            {
                Damage = new Interval(maxDamage, minDamage);
                Console.WriteLine("Incorrect input params for {0}. MinDamage was greater than MaxDamage, values have been swapped.", Name);
            }
            else
            {
                Damage = new Interval(minDamage, maxDamage);
            }

        }

        public int GetDamage()
        {
            return (Damage.Min + Damage.Max) / 2;
        }
    }

}
