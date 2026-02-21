using SocialCasino.GameItems.Cards;
namespace SocialCasino.GameItems.Cards
{
    public struct Card
    {
        public readonly CardSuit Suit;
        public readonly CardValue Value;
        public Card(CardSuit cardSuit, CardValue cardValue)
        {
            Suit = cardSuit;
            Value = cardValue;  
        }

        private static string GetSuitSymbol(CardSuit suit) => suit switch
        {
            CardSuit.Hearts => "♥",
            CardSuit.Diamonds => "♦",
            CardSuit.Clubs => "♣",
            CardSuit.Spades => "♠",
            _ => "?"
        };

        private static string GetValueSymbol(CardValue value) => value switch
        {
            CardValue.Six => "6",
            CardValue.Seven => "7",
            CardValue.Eight => "8",
            CardValue.Nine => "9",
            CardValue.Ten => "10",
            CardValue.Jack => "J",
            CardValue.Queen => "Q",
            CardValue.King => "K",
            CardValue.Ace => "A",
            _ => "?"
        };

        public override string ToString()
        {
            return $"{GetValueSymbol(Value)}{GetSuitSymbol(Suit)}";
        }
    }
}


