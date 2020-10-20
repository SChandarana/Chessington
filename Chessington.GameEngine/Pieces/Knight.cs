using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var potentialMoves = new List<Square>()
            {
                Square.At(currentSquare.Row + 2, currentSquare.Col + 1),
                Square.At(currentSquare.Row + 2, currentSquare.Col - 1),
                Square.At(currentSquare.Row - 2, currentSquare.Col + 1),
                Square.At(currentSquare.Row - 2, currentSquare.Col - 1),
                Square.At(currentSquare.Row + 1, currentSquare.Col + 2),
                Square.At(currentSquare.Row + 1, currentSquare.Col - 2),
                Square.At(currentSquare.Row - 1, currentSquare.Col + 2),
                Square.At(currentSquare.Row - 1, currentSquare.Col - 2)
            };

            return CheckAndAddMoves(potentialMoves, board);
        }

        public List<Square> CheckAndAddMoves(List<Square> potentialMoves, Board board)
        {
            var moves = new List<Square>();
            foreach (var move in potentialMoves)
            {
                var pieceOnNewSquare = board.GetPiece(move);
                if (pieceOnNewSquare == null || pieceOnNewSquare.Player != this.Player)
                {
                    moves.AddIfOnBoard(move);
                }
            }

            return moves;
        }
    }
}