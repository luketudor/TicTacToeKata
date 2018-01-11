using System;
using TicTacToe.Enums;
using TicTacToe.Players;

namespace TicTacToe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new TicTacToeGame(new ComputerPlayer(PlayerGlyph.Cross), new ComputerPlayer(PlayerGlyph.Naught));
            while (!game.IsDraw())
            {
                game.NextTurn();
                game.Render(Console.Out);
                var winner = game.Winner();
                if (winner != null)
                {
                    break;
                }
            }
        }
    }
}