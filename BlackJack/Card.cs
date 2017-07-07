using static BlackJack.GameData;

namespace BlackJack
{
    internal sealed class Card
    {
        private СardNumbers _number;
        private СardSuis _suit;
        public readonly int Score;

        public Card(int cardNumberID, int cardSuitID, int score)
        {
            Score = score;
            _number = (СardNumbers)cardNumberID;
            _suit = (СardSuis)cardSuitID;
        }
        
        public override string ToString()
        {
            return _suit + ":" + _number;
        }
    }
}
