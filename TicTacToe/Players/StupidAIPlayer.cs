using System;
using TicTacToe.Enums;

namespace TicTacToe.Players
{
    public class StupidAIPlayer : AbstractPlayer
    {
        public StupidAIPlayer(PlayerGlyph glyph)
        {
            this.glyph = glyph;
        }

        public override int MakeMove(PlayerGlyph[] board) =>
            Array.IndexOf(board, PlayerGlyph.Empty);
    }
}