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
            const int numHorizontalRows = 3;
            const int numVerticalCols = 3;
            const int numDiagonalRowLength = 3;

            IEnumerable<IEnumerable<int>> WinningRowsIndices()
            {
                var forwardDiagonalRowIndices =
                    Enumerable.Range(0, numDiagonalRowLength).Select(e => e * 2 + 2);
                var backDiagonalRowIndices = Enumerable.Range(0, numDiagonalRowLength).Select(e => e * 4);

                yield return backDiagonalRowIndices;
                yield return forwardDiagonalRowIndices;


                foreach (var horizontalRowNumber in Enumerable.Range(0, numHorizontalRows))
                {
                    var verticalRowIndices = Enumerable.Range(0, numVerticalCols)
                        .Select(e => e * numVerticalCols + horizontalRowNumber);
                    var horizontalRowIndices = Enumerable.Range(0, numVerticalCols)
                        .Select(e => e + numVerticalCols * horizontalRowNumber);

                    yield return horizontalRowIndices;
                    yield return verticalRowIndices;
                }
            }

            _winningRowsIndices = WinningRowsIndices();
        }

        public bool HasPlayerWon(PlayerGlyph[] currentBoard, PlayerGlyph player)
        {
            return _winningRowsIndices.Any(winningRowIndices =>
                winningRowIndices.All(winningRowIndex =>
                    currentBoard[winningRowIndex] == player
                )
            );
        }
    }
}