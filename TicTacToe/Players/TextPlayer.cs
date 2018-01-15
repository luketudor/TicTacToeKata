using System.IO;
using TicTacToe.Enums;

namespace TicTacToe.Players
{
    public class TextPlayer : IPlayer
    {
        private readonly PlayerGlyph _glyph;
        private readonly TextReader _input;
        private readonly TextWriter _output;

        public TextPlayer(PlayerGlyph glyph, TextReader input, TextWriter output)
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
            while(true)
            {
                var parseSuccess = int.TryParse(_input.ReadLine(), out var position);
                if (!parseSuccess)
                {
                    _output.WriteLine("Invalid format: Positive integers only, please try again");
                }
                else if (position < 0)
                {
                    _output.WriteLine("Negative indices are not allowed, please try again");
                }
                else if (position >= board.Length)
                {
                    _output.WriteLine("That index is out of bounds, please try again");
                }
                else if (board[position] != PlayerGlyph.Empty)
                {
                    _output.WriteLine("That position is occupied, please try again");
                }
                else
                {
                    return position;
                }
            }
        }
    }
}