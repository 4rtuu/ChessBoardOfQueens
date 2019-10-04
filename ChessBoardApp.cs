using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoard
{
    public class ChessBoardApp
    {
        public void Run()
        {
            // instanciations
            var readFile = new ReadFile();
            var sortingFile = new SortingFile();
            var queen = new ListOfQueens();
            var stringBuilder = new StringBuilder();
            var buildBoard = new BuildBoard();

            // asign values (file content, board size, queen count, individual queen coordinates)
            var fileContent = readFile.ReadFromFile();
            var settings = sortingFile.SplitFileContent(fileContent);
            var coordMash = sortingFile.GetCoordinates(settings);
            var sortedQueensWithCoordinates = queen.SortCoordinates(coordMash);

            // First value of settings (aka. board size) as string to int conversion
            Int32.TryParse(settings[0], out int rowLength);

            // Build ChessBoard(board size, string builder, values)
            buildBoard.BoardCellCycle(rowLength, stringBuilder, sortedQueensWithCoordinates);
            
            // Print
            string boardOutput = stringBuilder.ToString();
            Console.Write(boardOutput);

            Console.ReadKey();
        }
    }
}
