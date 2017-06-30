using static BlackJack.GameData;

namespace BlackJack
{
    internal sealed class Card
    {
        private _cardNumbers _number;
        private _cardSuis _suit;
        public readonly int Score;

        public Card(int CardNumberID, int CardSuitID)
        {
            Score = CardNumberID < 10 ? CardNumberID:10;
            _number = (_cardNumbers)CardNumberID;
            _suit = (_cardSuis)CardSuitID;
        }
        
        public override string ToString()
        {
            return _suit + ":" + _number;
        }
    }
}
