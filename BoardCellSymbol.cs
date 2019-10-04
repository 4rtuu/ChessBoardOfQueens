using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoard
{
    class BoardCellSymbol
    {
        public char[,] AsignToCellValue(int rowLength, int coordX, int coordY, List<Queen> sortedQueensWithCoordinates)
        {
            var board = new char[rowLength, rowLength];

            // assign available cells to its symbol
            board[coordX, coordY] = Setup._available;

            for (int queen = 0; queen < sortedQueensWithCoordinates.Count; queen++)
            {
                var coordinateY = sortedQueensWithCoordinates[queen].coordinateY;
                var coordinateX = sortedQueensWithCoordinates[queen].coordinateX;

                // assign cells that queens are located at to its symbol
                board[coordinateX, coordinateY] = Setup._taken;

                if (coordX == coordinateX || coordY == coordinateY)
                {
                    if (board[coordX, coordY] != Setup._taken)
                    {
                        // assign horizontal/vertical queen movement of her position to its symbol
                        board[coordX, coordY] = Setup._path;
                    }
                }
                // assaign diagonal queen movement of her position to its symbol
                // SW path
                EndangaredCellLocationDiagonally(board, coordinateX, coordinateY, rowLength, -1, +1);
                // SE path
                EndangaredCellLocationDiagonally(board, coordinateX, coordinateY, rowLength, +1, +1);
                // NW path
                EndangaredCellLocationDiagonally(board, coordinateX, coordinateY, rowLength, -1, -1);
                // NE path
                EndangaredCellLocationDiagonally(board, coordinateX, coordinateY, rowLength, +1, -1);
            }
            return board;
        }

        public void EndangaredCellLocationDiagonally(char[,] board, int coordinateX, int coordinateY, int rowLength, int x, int y)
        {
            while (rowLength != 0)
            {
                coordinateX += x;
                coordinateY += y;
                if (coordinateY < 0 || coordinateX < 0 || coordinateY >= rowLength || coordinateX >= rowLength)
                {
                    break;
                }
                if (board[coordinateX, coordinateY] != Setup._taken)
                {
                    board[coordinateX, coordinateY] = Setup._path;
                }
            }
        }
    }
}
