using System;
using System.Linq;
using TicTacToe.Enums;
using TicTacToe.Players;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private readonly PlayerGlyph[] _currentBoard;
        private readonly AbstractPlayer _player1;
        private readonly AbstractPlayer _player2;
        private readonly WinChecker _winChecker;
        private bool _player1Turn;

        public TicTacToeGame(AbstractPlayer player1, AbstractPlayer player2)
            : this(
                player1,
                player2,
                Enumerable.Repeat(PlayerGlyph.Empty, 9).ToArray(),
                true
            )
        {
        }

        internal TicTacToeGame(AbstractPlayer player1, AbstractPlayer player2, PlayerGlyph[] currentBoard,
            bool player1Turn)
        {
            _player1 = player1;
            _player2 = player2;
            _currentBoard = currentBoard;
            _player1Turn = player1Turn;
            _winChecker = new WinChecker();
        }

        public event EventHandler RaiseDrawEvent;
        public event EventHandler<AbstractPlayer> RaiseWinEvent;
        public event EventHandler<PlayerGlyph[]> RaiseRenderEvent;

        public void Run()
        {
            RaiseRenderEvent?.Invoke(this, _currentBoard);
            while (true)
            {
                NextTurn();
                RaiseRenderEvent?.Invoke(this, _currentBoard);
                if (IsWinner(out var winner))
                {
                    RaiseWinEvent?.Invoke(this, winner);
                    break;
                }
                if (IsDraw())
                {
                    RaiseDrawEvent?.Invoke(this, EventArgs.Empty);
                    break;
                }
            }
        }

        internal void NextTurn()
        {
            var currentPlayer = _player1Turn ? _player1 : _player2;
            _currentBoard[currentPlayer.MakeMove(_currentBoard)] = currentPlayer.GetGlyph();
            _player1Turn = !_player1Turn;
        }

        internal PlayerGlyph[] GetBoard()
        {
            return _currentBoard;
        }

        internal bool IsWinner(out AbstractPlayer winner)
        {
            winner = _winChecker.HasPlayerWon(_currentBoard, _player1.GetGlyph())
                ? _player1
                : _winChecker.HasPlayerWon(_currentBoard, _player2.GetGlyph())
                    ? _player2
                    : null;
            return winner != null;
        }

        internal bool IsDraw()
        {
            return !_currentBoard.Any(cell => cell == PlayerGlyph.Empty);
        }
    }
}