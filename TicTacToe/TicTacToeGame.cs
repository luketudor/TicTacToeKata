using System;
using System.Linq;
using TicTacToe.Enums;
using TicTacToe.Players;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private readonly PlayerGlyph[] _currentBoard;
        private readonly BasePlayer _player1;
        private readonly BasePlayer _player2;
        private readonly WinChecker _winChecker;
        private bool _player1Turn;

        public TicTacToeGame(BasePlayer player1, BasePlayer player2)
        {
            _player1 = player1;
            _player2 = player2;
            _currentBoard = Enumerable.Repeat(PlayerGlyph.Empty, 9).ToArray();
            _player1Turn = true;
            _winChecker = new WinChecker();
        }

        public event EventHandler RaiseDrawEvent;
        public event EventHandler<BasePlayer> RaiseWinEvent;
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

        private void NextTurn()
        {
            var currentPlayer = _player1Turn ? _player1 : _player2;
            _currentBoard[currentPlayer.MakeMove(_currentBoard)] = currentPlayer.GetGlyph();
            _player1Turn = !_player1Turn;
        }

        private bool IsWinner(out BasePlayer winner)
        {
            winner = _winChecker.HasPlayerWon(_currentBoard, _player1.GetGlyph())
                ? _player1
                : _winChecker.HasPlayerWon(_currentBoard, _player2.GetGlyph())
                    ? _player2
                    : null;
            return winner != null;
        }

        private bool IsDraw()
        {
            return _currentBoard.All(cell => cell != PlayerGlyph.Empty);
        }
    }
}