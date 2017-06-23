using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Output
    {
        CardView View;
        GameEngine Engine;

        int PlayerCountCards, EnemyCountCards, PlayerScore, EnemyScore, PlayerWins=0, EnemyWins=0;
        int[] PlayerDeck;
        int[] EnemyDeck;
        Stack<int> Deck;

        internal Output()
        {
            View = new CardView();
            Engine = new GameEngine();
            GameInitialization();

        }

        internal void GameInitialization() //new game initialization
        {
            PlayerCountCards = 0;
            EnemyCountCards = 0;
            PlayerScore = 0;
            EnemyScore = 0;
            PlayerDeck = new int[Engine.MAX_NUM_CARDS];
            EnemyDeck = new int[Engine.MAX_NUM_CARDS];
            Deck = Engine.GetSuit();
        }
        internal void StartGame()
        {
            GameInitialization();
            LoadView(0);
            Game();
            Console.Clear();
            ShowWinner();
        }

        void Game()//response to a choice
        {
            while (PlayerScore < Engine.WIN_SCORE && EnemyScore < Engine.WIN_SCORE)
            {
                string key = Console.ReadKey().Key.ToString();

                if (key == ConsoleKey.Spacebar.ToString())
                {
                    Console.Clear();
                    PlayerDeck[PlayerCountCards] = Deck.Pop();
                    PlayerCountCards++;
                    PlayerScore = Engine.ScoreComputing(PlayerDeck);
                    if (EnemyScore < Engine.ENEMY_STOP_SCORE)
                    {
                        EnemyCardChoice();
                    }
                    LoadView(0);

                }
                if (key == ConsoleKey.Escape.ToString())
                {
                    Environment.Exit(0);
                }
                if (key == ConsoleKey.Enter.ToString())
                {
                    Console.Clear();
                    while (EnemyScore < Engine.ENEMY_STOP_SCORE)
                    {
                        EnemyCardChoice();
                    }
                    ShowWinner();
                }
            }
        }

        void EnemyCardChoice()
        {
            EnemyDeck[EnemyCountCards] = Deck.Pop();
            EnemyCountCards++;
            EnemyScore = Engine.ScoreComputing(EnemyDeck);
        }
        void ShowWinner() //the winner's conclusion
        {
            if (EnemyScore > Engine.WIN_SCORE && PlayerScore < Engine.WIN_SCORE ||
                PlayerScore == Engine.WIN_SCORE && EnemyScore != Engine.WIN_SCORE ||
                PlayerScore > EnemyScore && PlayerScore <= Engine.WIN_SCORE)
            {
                PlayerWins++;
                LoadView();
                Console.WriteLine("You WIN!");
            }
            else if (PlayerScore > Engine.WIN_SCORE && EnemyScore < Engine.WIN_SCORE || 
                EnemyScore == Engine.WIN_SCORE && PlayerScore != Engine.WIN_SCORE ||
                EnemyScore > PlayerScore && EnemyScore <= Engine.WIN_SCORE)
            {
                EnemyWins++;
                LoadView();
                Console.WriteLine("You  LOSE!");
            }
            else if (EnemyScore == PlayerScore | EnemyScore > Engine.WIN_SCORE & PlayerScore > Engine.WIN_SCORE)
            {
                LoadView();
                Console.WriteLine("DRAW");
            }

            Console.WriteLine(" Again - |Enter|  Exit - |Esc|");

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
                    StartGame();
                }
            }
        }

        void LoadView(int viewtype = 1)
        {
            Console.WriteLine("________________\n   Enemy cards:");
            Console.WriteLine("________________\n");
            Console.WriteLine(View.GetCardView(EnemyDeck, EnemyCountCards,out EnemyScore));
            Console.WriteLine(" Enemy score:" + EnemyScore);
            Console.WriteLine("________________\n   Your cards:");
            Console.WriteLine("________________\n");
            Console.WriteLine(View.GetCardView(PlayerDeck, PlayerCountCards,out PlayerScore));
            Console.WriteLine(" Your score:" + PlayerScore + "\n__________________________________________________");
            Console.WriteLine("           Total score {0}:{1}", PlayerWins, EnemyWins);
            if (viewtype == 0)
                Console.WriteLine(" More - |Space| Open cards - |Enter|  Exit - |Esc|");

        }

    }
}
