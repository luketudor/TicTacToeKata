using System;
using TicTacToe.Enums;

namespace TicTacToe.Players
{
    public class StupidAIPlayer : BasePlayer
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