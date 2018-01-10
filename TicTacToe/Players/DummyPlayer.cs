using System;
using TicTacToe.Enums;

namespace TicTacToe.Players
{
    public class DummyPlayer : IPlayer
    {
        public PlayerGlyph GetGlyph()
        {
            throw new NotSupportedException();
        }

        public int MakeMove(PlayerGlyph[] board)
        {
            throw new NotSupportedException();
        }
    }
}