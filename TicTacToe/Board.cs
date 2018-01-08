using System.Linq;
using NUnit.Framework.Api;

namespace TicTacToe
{
    public class Board
    {
        private PlayerGlyph[] _boardState;
        public int Count { get; }
        public Board() : this(Enumerable.Repeat(PlayerGlyph.Empty, 9).ToArray(), 0)
        {
        }

        internal Board(PlayerGlyph[] boardState, int count)
        {
            _boardState = boardState;
            Count = count;
        }

    }
}