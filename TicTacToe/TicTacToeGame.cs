using System.Collections.Generic;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        public TicTacToeGame()
        {
        }

        internal TicTacToeGame(IReadOnlyList<string> previousBoard, string currentPlayer)
        {
            
        }

        public IReadOnlyList<string> NextBoard()
        {
            return new List<string>(new[] {"X"});
        }
    }
}
