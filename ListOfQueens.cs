using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoard
{
    public class ListOfQueens
    {
        public List<Queen> SortCoordinates(List<string> queensWithCoordsMash)
        {
            var coordsOfQeens = new List<Queen>();

            for (int queen = 0; queen < queensWithCoordsMash.Count; queen++)
            {
                var theQueen = new Queen();

                string[] singleCoord = queensWithCoordsMash[queen].Split(",");

                for (int i = 0; i < singleCoord.Length; i++)
                {
                    int coordinate = Int32.Parse(singleCoord[i]);

                    switch (i)
                    {
                        case 0:
                            theQueen.coordinateX = coordinate;
                            break;
                        case 1:
                            theQueen.coordinateY = coordinate;
                            break;

                        default:
                            break;
                    }                    
                }
                coordsOfQeens.Add(theQueen);
            }
            return coordsOfQeens;
        }
    }
}
