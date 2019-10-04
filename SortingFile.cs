using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoard
{
    public class SortingFile
    {
        // Split string where ";" and return as list
        public List<string> SplitFileContent(string fileContent)
        {
            return new List<string>(fileContent.Split(";"));
        }

        // Loop through each value from list check if it contains a ","
        // And add it to another list and return it
        public List<string> GetCoordinates(List<string> settings)
        {
            List<string> queensWithCoordsMash = new List<string>();

            foreach (string coord in settings)
            {
                if (coord.Contains(','))
                {
                    queensWithCoordsMash.Add(coord);
                }
            }
            return queensWithCoordsMash;
        }
    }
}
