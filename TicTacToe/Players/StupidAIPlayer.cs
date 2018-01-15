using System;
using TicTacToe.Enums;

namespace TicTacToe.Players
{
    public class StupidAIPlayer : AbstractPlayer
    {
        public StupidAIPlayer(PlayerGlyph glyph)
        {
            Glyph = glyph;
        }

        public override int MakeMove(PlayerGlyph[] board)
        {
            return Array.IndexOf(board, PlayerGlyph.Empty);
        }
    }
}