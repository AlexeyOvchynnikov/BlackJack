using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Card
    {
        public const int minCardNumID = 0, maxCardNumID = 13, minCardSuitID = 13, maxCardSuitID = 17;
        private int HashCode;
        private string _Number;
        private string _Suit;
        private string[] NumberAndSuit = new string[17] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "Spades", "Clubs", "Diamonds", "Hearts" };
        public readonly int Score;

        public Card(int CardNumberID, int CardSuitID)
        {
            Score = CardNumberID + 1;
            _Number = NumberAndSuit[CardNumberID];
            _Suit = NumberAndSuit[CardSuitID];
            HashCode = (CardNumberID + 1) * 10000 + CardSuitID;
        }
        public override bool Equals(object obj)
        {

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(this, null) || ReferenceEquals(obj, null))
            {
                return false;
            }

            return GetHashCode() == ((Card)obj).GetHashCode();
        }

        public override int GetHashCode()
        {
            return HashCode;
        }

        public override string ToString()
        {
            return _Suit + ":" + _Number;
        }
    }
}
