﻿using System;
using TicTacToe.Enums;
using TicTacToe.Players;

namespace TicTacToe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                var game = new TicTacToeGame(
                            new ComputerPlayer(PlayerGlyph.Cross),
                            new TextPlayer(PlayerGlyph.Naught, Console.In, Console.Out));
                var renderer = new TextBoardRenderer(Console.Out);

                game.RaiseDrawEvent += (sender, eventArgs) => Console.WriteLine("Draw! Everyone loses!");
                game.RaiseWinEvent += (sender, winner) => Console.WriteLine($"Congratulations, {winner.GetGlyph()} player won!");
                game.RaiseRenderEvent += (sender, board) => renderer.Render(board);

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