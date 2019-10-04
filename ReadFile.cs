using System;
using System.IO;

namespace ChessBoard
{
    public class ReadFile
    {
        private string fileContent;
        public string ReadFromFile()
        {
            try
            {
                FileStream fileStream = new FileStream(@"chessLayout.txt", FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream))
                {
                    if (string.IsNullOrEmpty(fileContent = streamReader.ReadLine()))
                    {
                        Console.WriteLine("The file appears empty!");
                        return null;
                    }
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
            return fileContent;
        }
    }
}
