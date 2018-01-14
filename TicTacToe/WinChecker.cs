using System.Collections.Generic;
using System.Linq;
using TicTacToe.Enums;

namespace TicTacToe
{
    public class WinChecker
    {
        private readonly IEnumerable<IEnumerable<int>> _winningRowsIndices;

        public WinChecker()
        {
            var numHorizontalRows = 3;
            var numVerticalCols = 3;
            var numDiagonalRowLength = 3;

            IEnumerable<IEnumerable<int>> WinningRowsIndices()
            {
                var diagonalRows = Enumerable.Range(0, numDiagonalRowLength);
                var verticalRows = Enumerable.Range(0, numVerticalCols);

                var forwardDiagonalRowIndices = diagonalRows.Select(e => e * 2 + 2);
                var backDiagonalRowIndices = diagonalRows.Select(e => e * 4);

                foreach (var horizontalRowNumber in Enumerable.Range(0, numHorizontalRows))
                {
                    var verticalRowIndices = verticalRows.Select(e => e * numVerticalCols + horizontalRowNumber);
                    var horizontalRowIndices = verticalRows.Select(e => e + numVerticalCols * horizontalRowNumber);

                    yield return horizontalRowIndices;
                    yield return verticalRowIndices;
                }
                yield return backDiagonalRowIndices;
                yield return forwardDiagonalRowIndices;
            }

            _winningRowsIndices = WinningRowsIndices();
        }

        public bool HasPlayerWon(PlayerGlyph[] currentBoard, PlayerGlyph player) => 
            _winningRowsIndices.Any(winningRowIndices => 
            winningRowIndices.All(winningRowIndex => 
            currentBoard[winningRowIndex] == player
            ));
    }
}