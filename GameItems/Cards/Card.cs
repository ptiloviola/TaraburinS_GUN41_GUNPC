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
    }
}


