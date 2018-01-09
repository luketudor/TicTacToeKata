using System.Linq;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;
        private PlayerGlyph[] _currentBoard;
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
            var newBoard = new PlayerGlyph[9];
            _currentBoard.CopyTo(newBoard, 0);
            var currentPlayer = _player1Turn ? _player1 : _player2;
            newBoard[currentPlayer.TakeTurn(_currentBoard)] = currentPlayer.GetGlyph();
            _player1Turn = !_player1Turn;
            _currentBoard = newBoard;
            return _currentBoard;
        }

        public IPlayer Winner()
        {
            if (_currentBoard[0] == _player1.GetGlyph() &&
                _currentBoard[1] == _player1.GetGlyph() &&
                _currentBoard[2] == _player1.GetGlyph() ||
                _currentBoard[3] == _player1.GetGlyph() &&
                _currentBoard[4] == _player1.GetGlyph() &&
                _currentBoard[5] == _player1.GetGlyph() ||
                _currentBoard[6] == _player1.GetGlyph() &&
                _currentBoard[7] == _player1.GetGlyph() &&
                _currentBoard[8] == _player1.GetGlyph())
                return _player1;
            return null;
        }
    }
}