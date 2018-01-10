﻿using System;
using TicTacToe.Enums;

namespace TicTacToe.Players
{
    public class ComputerPlayer : IPlayer
    {
        private readonly PlayerGlyph _glyph;

        public ComputerPlayer(PlayerGlyph glyph)
        {
            _glyph = glyph;
        }

        public PlayerGlyph GetGlyph()
        {
            return _glyph;
        }

        public int MakeMove(PlayerGlyph[] board)
        {
            return Array.IndexOf(board, PlayerGlyph.Empty);
        }
    }
}