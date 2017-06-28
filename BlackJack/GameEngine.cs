using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal sealed class GameEngine
    {
        private const int MAX_NUM_CARDS = 8; //maximum number of cards
        private const int ENEMY_STOP_SCORE = 17; //enemy stops score
        private const int WIN_SCORE = 21;//main score of game
        private Deck _deck;
        private CardView _view;
        private Output _out = new Output();
        private StringBuilder _playerCards, _enemyCards;
        private int _playerScore, _enemyScore, _playerWins = 0, _enemyWins = 0;
        private Deck _playerDeck;
        private Deck _enemyDeck;

        internal GameEngine()
        {
            _view = new CardView();
        }

        internal void NewGame()
        {
            GameInitialization();
            GetPlayersCardsView();
            _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins, 0);
            Game();
            _out.Clear();
            ShowWinner();
        }

        private void GameInitialization() //new game initialization
        {
            _playerScore = 0;
            _enemyScore = 0;
            _playerDeck = new Deck();
            _enemyDeck = new Deck();
            _deck = new Deck();
            _deck.DeckGeneration();
        }

        private void Game()//response to a choice
        {
            while (_playerScore < WIN_SCORE && _enemyScore < WIN_SCORE)
            {
                string key = _out.ReadKeyToString();

                if (key == ConsoleKey.Spacebar.ToString())
                {
                    _out.Clear();
                    _playerDeck.Push(_deck.Pop());
                    _playerScore = ScoreComputing(_playerDeck);
                    if (_enemyScore < ENEMY_STOP_SCORE)
                    {
                        EnemyCardChoice();
                    }
                    GetPlayersCardsView();
                    _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins, 0);

                }
                if (key == ConsoleKey.Escape.ToString())
                {
                    Environment.Exit(0);
                }
                if (key == ConsoleKey.Enter.ToString())
                {
                    _out.Clear();
                    while (_enemyScore < ENEMY_STOP_SCORE)
                    {
                        EnemyCardChoice();
                    }
                    ShowWinner();
                }
            }
        }

        private void GetPlayersCardsView()
        {
            _view.GetPlayersCardsView(out _enemyCards, out _playerCards, _enemyDeck, _playerDeck);
        }
        
        private void EnemyCardChoice()
        {
            _enemyDeck.Push(_deck.Pop());
            _enemyScore = ScoreComputing(_enemyDeck);
        }

        private void ShowWinner() //the winner's conclusion
        {
            if (_enemyScore > WIN_SCORE && _playerScore < WIN_SCORE ||
                _playerScore == WIN_SCORE && _enemyScore != WIN_SCORE ||
                _playerScore > _enemyScore && _playerScore <= WIN_SCORE)
            {
                _playerWins++;
                GetPlayersCardsView();
                _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins);
                _out.Win();
            }if (_playerScore > WIN_SCORE && _enemyScore < WIN_SCORE ||
                _enemyScore == WIN_SCORE && _playerScore != WIN_SCORE ||
                _enemyScore > _playerScore && _enemyScore <= WIN_SCORE)
            {
                _enemyWins++;
                GetPlayersCardsView();
                _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins);
                _out.Lose();
            }if (_enemyScore == _playerScore | _enemyScore > WIN_SCORE & _playerScore > WIN_SCORE)
            {
                _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins);
                GetPlayersCardsView();
                _out.Draw();
            }

            _out.ChoiceOfActions();

            while (true)
            {
                string key = _out.ReadKeyToString();

                if (key == ConsoleKey.Escape.ToString())
                {
                    Environment.Exit(0);
                }
                if (key == ConsoleKey.Enter.ToString())
                {
                    _out.Clear();
                    NewGame();
                }
            }
        }

        private int ScoreComputing(Deck deck)
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
