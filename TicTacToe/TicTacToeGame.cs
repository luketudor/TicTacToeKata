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
            var winningRows = new int[8][];
            winningRows[0] = new[] {0, 1, 2};
            winningRows[1] = new[] {3, 4, 5};
            winningRows[2] = new[] {6, 7, 8};
            winningRows[3] = new[] {0, 3, 6};
            winningRows[4] = new[] {1, 4, 7};
            winningRows[5] = new[] {2, 5, 8};
            winningRows[6] = new[] {0, 4, 8};
            winningRows[7] = new[] {2, 4, 6};
            return winningRows.Any(winningRow => winningRow.All(index => _currentBoard[index] == player));
        }

        public bool IsDraw()
        {
            return _currentBoard.All(cell => cell != PlayerGlyph.Empty);
        }
    }
}