using System;
using System.IO;
using TicTacToe.Enums;

namespace TicTacToe
{
    public class TextStreamBoardRenderer : IBoardRenderer
    {
        private readonly TextWriter _output;

        public TextStreamBoardRenderer(TextWriter output)
        {
            _output = output;
        }

        public void Render(PlayerGlyph[] currentBoard)
        {
            string ParseGlyph(PlayerGlyph glyph)
            {
                switch (glyph)
                {
                    case PlayerGlyph.Cross:
                        return "X";
                    case PlayerGlyph.Naught:
                        return "O";
                    case PlayerGlyph.Empty:
                        return "_";
                    default:
                        throw new ArgumentOutOfRangeException(nameof(glyph), glyph, null);
                }
            }

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    _output.Write($@"{ParseGlyph(currentBoard[i * 3 + j])}|");
                }
                _output.WriteLine();
            }
            _output.WriteLine();
        }
    }
}