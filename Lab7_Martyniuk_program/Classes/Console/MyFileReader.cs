using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Lab7_Martyniuk_program
{
    public class MyFileReader : Reader
    {
        public static string ReadName()
        {
            string name = string.Empty;
            string pattern = "^[a-zA-Z0-9 ]+$";
            bool isValidName = false;

            do
            {
                Console.Write("Input file name --> ");
                name = Console.ReadLine();
                isValidName = false;

                if (Regex.IsMatch(name, pattern)) isValidName = true;
                else Console.WriteLine("Name must contain only letters or digits!");
            }
            while (!isValidName);

            return name;
        }

        public static FileType ReadType()
        {
            FileType type = FileType.none;
            
            try
            {
                Console.Write("Input file type --> ");
                int typeNum = ReadInt32(1, 9);

                type = (FileType)typeNum;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Please, select only available file types!");
                type = ReadType();
            }
            catch (Exception)
            {
                Console.WriteLine("Please, input only integer number!");
                type = ReadType();
            }

            return type;
        }

        public static int ReadSize()
        {
            int size = 0;

            try
            {
                Console.Write("Max file size 1Gb, input size (Mb) --> ");
                size = ReadInt32(1, 1024);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Please, input number from the specified range!");
                size = ReadSize();
            }
            catch (Exception)
            {
                Console.WriteLine("Please, input only integer number!");
                size = ReadSize();
            }
            
            return size;
        }

        public static DateTime ReadDate()
        {
            string input;
            DateTime date;
            bool isValidDate;

            do
            {
                Console.Write("Insert file creation date (dd.mm.yyyy) --> ");
                input = Console.ReadLine();
                isValidDate = DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out date);
                if (!isValidDate) Console.WriteLine("Input date in correct format");
            }
            while (!isValidDate);

            return date;
        }
    }
}
