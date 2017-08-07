using System;
using System.Text;

namespace BlackJack
{
    internal sealed class GameEngine
    {
        private Deck _deck;
        private Output _out = new Output();
        private KeysComparator _keysComparator = new KeysComparator();
        private StringBuilder _playerCards, _enemyCards;
        private int _playerScore, _enemyScore, _playerWins = 0, _enemyWins = 0;

        // New game initialization.
        private void GameInitialization()
        {
            _playerScore = 0;
            _enemyScore = 0;
            _deck = new Deck();
            _playerCards = new StringBuilder();
            _enemyCards = new StringBuilder();
        }

        internal void NewGame()
        {
            GameInitialization();
            _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins, GameData.viewOnGame);
            Game();
            _out.Clear();
            ShowWinner();
            GameFinishActions();
        }
        // Response to a choice.
        private void Game()
        {
            while (_playerScore < GameData.WIN_SCORE && _enemyScore < GameData.WIN_SCORE)
            {
                string key = _keysComparator.ReadKeyToString();

                if (_keysComparator.KeyIsSpacebar(key))
                {
                    _out.Clear();
                    Card card = _deck.Pop();
                    ScoreComputing(card, ref _playerScore);
                    _playerCards.Insert(_playerCards.Length, card + "\n");

                    if (_enemyScore < GameData.ENEMY_STOP_SCORE)
                    {
                        EnemyCardChoice();
                    }
                    _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins, GameData.viewOnGame);

                }
                if (_keysComparator.KeyIsEscape(key))
                {
                    Environment.Exit(0);
                }
                if (_keysComparator.KeyIsEnter(key))
                {
                    _out.Clear();
                    while (_enemyScore < GameData.ENEMY_STOP_SCORE)
                    {
                        EnemyCardChoice();
                    }
                    ShowWinner();
                    GameFinishActions();
                }
            }
        }

        private void EnemyCardChoice()
        {
            Card card = _deck.Pop();
            ScoreComputing(card, ref _enemyScore);
            _enemyCards.Insert(_enemyCards.Length, card + "\n");
        }

        // The winner's conclusion.
        private void ShowWinner()
        {
            if (_playerScore < GameData.WIN_SCORE)
            {
                if (_enemyScore > GameData.WIN_SCORE)
                {
                    _playerWins++;
                    _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins, GameData.viewFinishGame);
                    _out.Win();
                }
                if (_playerScore == _enemyScore)
                {
                    _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins, GameData.viewFinishGame);
                    _out.Draw();
                }
                if (_playerScore < _enemyScore && _enemyScore <= GameData.WIN_SCORE)
                {
                    _enemyWins++;
                    _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins, GameData.viewFinishGame);
                    _out.Lose();
                }
            }
            if (_playerScore == GameData.WIN_SCORE)
            {
                if (_enemyScore != GameData.WIN_SCORE)
                {
                    _playerWins++;
                    _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins, GameData.viewFinishGame);
                    _out.Win();
                }
                if (_enemyScore == GameData.WIN_SCORE)
                {
                    _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins, GameData.viewFinishGame);
                    _out.Draw();
                }
            }
            if (_playerScore > GameData.WIN_SCORE)
            {
                if (_enemyScore > GameData.WIN_SCORE)
                {
                    _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins, GameData.viewFinishGame);
                    _out.Draw();
                }
                if (_enemyScore <= GameData.WIN_SCORE)
                {
                    _enemyWins++;
                    _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins, GameData.viewFinishGame);
                    _out.Lose();
                }
            }


        }
        private void GameFinishActions()
        {
            _out.ChoiceOfActions();

            while (true)
            {
                string key = _keysComparator.ReadKeyToString();

                if (_keysComparator.KeyIsEscape(key))
                {
                    Environment.Exit(0);
                }
                if (_keysComparator.KeyIsEnter(key))
                {
                    _out.Clear();
                    NewGame();
                }
            }
        }
        private void ScoreComputing(Card card, ref int score)
        {
            score += card.Score;
        }

    }
}
