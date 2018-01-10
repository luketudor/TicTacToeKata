using System.Collections.Generic;
using System.Linq;
using TicTacToe.Enums;

namespace TicTacToe
{
    public class WinChecker
    {
        private readonly IEnumerable<IEnumerable<int>> _winningRows;

        public WinChecker()
        {
            IEnumerable<IEnumerable<int>> WinningRows()
            {
                IEnumerable<int> ForwardDiagonalRowIndices()
                {
                    for (var j = 0; j < 3; j++)
                    {
                        yield return j * 2 + 2;
                    }
                }

                IEnumerable<int> BackDiagonalRowIndices()
                {
                    for (var j = 0; j < 3; j++)
                    {
                        yield return j * 4;
                    }
                }

                IEnumerable<int> VerticalRowIndices(int rowNumber)
                {
                    for (var j = 0; j < 3; j++)
                    {
                        yield return j * 3 + rowNumber;
                    }
                }

                IEnumerable<int> HorizontalRowIndices(int rowNumber)
                {
                    for (var j = 0; j < 3; j++)
                    {
                        yield return j + 3 * rowNumber;
                    }
                }

                for (var i = 0; i < 3; i++)
                {
                    yield return HorizontalRowIndices(i);
                    yield return VerticalRowIndices(i);
                }
                yield return BackDiagonalRowIndices();
                yield return ForwardDiagonalRowIndices();
            }

            _winningRows = WinningRows();
        }

        public bool HasPlayerWon(PlayerGlyph[] currentBoard, PlayerGlyph player)
        {
            return _winningRows.Any(winningRow => winningRow.All(index => currentBoard[index] == player));
        }
    }
}