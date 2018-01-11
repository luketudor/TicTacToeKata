using System;
using System.IO;
using TicTacToe.Enums;

namespace TicTacToe
{
    public class TextBoardRenderer : IBoardRenderer
    {
        private readonly TextWriter _output;
        private readonly string _crossString;
        private readonly string _naughtString;
        private readonly string _emptyString;
        private readonly string _cellSeparator;
        private readonly int _boardWidth;
        private readonly int _boardLength;

        public TextBoardRenderer(TextWriter output)
        {
            _output = output;
            _crossString = "X";
            _naughtString = "O";
            _emptyString = "_";
            _cellSeparator = "|";
            _boardWidth = 3;
            _boardLength = 3;
        }

        public void Render(PlayerGlyph[] currentBoard)
        {
            for (var i = 0; i < _boardLength; i++)
            {
                for (var j = 0; j < _boardWidth; j++)
                {
                    _output.Write($"{ParseGlyph(currentBoard[i * _boardWidth + j])}{_cellSeparator}");
                }
                _output.WriteLine();
            }
            _output.WriteLine();
        }

        private string ParseGlyph(PlayerGlyph glyph)
        {
            switch (glyph)
            {
                case PlayerGlyph.Cross:
                    return _crossString;
                case PlayerGlyph.Naught:
                    return _naughtString;
                case PlayerGlyph.Empty:
                    return _emptyString;
                default:
                    throw new ArgumentOutOfRangeException(nameof(glyph), glyph, null);
            }
        }
    }
}