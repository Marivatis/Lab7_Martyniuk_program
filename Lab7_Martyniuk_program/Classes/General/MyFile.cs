using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab7_Martyniuk_program
{
    public class MyFile
    {
        private static int _count;

        private string _name;
        private FileType _type = FileType.none;
        private int _size;
        private DateTime _creationDate;

        public MyFile()
        {
            _name = "Untitled file";
            _size = 0;
            _type = FileType.none;
            _creationDate = DateTime.MinValue;

            _count++;
        }

        public MyFile(string name, FileType fileType, int size, DateTime creationDate)
        {
            _name = name ?? "Untitled file";
            _size = size;
            _type = fileType;
            _creationDate = creationDate;

            _count++;
        }

        public static int Count => _count;

        public string Name 
        {
            get { return _name; } 
            set { _name = value; } 
        }

        public FileType Type 
        {
            get { return _type; }
            set { _type = value; }
        }

        public int Size 
        {
            get { return _size; }
            set { _size = value; }
        }
        
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }

        public override int GetHashCode()
        {
            int hash = 4;

            hash *= 3 + _name.GetHashCode();
            hash *= 3 + _type.GetHashCode();
                        
            return hash;            
        }

        public override string ToString()
        {
            byte typeMaxLength = 0;
            foreach (FileType fileType in Enum.GetValues(typeof(FileType)))
            {
                if (fileType.ToString().Length > typeMaxLength)
                    typeMaxLength = (byte)fileType.ToString().Length;
            }

            string typeString = _type.ToString();
            if (typeString.Length < typeMaxLength)
                typeString = typeString.PadRight(typeString.Length + (typeMaxLength - typeString.Length), ' ');

            string sizeString = _size.ToString();
            if (sizeString.Length < 4) // 4 is max size length
                sizeString = sizeString.PadRight(sizeString.Length + (4 - sizeString.Length), ' ');

            string info = $"{_name} | {typeString} | {sizeString} | {_creationDate.ToString("dd.MM.yyyy")}";
            return info;
        }

        public static MyFile Parse(string s)
        {
            string[] values = s?.Split('|') ?? throw new NullReferenceException();

            if (values.Length != 4) throw new FormatException();

            string name = values[0].Trim();
            if (!Regex.IsMatch(name, "^[a-zA-Z0-9 ]+$")) throw new FormatException();

            FileType type = (FileType)Enum.Parse(typeof(FileType), values[1].Trim());

            int size = int.Parse(values[2].Trim());
            if (size > 1024) throw new OverflowException();

            DateTime date = DateTime.ParseExact(values[3].Trim(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            return new MyFile(name, type, size, date);
        }

        public static bool TryParse(string s, out MyFile file)
        {
            file = null;

            try
            {
                file = Parse(s);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
