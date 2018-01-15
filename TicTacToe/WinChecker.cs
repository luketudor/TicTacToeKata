using System;
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
                Func<int, int> forwardDiagonalSelector = e => e * 2 + 2;
                Func<int, int> backwardDiagonalSelector = e => e * 4;

                var diagonalRows = Enumerable.Range(0, numDiagonalRowLength);

                var forwardDiagonalRowIndices = diagonalRows.Select(forwardDiagonalSelector);
                var backDiagonalRowIndices = diagonalRows.Select(backwardDiagonalSelector);

                yield return backDiagonalRowIndices;
                yield return forwardDiagonalRowIndices;


                var verticalRows = Enumerable.Range(0, numVerticalCols);

                foreach (var horizontalRowNumber in Enumerable.Range(0, numHorizontalRows))
                {
                    Func<int, int> verticalRowSelector = e => e * numVerticalCols + horizontalRowNumber;
                    Func<int, int> horizontalRowSelector = e => e + numVerticalCols * horizontalRowNumber;

                    var verticalRowIndices = verticalRows.Select(verticalRowSelector);
                    var horizontalRowIndices = verticalRows.Select(horizontalRowSelector);

                    yield return horizontalRowIndices;
                    yield return verticalRowIndices;
                }
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