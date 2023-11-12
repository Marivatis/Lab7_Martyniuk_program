using System;
using System.IO;

namespace Lab7_Martyniuk_program
{
    public class FilesPrinter
    {
        public static void PrintFilesInFolder(string path, FileType type = FileType.none)
        {
            try
            {
                string[] files = Directory.GetFiles(path);

                Console.WriteLine("\n\t[Existing files in folder `Saved Files`]");
                foreach (string file in files)
                {
                    if (Path.GetFileName(file).Split('.')[1] == type.ToString() || type == FileType.none) 
                        Console.WriteLine("#: "+ Path.GetFileName(file));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
