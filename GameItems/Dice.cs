namespace SocialCasino.GameItems
{
    public struct Dice
    {

        private int _min;

        private int _max;

        private static readonly Random _random = new Random();

        public int Number { get
            {
                return _random.Next(_min, _max + 1);
            }
        }

        public Dice(int min, int max)
        {
            if (min < 1 || min > max || max > int.MaxValue)
            {
                throw new WrongDiceNumberException($"Invalid dice range: min={min}, max={max}. Min must be at least 1, max must be greater than or equal to min, and max must not exceed {int.MaxValue}.");
            }
            _min = min;
            _max = max;
        }
    }
}


