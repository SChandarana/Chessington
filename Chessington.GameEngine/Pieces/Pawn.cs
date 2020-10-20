using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var moves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            var playerDirection = this.Player == Player.White ? -1 : 1;
            var moveOneStep = Square.At(currentSquare.Row + playerDirection, currentSquare.Col);
            var moveTwoSteps = Square.At(currentSquare.Row + 2 * playerDirection, currentSquare.Col);
            
            if (board.GetPiece(moveOneStep) == null)
            {
                moves.AddIfOnBoard(moveOneStep);
            }

            if (!HasMoved && moves.Any() && board.GetPiece(moveTwoSteps) == null)
            {
                moves.AddIfOnBoard(moveTwoSteps);
            }

            var diagonal1 = Square.At(currentSquare.Row + 1 * playerDirection, currentSquare.Col + 1);
            var diagonal2 = Square.At(currentSquare.Row + 1 * playerDirection, currentSquare.Col - 1);
            var opposingPlayer = this.Player == Player.White ? Player.Black : Player.White;

            if (board.GetPiece(diagonal1)?.Player == opposingPlayer)
            {
                moves.AddIfOnBoard(diagonal1);
            }

            if (board.GetPiece(diagonal2)?.Player == opposingPlayer)
            {
                moves.AddIfOnBoard(diagonal2);
            }

            return moves;
        }
    }
}