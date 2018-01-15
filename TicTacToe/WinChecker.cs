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
                int ForwardDiagonalSelector(int e) => e * 2 + 2;
                int BackwardDiagonalSelector(int e) => e * 4;

                var forwardDiagonalRowIndices =
                    Enumerable.Range(0, numDiagonalRowLength).Select(ForwardDiagonalSelector);
                var backDiagonalRowIndices = Enumerable.Range(0, numDiagonalRowLength).Select(BackwardDiagonalSelector);

                yield return backDiagonalRowIndices;
                yield return forwardDiagonalRowIndices;


                foreach (var horizontalRowNumber in Enumerable.Range(0, numHorizontalRows))
                {
                    int VerticalRowSelector(int e) => e * numVerticalCols + horizontalRowNumber;
                    int HorizontalRowSelector(int e) => e + numVerticalCols * horizontalRowNumber;

                    var verticalRowIndices = Enumerable.Range(0, numVerticalCols).Select(VerticalRowSelector);
                    var horizontalRowIndices = Enumerable.Range(0, numVerticalCols).Select(HorizontalRowSelector);

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