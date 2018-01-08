using System.Collections.Generic;

namespace TicTacToe
{
    public class ComputerPlayer : Player
    {
        public ComputerPlayer(PlayerGlyph glyph) : base(glyph)
        {
        }

        public override int TakeTurn(IReadOnlyList<PlayerGlyph> board)
        {
            return board.Count;
        }
    }
}
