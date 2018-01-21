using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
            Mark ConvertGlyph(PlayerGlyph glyph)
            {
                switch (glyph)
                {
                    case PlayerGlyph.Cross:
                        return Mark.Cross;
                    case PlayerGlyph.Naught:
                        return Mark.Naught;
                    case PlayerGlyph.Empty:
                        return Mark.Empty;
                    default:
                        throw new Exception();
                }
            }

            IEnumerable<Mark> ConvertBoard(IEnumerable<PlayerGlyph> board)
            {
                return board.Select(ConvertGlyph);
            }

            while (true)
            {
                var game = new TicTacToeGame(
                    new StupidAIPlayer(PlayerGlyph.Cross),
                    new TextPlayer(PlayerGlyph.Naught, Console.In, Console.Error)
                );
                var renderer = new TextBoardRenderer(Console.Out);
                //var ren2 = new ConsoleRenderer();

                game.RaiseDrawEvent += (sender, eventArgs) => Console.WriteLine("Draw! Everyone loses!");
                //game.RaiseDrawEvent += (sender, eventArgs) => ren2.RenderGameIsADrawScreen();
                game.RaiseWinEvent += (sender, winner) =>
                    Console.WriteLine($"Congratulations, {winner.GetGlyph()} player won!");
                //game.RaiseWinEvent += (sender, winner) => ren2.RenderWinGameScreen(ConvertGlyph(winner.GetGlyph()));
                //game.RaiseRenderEvent += (sender, board) => ren2.RenderBoard(new List<Mark>(ConvertBoard(board)));
                game.RaiseRenderEvent += (sender, board) => renderer.Render(board);
                //ren2.RenderWelcomeMessage();
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