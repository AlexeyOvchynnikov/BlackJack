namespace BlackJack
{
    internal static class GameData
    {   
        // Maximum number of cards.
        public const int MAX_NUM_CARDS = 8;
        // Enemy stops score.
        public const int ENEMY_STOP_SCORE = 17;
        // Main score of game.
        public const int WIN_SCORE = 21;
        // Max number of cards in the deck.
        public const int MAX_NUMBER_OF_CARDS = 52;
        public const int minCardNumID = 1, maxCardNumID = 14, minCardSuitID = 0, maxCardSuitID = 4;
        // Max score of cards.
        public const int maxCardScore = 10;
        public const int viewOnGame = 0;
        public const int viewFinishGame = 1;
        public enum СardNumbers : int { A = 1, J = 11, Q = 12, K = 13 };
        public enum СardSuis : int { Spades, Clubs, Diamonds, Hearts };
    }
}
