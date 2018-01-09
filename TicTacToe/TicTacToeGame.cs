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

        private bool HasPlayerWon(PlayerGlyph player)
        {
            return _currentBoard[0] == player &&
                   _currentBoard[1] == player &&
                   _currentBoard[2] == player ||
                   _currentBoard[3] == player &&
                   _currentBoard[4] == player &&
                   _currentBoard[5] == player ||
                   _currentBoard[6] == player &&
                   _currentBoard[7] == player &&
                   _currentBoard[8] == player ||
                   _currentBoard[0] == player &&
                   _currentBoard[3] == player &&
                   _currentBoard[6] == player ||
                   _currentBoard[1] == player &&
                   _currentBoard[4] == player &&
                   _currentBoard[7] == player ||
                   _currentBoard[2] == player &&
                   _currentBoard[5] == player &&
                   _currentBoard[8] == player ||
                   _currentBoard[0] == player &&
                   _currentBoard[4] == player &&
                   _currentBoard[8] == player ||
                   _currentBoard[2] == player &&
                   _currentBoard[4] == player &&
                   _currentBoard[6] == player;
        }

        public bool IsDraw()
        {
            return _currentBoard.All(cell => cell != PlayerGlyph.Empty);
        }
    }
}