using SocialCasino.CasinoGame;
using SocialCasino.GameItems;
using SocialCasino.GameItems.Cards;

namespace SocialCasino.CasinoGame
{
    public class Blackjack : CasinoGameBase
    {
        private Queue<Card> _deck = new();

        private List<Card> _cardList = new();

        private readonly Random _random = new();

        private List<Card> _playerHand = new();
        private List<Card> _compHand = new();



        public override void PlayGame()
        {
            Console.WriteLine("Starting game...");
            FactoryMethod();
            Shuffle();

            int roundNumber = 0;
            int cardCount = 2;

            while (true)
            {
                roundNumber++;
                Console.WriteLine($"Round {roundNumber}");

                if (roundNumber > 1)
                {
                    cardCount = 1;
                }

                ReceiveCards(_playerHand, cardCount, "player");
                ReceiveCards(_compHand, cardCount, "comp");

                int playerScores = CalculateScores(_playerHand);
                Console.WriteLine($"player has scores: {playerScores}");
                int compScores = CalculateScores(_compHand);
                Console.WriteLine($"comp has scores: {compScores}");

                if (playerScores == compScores && playerScores < 21)
                {
                    continue;
                }
                else if (playerScores <= 21 && (compScores > 21 || compScores < playerScores))
                {
                    OnWinInvoke();
                    break;
                }
                else if (compScores <= 21 && (playerScores > 21 || playerScores < compScores))
                {
                    OnLooseInvoke();
                    break;
                }
                else
                {
                    OnDrawInvoke();
                    break;
                }
            }

        }

        protected override void FactoryMethod()
        {
            foreach (CardSuit suit in Enum.GetValues<CardSuit>())
            {
                foreach (CardValue value in Enum.GetValues<CardValue>())
                {
                    _cardList.Add(new Card(suit, value));
                }
            }
        }

        private void Shuffle()
        {
            Console.WriteLine("Deck creation...");
            List<Card> cardListCopy = new List<Card> (_cardList);
            for (int i = cardListCopy.Count - 1; i > 0; i--)
            {
                int j = _random.Next(i + 1);
                (cardListCopy[i], cardListCopy[j]) = (cardListCopy[j], cardListCopy[i]);
            }
            foreach (var card in cardListCopy)
            {
                _deck.Enqueue(card);
            }
        }

        private void ReceiveCards(List<Card> hand, int count, string player)
        {
            for (int i = 0; i < count; i++)
            {
                if (!_deck.TryDequeue(out var card))
                {
                    throw new InvalidOperationException("Deck is empty");
                }
                hand.Add(card);
                Console.WriteLine($"The {player} receives the following card: {card}");
            }
        }

        private int CalculateScores(List<Card> hand)
        {
            int total = 0;
            int aces = 0;
            foreach (var card in hand)
            {
                total += GetBlackjackPoints(card.Value);
                if (card.Value == CardValue.Ace)
                {
                    aces++;
                }
                while (total > 21 && aces > 0)
                {
                    total -= 10;
                    aces --;
                    Console.WriteLine("Ace turns into 1");
                }
            }
            return total;
        }

        private static int GetBlackjackPoints(CardValue value)
        {
            return value switch
            {
                CardValue.Jack or CardValue.Queen or CardValue.King => 10,
                CardValue.Ace => 11,
                _ => (int)value // Six..Ten = 6..10
            };
        }

        public Queue<Card> GetCardQueue()
        {
            return _deck;
        }

        public List<Card> GetCardList()
        {
            return _cardList;
        }





        public Blackjack()
        {

        }
    }
}




