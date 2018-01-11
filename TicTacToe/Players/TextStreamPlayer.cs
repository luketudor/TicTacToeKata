﻿using System;
using System.ComponentModel.Design;
using System.IO;
using TicTacToe.Enums;

namespace TicTacToe.Players
{
    public class TextStreamPlayer : IPlayer
    {
        private readonly PlayerGlyph _glyph;
        private readonly TextReader _input;
        private readonly TextWriter _output;

        public TextStreamPlayer(PlayerGlyph glyph, TextReader input, TextWriter output)
        {
            _glyph = glyph;
            _input = input;
            _output = output;
        }

        public PlayerGlyph GetGlyph()
        {
            return _glyph;
        }

        public int MakeMove(PlayerGlyph[] board)
        {
            var position = Convert.ToInt32(_input.ReadLine());
            while (board[position] != PlayerGlyph.Empty)
            {
                _output.WriteLine("That position is occupied, please try again");
                position = Convert.ToInt32(_input.ReadLine());
            }
            return position;
        }
    }
}