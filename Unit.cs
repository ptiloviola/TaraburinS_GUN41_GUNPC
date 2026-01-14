namespace Classes
{
    public class Unit
    {

        private float _health;
        private float _armour;

        public string Name { get; }

        public float Health => _health;

        public Unit() : this("Unknown Unit")
        {

        }

        public Unit(string name)
        {
            Name = name;
        }

        public float GetRealHealth()
        {
            return Health * (1f + Armour);
        }

        public float Armour
        {
            get
            {
                return (float)Math.Round(_armour, 2);
            }
            set
            {
                if (value >= 0 || value <= 1)
                {
                    _armour = value;
                }
                else
                {
                    Console.WriteLine("Error armour value");
                }
            }
        }
    }
}


