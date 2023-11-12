using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Martyniuk_program
{
    public class Printer
    {
        public static void PrintMainMenu()
        {
            Console.WriteLine("\n\t[Menu]");
            Console.WriteLine("[1] - Add file");
            Console.WriteLine("[2] - Show files list");
            Console.WriteLine("[3] - Find file");
            Console.WriteLine("[4] - Delete file");
            Console.WriteLine("[5] - Show program behavior");            
            Console.WriteLine("[6] - Save files to file");
            Console.WriteLine("[7] - Load files from file");
            Console.WriteLine("[8] - Clear files");
            Console.WriteLine("[9] - Show menu");
            Console.WriteLine("[0] - Exit");
        }

        public static void PrintAddingMenu()
        {
            Console.WriteLine("\n\t[Adding File]");
            Console.WriteLine("[1] - Add file by hands");
            Console.WriteLine("[2] - Add file by random");
            Console.WriteLine("[3] - Add file from string by hands");
            Console.WriteLine("[4] - Add file from string by random");
            Console.WriteLine("[0] - Back to menu");
        }        

        public static void PrintFileTypesMenu()
        {
            Console.WriteLine("\n\t[File Types]");
            Console.WriteLine("[1] - txt");
            Console.WriteLine("[2] - pdf");
            Console.WriteLine("[3] - docx");
            Console.WriteLine("[4] - mp3");
            Console.WriteLine("[5] - flac");
            Console.WriteLine("[6] - mp4");
            Console.WriteLine("[7] - mkv");
            Console.WriteLine("[8] - png");
            Console.WriteLine("[9] - jpeg");
        }

        public static void PrintSearchPropertiesMenu()
        {
            Console.WriteLine("\n\t[Search Properties]");
            Console.WriteLine("[1] - Name");
            Console.WriteLine("[2] - Size");
            Console.WriteLine("[3] - Type");
            Console.WriteLine("[4] - Creation Date");
            Console.WriteLine("[0] - Back to menu");
        }

        public static void PrintDataWriterMenu()
        {
            Console.WriteLine("\n\t[FileManager Save]");
            Console.WriteLine("[1] - Save to .csv file");
            Console.WriteLine("[2] - Save to .json file");
            Console.WriteLine("[0] - Back to menu");
        }

        public static void PrintDataReaderMenu()
        {
            Console.WriteLine("\n\t[FileManager Save]");
            Console.WriteLine("[1] - Load from .csv file");
            Console.WriteLine("[2] - Load from .json file");
            Console.WriteLine("[0] - Back to menu");
        }
    }
}
