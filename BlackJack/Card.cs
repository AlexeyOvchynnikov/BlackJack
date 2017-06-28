using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal sealed class Card
    {
        public const int minCardNumID = 1, maxCardNumID = 14, minCardSuitID = 0, maxCardSuitID = 4;
        private int _hashCode;
        private _cardNumbers _number;
        private _cardSuis _suit;
        private enum _cardNumbers : int { A = 1, J = 11, Q, K }
        private enum _cardSuis : int { Spades, Clubs, Diamonds, Hearts }
        public readonly int Score;

        public Card(int CardNumberID, int CardSuitID)
        {
            Score = CardNumberID + 1;
            _number = (_cardNumbers)CardNumberID;
            _suit = (_cardSuis)CardSuitID;
            _hashCode = (CardNumberID + 1) * 10000 + CardSuitID;
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
            return _hashCode;
        }

        public override string ToString()
        {
            return _suit + ":" + _number;
        }
    }
}
