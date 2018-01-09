using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

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

        private bool HasPlayerWon(PlayerGlyph player)
        {
            var winningRows = new int[8][];
            for (var i = 0; i < 3; i++)
            {
                winningRows[i] = new int[3];
                for (var j = 0; j < 3; j++)
                {
                    winningRows[i][j] = j + 3 * i;
                }
            }
            for (var i = 0; i < 3; i++)
            {
                winningRows[i + 3] = new int[3];
                for (var j = 0; j < 3; j++)
                {
                    winningRows[i + 3][j] = j * 3 + i;
                }
            }
            winningRows[6] = new int[3];
            for (var j = 0; j < 3; j++)
            {
                winningRows[6][j] = j * 4;
            }
            winningRows[7] = new int[3];
            for (var j = 0; j < 3; j++)
            {
                winningRows[7][j] = j * 2 + 2;
            }
            return winningRows.Any(winningRow => winningRow.All(index => _currentBoard[index] == player));
        }

        public bool IsDraw()
        {
            return _currentBoard.All(cell => cell != PlayerGlyph.Empty);
        }
    }
}