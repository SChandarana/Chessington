using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            var directions = CardinalDirections;
            var helpers = new Helpers();
            for (var i = 1; i < GameSettings.BoardSize; i++)
            {
                helpers.AddMoves(board, directions, currentSquare, i, moves, this.Player);
                directions = helpers.UpdateValidDirections(board, directions, currentSquare, i);
            }

            return moves;
        }

    }
}