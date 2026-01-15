namespace Classes
{
    public class Unit
    {

        private float _health = 100f;
        private float _armor;
        private int _damage;

        public string Name { get; }

        public float Health => _health;

        public int Damage { get; }

        public float Armor { get; }

        public Unit() : this("Unknown Unit")
        {
        }

        public Unit(string name)
        {
            Name = name;
            Armor = 0.6f;
            Damage = 5;
        }

        public float GetRealHealth()
        {
            return Health * (1f + Armor);
        }
        public bool SetDamage(float value)
        {
            _health -= value * Armor;
            Console.WriteLine($"Unit {Name} got {value * Armor} damage, current health: {_health}");
            if (_health <= 0f)
            {
                Console.WriteLine($"Unit {Name} is dead.");
                return true;
            } else
            {
                Console.WriteLine($"Unit {Name} is still alive.");
                return false;
            }
        }
    }
}


