using System;
namespace BlackJack
{
    internal sealed class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Black Jack";
            GameEngine Game = new GameEngine();
            Game.NewGame();
        }
    }
}
