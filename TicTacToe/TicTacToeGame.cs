using System;
using System.Linq;
using TicTacToe.Enums;
using TicTacToe.Players;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private readonly PlayerGlyph[] _currentBoard;
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;
        private readonly IBoardRenderer _renderer;
        private readonly WinChecker _winChecker;
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
            _renderer = new TextStreamBoardRenderer(Console.Out);
            _winChecker = new WinChecker();
        }

        public void NextTurn()
        {
            var currentPlayer = _player1Turn ? _player1 : _player2;
            var playerMove = currentPlayer.MakeMove(_currentBoard);
            // TODO should replace with validation
            if (_currentBoard[playerMove] != PlayerGlyph.Empty)
            {
                throw new ArgumentException("Position is not empty");
            }
            _currentBoard[playerMove] = currentPlayer.GetGlyph();
            _player1Turn = !_player1Turn;
        }

        internal PlayerGlyph[] GetBoard()
        {
            return _currentBoard;
        }

        public IPlayer Winner()
        {
            return _winChecker.HasPlayerWon(_currentBoard, _player1.GetGlyph())
                ? _player1
                : (_winChecker.HasPlayerWon(_currentBoard, _player2.GetGlyph()) ? _player2 : null);
        }

        public bool IsDraw()
        {
            return _currentBoard.All(cell => cell != PlayerGlyph.Empty);
        }

        public void Render()
        {
            _renderer.Render(_currentBoard);
        }
    }
}