using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab7_Martyniuk_program
{
    public class RandomFileProperties
    {
        private static Random _random = new Random();

        public static string GetName()
        {
            return $"File {_random.Next(10, 100)}";
        }

        public static ushort GetSize()
        {
            return (ushort)_random.Next(1, 1024);
        }

        public static new FileType GetType()
        {
            return (FileType)_random.Next(1, 9);
        }

        public static DateTime GetDate()
        {
            int year = _random.Next(1995, 2024);
            int manth = _random.Next(1, 13);
            int day = _random.Next(1, DateTime.DaysInMonth(year, manth) + 1);

            return new DateTime(year, manth, day);
        }

        public static string GetFileInfo()
        {
            return $"{GetName()} | {GetType()} | {GetSize()} | {GetDate().ToString("dd.MM.yyyy")}";
        }
    }
}
