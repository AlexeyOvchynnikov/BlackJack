using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    internal sealed class Deck
    {
        private List<Card> _deck;

        public Deck() //Deck generation
        {
            _deck = new List<Card>();
            for (int i = GameData.minCardSuitID; i < GameData.maxCardSuitID; i++)
            {
                for (int j = GameData.minCardNumID; j < GameData.maxCardNumID; j++)
                {
                    _deck.Add(new Card(j, i, j < 10 ? j : 10));
                }
            }
            MixDeck(_deck);
        }
        
        private void MixDeck(List<Card> deck)
        {

            Random rand = new Random();
            int n = deck.Count;
            while (n > GameData.minCardNumID)
            {
                n--;
                int k = rand.Next(n + 1);
                Card card = deck[k];
                deck[k] = deck[n];
                deck[n] = card;
            }
        }

        public Card Pop()
        {
            Card c = _deck.First();
            _deck.Remove(c);
            return c;
        }
    }
}
