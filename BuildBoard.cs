using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoard
{
    public class BuildBoard
    {
        public void BoardCellCycle(int rowLength, StringBuilder builder, List<Queen> sortedQueensWithCoordinates)
        {
            var boardCellSymbol = new BoardCellSymbol();

            for (int y = 0; y < rowLength; y++)
            {
                for (int x = 0; x < rowLength; x++)
                {
                    var sortedBoard = boardCellSymbol.AsignToCellValue(rowLength, x, y, sortedQueensWithCoordinates);

                    builder.Append(sortedBoard[x, y]).Append(' ');
                }
                builder.AppendLine();
            }
        }
    }
}
