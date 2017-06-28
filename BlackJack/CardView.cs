using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal sealed class CardView
    {
        internal StringBuilder GetCardView(Deck Deck)
        {
            Deck deck = Deck;
            StringBuilder CardViewBlank = new StringBuilder();

            foreach (Card c in deck)
            {
                CardViewBlank.Insert(0,c + "\n");
            }
            return CardViewBlank;
        }

        internal void GetPlayersCardsView(out StringBuilder _EnemyCards, out  StringBuilder _PlayerCards, Deck _EnemyDeck, Deck _PlayerDeck)
        {
            _EnemyCards = GetCardView(_EnemyDeck);
            _PlayerCards = GetCardView(_PlayerDeck);
        }
    }
}
