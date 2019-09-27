using System;
using System.Collections.Generic;
using System.IO;

namespace ChessBoard
{
    class Program
    {
        public static string ReadFile()
        {
            try
            {
                FileStream fileStream = new FileStream(@"chessLayout.txt", FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream))
                {
                    string fileContent;
                    if (string.IsNullOrEmpty(fileContent = streamReader.ReadLine()))
                    {
                        Console.WriteLine("The file appears empty!");
                        return null;
                    }
                    return fileContent;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("It appears that I have nothing to read from!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unpredicted exception caught: " + ex.Message);
            }
            return null;
        }

        public static List<string> SplitFileContent(string result)
        {
            return new List<string>(result.Split(";"));
        }

        public static List<string> FilterOutCoordinates(List<string> coordinates)
        {
            List<string> readyCoords = new List<string>();
            foreach (string coord in coordinates)
            {
                if (coord.Contains(','))
                    readyCoords.Add(coord);
            }
            return readyCoords;
        }

        public static void QueenPosition(List<string> positions, List<List<int>> singleQueen)
        {
            for (int queen = 0; queen < positions.Count; queen++)
            {
                List<int> tempQueenCount = new List<int>();
                string[] singleCoord = positions[queen].Split(",");

                for (int i = 0; i < singleCoord.Length; i++)
                {
                    int coordinate = Int32.Parse(singleCoord[i]);
                    tempQueenCount.Add(coordinate);
                }
                singleQueen.Add(tempQueenCount);
            }
        }

        static bool QueenLocationCheck(List<List<int>> queenGround, int y, int x)
        {
            for (int queen = 0; queen < queenGround.Count; queen++)
            {
                if (queenGround[queen][0] == y && queenGround[queen][1] == x)
                    return true;
            }
            return false;
        }

        static bool QueenMovementRuleSet(List<List<int>> queenGround, int y, int x)
        {
            for (int queen = 0; queen < queenGround.Count; queen++)
            {
                if (queenGround[queen][0] == y || queenGround[queen][1] == x)
                    return true;
            }
            return false;
        }
        
        // test not working method
        public static void VerticlLeftAxis(List<List<int>> queenGround, int v, int h, int side)
        {
            for (int queen = 0; queen < queenGround.Count; queen++)
            {
                if (queenGround[queen][0] == v)
                {
                    for (int i = side-1; i >= 0; i--)
                    {
                        v = i;
                    }
                }

                if (queenGround[queen][1] == h)
                {
                    for (int i = side - 1; i >= 0; i--)
                    {
                        h = i;
                    }
                }
            }
        }

        public static void BoardLayout(char[,] box, List<List<int>> queenGround)
        {
            int side = (int)Math.Sqrt(box.Length);

            for (int y = 0; y < side; y++)
            {
                for (int x = 0; x < side; x++)
                {
                    box[y, x] = '?';

                    if (QueenMovementRuleSet(queenGround, y, x))
                        box[y, x] = 'X';

                    if (QueenLocationCheck(queenGround, y, x))
                        box[y, x] = 'O';

                    Console.Write("{0} ", box[y, x]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Attempting to read file content!");

            string result = ReadFile();
            if (string.IsNullOrEmpty(result))
            {
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Ruleset: {0}", result);

            List<string> settings = SplitFileContent(result);
            List<string> queenLocations = FilterOutCoordinates(settings);
            List<List<int>> singleQueen = new List<List<int>>();

            int size = Int32.Parse(settings[0]);
            char[,] boxes = new char[size, size];

            QueenPosition(queenLocations, singleQueen);
            BoardLayout(boxes, singleQueen);

            Console.ReadKey();
        }
    }
}
