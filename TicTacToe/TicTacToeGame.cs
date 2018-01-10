using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;
        private readonly PlayerGlyph[] _currentBoard;
        private bool _player1Turn;

        public TicTacToeGame(IPlayer player1, IPlayer player2) : this(player1, player2,
            Enumerable.Repeat(PlayerGlyph.Empty, 9).ToArray(), true)
        {
        }

        internal TicTacToeGame(IPlayer player1, IPlayer player2, PlayerGlyph[] currentBoard, bool player1Turn)
        {
            _player1 = player1;
            _player2 = player2;
            _currentBoard = currentBoard;
            _player1Turn = player1Turn;
        }

        public PlayerGlyph[] NextBoard()
        {
            var currentPlayer = _player1Turn ? _player1 : _player2;
            _currentBoard[currentPlayer.TakeTurn(_currentBoard)] = currentPlayer.GetGlyph();
            _player1Turn = !_player1Turn;
            return _currentBoard;
        }

        public IPlayer Winner()
        {
            return HasPlayerWon(_player1.GetGlyph()) ? _player1 : (HasPlayerWon(_player2.GetGlyph()) ? _player2 : null);
        }

        public bool IsDraw()
        {
            return _currentBoard.All(cell => cell != PlayerGlyph.Empty);
        }

        private bool HasPlayerWon(PlayerGlyph player)
        {
            return WinningRows().Any(winningRow => winningRow.All(index => _currentBoard[index] == player));
        }

        private IEnumerable<IEnumerable<int>> WinningRows()
        {
            for (var i = 0; i < 3; i++)
            {
                yield return HorizontalRowIndices(i);
            }
            for (var i = 0; i < 3; i++)
            {
                yield return VerticalRowIndices(i);
            }
            yield return BackDiagonalRowIndices();
            yield return ForwardDiagonalRowIndices();
        }

        private IEnumerable<int> HorizontalRowIndices(int rowNumber)
        {
            for (var j = 0; j < 3; j++)
            {
                yield return j + 3 * rowNumber;
            }
        }

        private IEnumerable<int> VerticalRowIndices(int rowNumber)
        {
            for (var j = 0; j < 3; j++)
            {
                yield return j * 3 + rowNumber;
            }
        }

        private IEnumerable<int> BackDiagonalRowIndices()
        {
            for (var j = 0; j < 3; j++)
            {
                yield return j * 4;
            }
        }

        private IEnumerable<int> ForwardDiagonalRowIndices()
        {
            for (var j = 0; j < 3; j++)
            {
                yield return j * 2 + 2;
            }
        }
    }
}