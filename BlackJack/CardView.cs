using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class CardView
    {
        internal StringBuilder GetCardView(int[] Deck, int count, out int score)
        {
            score = 0;
            int[] deck = Deck;
            string num = null;
            string suit = null;
            StringBuilder CardViewBlank = new StringBuilder();

            void GetCurrentCard(ref int id)//Определяем масть и номер карты
            {
                if (id <= 13)
                {
                    suit = "Spades";
                }
                if (id > 13 && id <= 26)
                {
                    suit = "Clubs";
                    id -= 13;
                }
                if (id > 26 && id <= 39)
                {
                    suit = "Diamonds";
                    id -= 26;
                }
                if (id > 39 && id <= 52)
                {
                    suit = "Hearts";
                    id -= 39;
                }
                switch (id)
                {
                    case 1:
                        {
                            num = "A";
                            break;
                        }
                    case 11:
                        {
                            num = "J";
                            break;
                        }
                    case 12:
                        {
                            num = "Q";
                            break;
                        }
                    case 13:
                        {
                            num = "K";
                            break;
                        }
                    default:
                        {
                            num = id.ToString();
                            break;
                        }
                }

                CardViewBlank.Insert(0, suit + ":" + num + " \n");
            }

            for (int j = 0; j < count; j++)
            {
                int id = deck[j];
                GetCurrentCard(ref id);

                if (id <= 10)
                    score += id;
                else
                    score += (id - 9);
            }


            return CardViewBlank;
        }

    }
}
