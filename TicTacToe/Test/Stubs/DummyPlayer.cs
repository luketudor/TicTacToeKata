using System;
using TicTacToe.Enums;
using TicTacToe.Players;

namespace TicTacToe.Test.Stubs
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