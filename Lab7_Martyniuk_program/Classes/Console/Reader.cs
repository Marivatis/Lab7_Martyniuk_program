using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab7_Martyniuk_program
{
    public class Reader
    {
        /// <summary>
        /// Reads integer number from console
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static int ReadInt32()
        {
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Reads integer number from console
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static int ReadInt32(int minRange, int maxRange)
        {
            int number = int.Parse(Console.ReadLine());

            if (minRange > number || number > maxRange)
                throw new OverflowException("Please, input number from the specified range!");

            return number;
        }
    }
}