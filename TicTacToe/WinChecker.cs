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

            IEnumerable<IEnumerable<int>> WinningRows()
            {
                IEnumerable<int> ForwardDiagonalRowIndices()
                {
                    for (var i = 0; i < numDiagonalRowLength; i++)
                    {
                        yield return i * 2 + 2;
                    }
                }

                IEnumerable<int> BackDiagonalRowIndices()
                {
                    for (var i = 0; i < numDiagonalRowLength; i++)
                    {
                        yield return i * 4;
                    }
                }

                IEnumerable<int> VerticalRowIndices(int horizontalRowNumber)
                {
                    for (var i = 0; i < numVerticalCols; i++)
                    {
                        yield return i * numVerticalCols + horizontalRowNumber;
                    }
                }

                IEnumerable<int> HorizontalRowIndices(int horizontalRowNumber)
                {
                    for (var i = 0; i < numVerticalCols; i++)
                    {
                        yield return i + numVerticalCols * horizontalRowNumber;
                    }
                }

                for (var i = 0; i < numHorizontalRows; i++)
                {
                    yield return HorizontalRowIndices(i);
                    yield return VerticalRowIndices(i);
                }
                yield return BackDiagonalRowIndices();
                yield return ForwardDiagonalRowIndices();
            }

            _winningRowsIndices = WinningRows();
        }

        public bool HasPlayerWon(PlayerGlyph[] currentBoard, PlayerGlyph player) => 
            _winningRowsIndices.Any(winningRowIndices => 
            winningRowIndices.All(winningRowIndex => 
            currentBoard[winningRowIndex] == player
            ));
    }
}