using SocialCasino.CasinoGame;
using SocialCasino.GameItems;

namespace SocialCasino.CasinoGame
{
    public class DiceGame : CasinoGameBase
    {
        private readonly int _diceCount;
        private readonly int _minValue;
        private readonly int _maxValue;

        private readonly List<Dice> _diceListPlayer = new();
        private readonly List<Dice> _diceListComp = new();



        public DiceGame(int diceCount, int minValue, int maxValue)
        {
            _diceCount = diceCount;
            _minValue = minValue;
            _maxValue = maxValue;
        }

        protected override void FactoryMethod()
        {
            for (int i = 0; i < _diceCount; i++)
            {
                _diceListPlayer.Add(new Dice(_minValue, _maxValue));
                _diceListComp.Add(new Dice(_minValue, _maxValue));
            }
        }

        public override void PlayGame()
        {
            Console.WriteLine("Starting game...");
            FactoryMethod();
            int playerTotal = 0;
            int compTotal = 0;

            Console.WriteLine("Player rolls:");
            playerTotal = RollAndCalculateTotal(_diceListPlayer);

            Console.WriteLine($"Total player scores: {playerTotal}");

            Console.WriteLine("Computer rolls:");
            compTotal = RollAndCalculateTotal(_diceListComp);
            Console.WriteLine($"Total comp scores: {compTotal}");

            if (playerTotal > compTotal)
            {
                OnWinInvoke();
            }
            else if (compTotal > playerTotal)
            {
                OnLooseInvoke();
            }
            else
            {
                OnDrawInvoke();
            }
        }

        private int RollAndCalculateTotal(List<Dice> diceList)
        {
            int total = 0;
            foreach (var dice in diceList)
            {
                int number = dice.Number;
                if (_minValue == 1 && _maxValue == 6)
                {
                    Console.WriteLine(DiceToEmoji(number));
                }
                else
                {
                    Console.WriteLine(number);
                }
                total += number;
            }
            return total;
        }

        private static string DiceToEmoji(int value)
        {
            return value switch
            {
                1 => "⚀",
                2 => "⚁",
                3 => "⚂",
                4 => "⚃",
                5 => "⚄",
                6 => "⚅",
                _ => value.ToString()
            };
        }
    }


}


