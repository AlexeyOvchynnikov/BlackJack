namespace BlackJack
{
    internal static class GameData
    {
        public const int MAX_NUM_CARDS = 8; //maximum number of cards
        public const int ENEMY_STOP_SCORE = 17; //enemy stops score
        public const int WIN_SCORE = 21;//main score of game
        public const int MAX_NUMBER_OF_CARDS = 52;//max number of cards in the deck
        public const int minCardNumID = 1, maxCardNumID = 14, minCardSuitID = 0, maxCardSuitID = 4;
        public  enum _cardNumbers : int { A = 1, J = 11, Q=12, K=13 };
        public  enum _cardSuis : int { Spades, Clubs, Diamonds, Hearts };
    }
}
