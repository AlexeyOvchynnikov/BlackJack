using System;
using System.Text;

namespace BlackJack
{
    internal sealed class Output
    {
        internal void LoadView(StringBuilder _EnemyCards, StringBuilder _PlayerCards, int _EnemyScore, int _PlayerScore, int _PlayerWins, int _EnemyWins, int viewtype = 1)
        {
            Console.WriteLine("________________\n   Enemy cards:");
            Console.WriteLine("________________\n");
            Console.WriteLine(_EnemyCards);
            Console.WriteLine(" Enemy score:" + _EnemyScore);
            Console.WriteLine("________________\n   Your cards:");
            Console.WriteLine("________________\n");
            Console.WriteLine(_PlayerCards);
            Console.WriteLine(" Your score:" + _PlayerScore + "\n__________________________________________________");
            Console.WriteLine("           Total score {0}:{1}", _PlayerWins, _EnemyWins);
            if (viewtype == 0)
            {
                Console.WriteLine(" More - |Space| Open cards - |Enter|  Exit - |Esc|");
            }
        }
        internal void ChoiceOfActions()
        {
            Console.WriteLine(" Again - |Enter|  Exit - |Esc|");
        }
        internal void Win()
        {
            Console.WriteLine("You WIN!");
        }

        internal void Lose()
        {
            Console.WriteLine("You  LOSE!");
        }
        internal void Draw()
        {
            Console.WriteLine("DRAW");
        }

        internal void Clear()
        {
            Console.Clear();
        }

    }
}
