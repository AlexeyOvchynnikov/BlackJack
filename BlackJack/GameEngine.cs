using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class GameEngine
    {
        private const int MAX_NUM_CARDS = 8; //maximum number of cards
        private const int ENEMY_STOP_SCORE = 17; //enemy stops score
        private const int WIN_SCORE = 21;//main score of game
        private const int MAX_NUMBER_OF_CARDS = 52;//max number of cards in the deck
        private CardView View;
        private Output Out = new Output();
        private StringBuilder _PlayerCards, _EnemyCards;
        private int _PlayerScore, _EnemyScore, _PlayerWins = 0, _EnemyWins = 0;
        private Stack<Card> _PlayerDeck;
        private Stack<Card> _EnemyDeck;
        private Stack<Card> Deck;

        public GameEngine()
        {
            View = new CardView();
        }

        internal void NewGame()
        {
            GameInitialization();
            GetPlayersCardsView();
            Out.LoadView(_EnemyCards, _PlayerCards, _EnemyScore, _PlayerScore, _PlayerWins, _EnemyWins, 0);
            Game();
            Console.Clear();
            ShowWinner();
        }

        private void GameInitialization() //new game initialization
        {
            _PlayerScore = 0;
            _EnemyScore = 0;
            _PlayerDeck = new Stack<Card>();
            _EnemyDeck = new Stack<Card>();
            Deck = GetDeck();
        }

        private void Game()//response to a choice
        {
            while (_PlayerScore < WIN_SCORE && _EnemyScore < WIN_SCORE)
            {
                string key = Console.ReadKey().Key.ToString();

                if (key == ConsoleKey.Spacebar.ToString())
                {
                    Console.Clear();
                    _PlayerDeck.Push(Deck.Pop());
                    _PlayerScore = ScoreComputing(_PlayerDeck);
                    if (_EnemyScore < ENEMY_STOP_SCORE)
                    {
                        EnemyCardChoice();
                    }
                    GetPlayersCardsView();
                    Out.LoadView(_EnemyCards, _PlayerCards, _EnemyScore, _PlayerScore, _PlayerWins, _EnemyWins, 0);

                }
                if (key == ConsoleKey.Escape.ToString())
                {
                    Environment.Exit(0);
                }
                if (key == ConsoleKey.Enter.ToString())
                {
                    Console.Clear();
                    while (_EnemyScore < ENEMY_STOP_SCORE)
                    {
                        EnemyCardChoice();
                    }
                    ShowWinner();
                }
            }
        }
        private void GetPlayersCardsView()
        {
            View.GetPlayersCardsView(out _EnemyCards, out _PlayerCards, _EnemyDeck, _PlayerDeck);
        }

        private Stack<Card> GetDeck() //Deck generation
        {
            Stack<Card> GeneratedDeck = new Stack<Card>();
            Random randCardNumber = new Random();
            Random randCardSuit = new Random(DateTime.Now.Millisecond);
            Card newCard = null;
            int CardCounter = 0;
            while (CardCounter < MAX_NUMBER_OF_CARDS)
            {
                int CardNumberID = randCardNumber.Next(Card.minCardNumID, Card.maxCardNumID);
                int CardSuitID = randCardSuit.Next(Card.minCardSuitID, Card.maxCardSuitID);
                newCard = new Card(CardNumberID, CardSuitID);

                if (!GeneratedDeck.Contains(newCard))
                {
                    CardCounter++;
                    GeneratedDeck.Push(newCard);
                }
            }
            return GeneratedDeck;
        }


        private void EnemyCardChoice()
        {
            _EnemyDeck.Push(Deck.Pop());
            _EnemyScore = ScoreComputing(_EnemyDeck);
        }

        private void ShowWinner() //the winner's conclusion
        {
            if (_EnemyScore > WIN_SCORE && _PlayerScore < WIN_SCORE ||
                _PlayerScore == WIN_SCORE && _EnemyScore != WIN_SCORE ||
                _PlayerScore > _EnemyScore && _PlayerScore <= WIN_SCORE)
            {
                _PlayerWins++;
                GetPlayersCardsView();
                Out.LoadView(_EnemyCards, _PlayerCards, _EnemyScore, _PlayerScore, _PlayerWins, _EnemyWins);
                Out.Win();
            }if (_PlayerScore > WIN_SCORE && _EnemyScore < WIN_SCORE ||
                _EnemyScore == WIN_SCORE && _PlayerScore != WIN_SCORE ||
                _EnemyScore > _PlayerScore && _EnemyScore <= WIN_SCORE)
            {
                _EnemyWins++;
                GetPlayersCardsView();
                Out.LoadView(_EnemyCards, _PlayerCards, _EnemyScore, _PlayerScore, _PlayerWins, _EnemyWins);
                Out.Lose();
            }if (_EnemyScore == _PlayerScore | _EnemyScore > WIN_SCORE & _PlayerScore > WIN_SCORE)
            {
                Out.LoadView(_EnemyCards, _PlayerCards, _EnemyScore, _PlayerScore, _PlayerWins, _EnemyWins);
                GetPlayersCardsView();
                Out.Draw();
            }

            Out.ChoiceOfActions();

            while (true)
            {
                string key = Console.ReadKey().Key.ToString();

                if (key == ConsoleKey.Escape.ToString())
                {
                    Environment.Exit(0);
                }
                if (key == ConsoleKey.Enter.ToString())
                {
                    Console.Clear();
                    NewGame();
                }
            }
        }

        private int ScoreComputing(Stack<Card> deck)
        {
            int score = 0;
            foreach (Card c in deck)
            {
                score += c.Score;
            }
            return score;
        }

    }
}
