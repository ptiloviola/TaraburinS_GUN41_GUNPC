
namespace Game
{
    public struct Interval
    {
        public int Min { get; }
        public int Max { get; }
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
}




