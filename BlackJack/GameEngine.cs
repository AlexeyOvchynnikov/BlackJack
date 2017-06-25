using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class GameEngine
    {
        public static int MAX_NUM_CARDS = 8; //maximum number of cards
        public static int ENEMY_STOP_SCORE = 17; //enemy stops score
        public static int WIN_SCORE = 21;//main score of game
        public static string str = "11";
        public static int A;

        internal Stack<int> GetSuit() //Deck generation
        {
            Stack<int> GeneratedSuit = new Stack<int>();
            Random R = new Random();
            GeneratedSuit.Push(R.Next(1, 52));
            while (true)
            {
                int rand = R.Next(1, 52);
                if (!GeneratedSuit.Contains(rand) && GeneratedSuit.Count != 51)
                    GeneratedSuit.Push(rand);
                if (GeneratedSuit.Count == 51)
                    break;
            }
            return GeneratedSuit;
        }

        internal int ScoreComputing(int[] _deck)
        {
            int id = 0;
            int score = 0;
            for (int i = 0; i < _deck.Length; i++)
            {
                id = _deck[i];
                if (id > 13 && id <= 26)
                {
                    id -= 13;
                }
                if (id > 26 && id <= 39)
                {
                    id -= 26;
                }
                if (id > 39 && id <= 52)
                {
                    id -= 39;
                }
                // Computing player's score  
                if (id <= 10)
                    score += id;
                else
                    score += (id - 9);
            }
            return score;


        }

    }
}
