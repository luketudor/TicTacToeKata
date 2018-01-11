using System;
using System.IO;
using TicTacToe.Enums;

namespace TicTacToe.Players
{
    public class TextStreamPlayer : IPlayer
    {
        private readonly PlayerGlyph _glyph;
        private readonly TextReader _input;

        public TextStreamPlayer(PlayerGlyph glyph, TextReader input)
        {
            _glyph = glyph;
            _input = input;
        }

        public PlayerGlyph GetGlyph()
        {
            return _glyph;
        }

        public int MakeMove(PlayerGlyph[] board)
        {
            return Convert.ToInt32(_input.ReadLine());
        }
    }
}