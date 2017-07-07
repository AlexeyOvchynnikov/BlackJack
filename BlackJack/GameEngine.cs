using System;
using System.Text;

namespace BlackJack
{
    internal sealed class GameEngine
    {
        private Deck _deck;
        private Output _out = new Output();
        private StringBuilder _playerCards, _enemyCards;
        private int _playerScore, _enemyScore, _playerWins = 0, _enemyWins = 0;
        

        internal void NewGame()
        {
            GameInitialization();
            _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins, 0);
            Game();
            _out.Clear();
            ShowWinner();
        }

        private void GameInitialization() //new game initialization
        {
            _playerScore = 0;
            _enemyScore = 0;
            _deck = new Deck();
            _playerCards = new StringBuilder();
            _enemyCards = new StringBuilder();
        }

        private void Game()//response to a choice
        {
            while (_playerScore < GameData.WIN_SCORE && _enemyScore < GameData.WIN_SCORE)
            {
                string key = _out.ReadKeyToString();

                if (_out.KeyIsSpacebar(key))
                {
                    _out.Clear();
                    Card card = _deck.Pop();
                    ScoreComputing(card, ref _playerScore);
                    _playerCards.Insert(_playerCards.Length, card + "\n");

                    if (_enemyScore < GameData.ENEMY_STOP_SCORE)
                    {
                        EnemyCardChoice();
                    }
                    _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins, 0);

                }
                if (_out.KeyIsEscape(key))
                {
                    Environment.Exit(0);
                }
                if (_out.KeyIsEnter(key))
                {
                    _out.Clear();
                    while (_enemyScore < GameData.ENEMY_STOP_SCORE)
                    {
                        EnemyCardChoice();
                    }
                    ShowWinner();
                }
            }
        }
        
        private void EnemyCardChoice()
        {
            Card card = _deck.Pop();
            ScoreComputing(card, ref _enemyScore);
            _enemyCards.Insert(_enemyCards.Length, card + "\n");
        }

        private void ShowWinner() //the winner's conclusion
        {
            if (_enemyScore > GameData.WIN_SCORE && _playerScore < GameData.WIN_SCORE ||
                _playerScore == GameData.WIN_SCORE && _enemyScore != GameData.WIN_SCORE ||
                _playerScore > _enemyScore && _playerScore <= GameData.WIN_SCORE)
            {
                _playerWins++;
                _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins);
                _out.Win();
            }if (_playerScore > GameData.WIN_SCORE && _enemyScore < GameData.WIN_SCORE ||
                _enemyScore == GameData.WIN_SCORE && _playerScore != GameData.WIN_SCORE ||
                _enemyScore > _playerScore && _enemyScore <= GameData.WIN_SCORE)
            {
                _enemyWins++;
                _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins);
                _out.Lose();
            }if (_enemyScore == _playerScore | _enemyScore > GameData.WIN_SCORE & _playerScore > GameData.WIN_SCORE)
            {
                _out.LoadView(_enemyCards, _playerCards, _enemyScore, _playerScore, _playerWins, _enemyWins);
                _out.Draw();
            }

            _out.ChoiceOfActions();

            while (true)
            {
                string key = _out.ReadKeyToString();

                if (_out.KeyIsEscape(key))
                {
                    Environment.Exit(0);
                }
                if (_out.KeyIsEnter(key))
                {
                    _out.Clear();
                    NewGame();
                }
            }
        }

        private void ScoreComputing(Card card , ref int score)
        {
                score += card.Score;
        }

    }
}
