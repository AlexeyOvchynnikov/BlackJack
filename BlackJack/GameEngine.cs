using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class GameEngine
    {
        private int max_num_cards = 8; //maximum number of cards
        private int enemy_stop_score = 17; //enemy stops score
        private int win_score = 21;//main score of game

        public int MAX_NUM_CARDS
        {
            get { return max_num_cards; }
        }
        public int ENEMY_STOP_SCORE
        {
            get { return enemy_stop_score; }
        }
        public int WIN_SCORE
        {
            get { return win_score; }
        }


        
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
