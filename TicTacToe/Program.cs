﻿using System;
using System.IO;
using TicTacToe.Enums;
using TicTacToe.Players;

namespace TicTacToe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var game = new TicTacToeGame(
                new ComputerPlayer(PlayerGlyph.Cross),
                new TextStreamPlayer(PlayerGlyph.Naught, Console.In)
                );
            while (!game.IsDraw())
            {
                game.NextTurn();
                game.Render();
                var winner = game.Winner();
                if (winner != null)
                {
                    break;
                }
            }
        }
    }
}