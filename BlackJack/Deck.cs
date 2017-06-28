using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    internal sealed class Deck : IEnumerable
    {
        public const int MAX_NUMBER_OF_CARDS = 52;//max number of cards in the deck
        private Stack<Card> _deck;

        public Deck() //Deck generation
        {
            _deck = new Stack<Card>();
        }

        public void DeckGeneration()
        {
            HashSet<Card> tempDeck = new HashSet<Card>();
            HashSet<int> mixCardsID = new HashSet<int>();
            for (int i = Card.minCardSuitID; i < Card.maxCardSuitID; i++)
            {
                for (int j = Card.minCardNumID; j < Card.maxCardNumID; j++)
                {
                    tempDeck.Add(new Card(j, i));
                }
            }

            Random rand = new Random();
            while (mixCardsID.Count < MAX_NUMBER_OF_CARDS)
            {
                mixCardsID.Add(rand.Next(MAX_NUMBER_OF_CARDS));
            }

            foreach (int i in mixCardsID)
            {
                _deck.Push(tempDeck.ElementAt(i));
            }
        }

        public void Push(Card item)
        {
            _deck.Push(item);
        }
        public Card Pop()
        {
            return _deck.Pop();
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)_deck).GetEnumerator();
        }
    }
}
