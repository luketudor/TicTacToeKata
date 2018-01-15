using System;
using System.Collections.Generic;
using TicTacToe.Enums;
using TicTacToe.GameBoard;
using TicTacToe.Players;
using TicTacToe.Renderer;
using TicTacToe.Renderers;

namespace TicTacToe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IEnumerable<Mark> Convert(PlayerGlyph[] board)
            {
                foreach(var glyph in board)
                {
                    switch(glyph)
                    {
                        case PlayerGlyph.Cross:
                            yield return Mark.Cross;
                            break;
                        case PlayerGlyph.Naught:
                            yield return Mark.Naught;
                            break;
                        case PlayerGlyph.Empty:
                            yield return Mark.Empty;
                            break;
                        default:
                            throw new Exception();
                    }
                }
            }

            while (true)
            {
                var game = new TicTacToeGame(
                            new ComputerPlayer(PlayerGlyph.Cross),
                            new TextPlayer(PlayerGlyph.Naught, Console.In, Console.Error)
                            );
                var renderer = new TextBoardRenderer(Console.Out);
                var ren2 = new ConsoleRenderer(); 

                game.RaiseDrawEvent += (sender, eventArgs) => Console.WriteLine("Draw! Everyone loses!");
                game.RaiseWinEvent += (sender, winner) => Console.WriteLine($"Congratulations, {winner.GetGlyph()} player won!");
                game.RaiseRenderEvent += (sender, board) => ren2.RenderBoard(new List<Mark>(Convert(board)));

                game.Run();

                Console.WriteLine("Do you want to play again? y/n");
                if (Console.ReadLine() != "y")
                {
                    break;
                }
            }
        }
    }
}