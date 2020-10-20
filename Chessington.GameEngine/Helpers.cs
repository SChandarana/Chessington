using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine
{
    public class Helpers
    {
        public void AddMoves(
            Board board, 
            List<Direction> directions, 
            Square currentSquare, 
            int spacesAway, 
            List<Square> moves, 
            Player player
            )
        {
            var newDirections = new List<Direction>();
            foreach (var direction in directions)
            {
                var potentialMove = Square.At(
                    currentSquare.Row + spacesAway * direction.RowOffset,
                    currentSquare.Col + spacesAway * direction.ColOffset
                    );
                var pieceOnNewSquare = board.GetPiece(potentialMove);

                if (pieceOnNewSquare == null || pieceOnNewSquare.Player != player)
                {
                    moves.AddIfOnBoard(potentialMove);
                }
            }
        }

        public List<Direction> UpdateValidDirections(
            Board board,
            List<Direction> directions,
            Square currentSquare,
            int spacesAway
        )
        {
            var newDirections = new List<Direction>();
            foreach (var direction in directions)
            {
                var potentialMove = Square.At(
                    currentSquare.Row + spacesAway * direction.RowOffset,
                    currentSquare.Col + spacesAway * direction.ColOffset
                );
                var pieceOnNewSquare = board.GetPiece(potentialMove);                
                
                if (pieceOnNewSquare == null)
                {
                    newDirections.Add(direction);
                }
            }

            return newDirections;
        }
    }
}

