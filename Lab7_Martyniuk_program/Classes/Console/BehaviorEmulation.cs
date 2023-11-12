using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab7_Martyniuk_program
{
    public class BehaviorEmulation
    {
        private FileManager fileManager;

        public BehaviorEmulation(int capacity) 
        {
            fileManager = new FileManager(capacity);
        }

        public void Run()
        {
            Console.WriteLine("\n\t\t[Program behaviour demonstration]");

            // Adding
            Console.WriteLine("\n\t[1 - Add File]");

            AddFileRandomly();
            AddFileRandomly();

            CopyingFiles();

            // Showing
            Console.WriteLine("\n\t[2 - Showing Files]");
            ShowFiles(fileManager);

            // Searching Files
            Console.WriteLine("\n\t[3 - Searching Files]");
            FindingRandomly();

            // Deleteing Files
            Console.WriteLine("\n\t[4 - Delete File]");
            Random random = new Random();

            int num = random.Next(1, fileManager.Count);
            Console.WriteLine($"Choose the number of file you want to delete [1; {fileManager.Count}] --> {num}");

            fileManager.RemoveAt(num - 1);
            Console.WriteLine("File was deleted!");

            ShowFiles(fileManager);


            Console.WriteLine("\n\t[Behavior test end]\n\n");
        }

        private void AddFileRandomly()
        {
            MyFile file = fileManager.CreateRandomly();
            Console.WriteLine($"[Adding File] Input file name --> {file.Name}");
            Console.WriteLine($"[Adding File] Input file type --> {file.Type}");
            Console.WriteLine($"[Adding File] Input file size --> {file.Size}");
            Console.WriteLine($"[Adding File] Input file creation date--> {file.CreationDate}");

            fileManager.Add(file);
            Console.WriteLine("File has been added!");
        }

        protected void ShowFiles(FileManager files)
        {
            if (files.Count == 0)
            {
                Console.WriteLine("No files has been added yet!");
                return;
            }

            int i = 1;
            foreach (MyFile file in files)
            {
                string numString = (i++).ToString();
                if (numString.Length < files.Count)
                    numString = numString.PadRight(numString.Length + (files.Count.ToString().Length - numString.Length), ' ');

                Console.WriteLine($"[#{numString}]: {file}");
            }
        }

        private void CopyingFiles()
        {
            Console.WriteLine("\nCopying files using ToString():");
            List<MyFile> newFiles = new List<MyFile>();

            foreach (MyFile file in fileManager)
            {
                string info = file.ToString();
                Console.WriteLine($"[Adding File] Input file description (Name | Type | Size | Date) --> {info}");
                MyFile.TryParse(info, out MyFile newFile);
                newFiles.Add(newFile);
            }

            foreach (MyFile file in newFiles)
                fileManager.Add(file, true);
        }

        private void FindingRandomly()
        {
            Random random = new Random();
            string name;
            FileType type;
            int size;
            DateTime date;
            FileManager foundFiles = null;

            switch (random.Next(1, 4))
            {
                case 1:
                    name = fileManager[random.Next(0, fileManager.Count)].Name;
                    Console.WriteLine("Search property [Name] --> " + name);
                    foundFiles = fileManager.Find(name);
                    break;
                case 2:
                    type = fileManager[random.Next(0, fileManager.Count)].Type;
                    Console.WriteLine("Search property [Type] --> " + type);
                    foundFiles = fileManager.Find(type);
                    break;
                case 3:
                    size = fileManager[random.Next(0, fileManager.Count)].Size;
                    Console.WriteLine("Search property [Size] --> " + size);
                    foundFiles = fileManager.Find(size);
                    break;
                case 4:
                    date = fileManager[random.Next(0, fileManager.Count)].CreationDate;
                    Console.WriteLine("Search property [Date] --> " + date);
                    foundFiles = fileManager.Find(date);
                    break;
            }

            ShowFiles(foundFiles);
        }
    }
}