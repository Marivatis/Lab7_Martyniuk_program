using Lab7_Martyniuk_program;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lab7_Martyniuk_program
{
    public class MyConsole
    {
        protected FileManager fileManager;
        
        public MyConsole()
        {
            MyFile.Parse("File | 12 | 537 | 12.12.2009");
            int capacity = 0;

            while (true)
            {
                try
                {
                    Console.Write("Input max count of files (0 < N < 100) --> ");
                    capacity = Reader.ReadInt32(1, 101);
                    break;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Please, input number from the specified range!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Please, input only integer number!");
                }
            }                

            fileManager = new FileManager(capacity);
        }

        public void Run()
        {
            Printer.PrintMainMenu();
            int option;

            while (true)
            {
                Console.Write("[Main Menu] Choose any option --> ");                

                try
                {
                    option = Reader.ReadInt32(0, 9);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Please, select only available menu options!");
                    continue;
                }
                catch (Exception)
                {
                    Console.WriteLine("Please, input only integer number!");
                    continue;
                }

                if (option == 0)
                    break;

                MenuSwitch(option);
            }
        }

        private void MenuSwitch(int option)
        {
            switch (option)
            {
                case 1:
                    Printer.PrintAddingMenu();

                    int addOption = AddFileOption();
                    AddFileSwitch(addOption);                    
                    break;
                case 2:
                    Console.WriteLine("\n\t[Files list info]");
                    ShowFiles(fileManager);
                    break;
                case 3:
                    Console.WriteLine("\n\t[Finding File]");
                    Printer.PrintSearchPropertiesMenu();

                    int searchOption = SearchFileOption();
                    SearchFileSwitch(searchOption);
                    break;
                case 4:
                    DeleteFile();
                    break;
                case 5:
                    BehaviorEmulation behavior = new BehaviorEmulation(fileManager.Capacity);
                    behavior.Run();
                    break;
                case 6:
                    Printer.PrintDataWriterMenu();
                    int saveOption = SaveFileOption();
                    SaveFileSwitch(saveOption);
                    break;
                case 7:
                    Printer.PrintDataReaderMenu();
                    int loadOption = LoadFileOption();                    
                    LoadFileSwitch(loadOption);
                    break;
                case 8:
                    fileManager.Clear();
                    Console.WriteLine("The files list has been cleared!");
                    break;
                case 9:
                    Printer.PrintMainMenu();
                    break;
            }
        }

        // case 1: Add
        private int AddFileOption()
        {
            Console.Write("[Adding File] Choose any option --> ");
            int option = 0;

            try
            {
                option = Reader.ReadInt32(0, 4);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Please, select only available menu options!");
                option = AddFileOption();
            }
            catch (Exception)
            {
                Console.WriteLine("Please, input only integer number!");
                option = AddFileOption();
            }

            return option;
        }

        private void AddFileSwitch(int option)
        {
            MyFile file = null;

            switch (option)
            {
                case 0:
                    return;
                case 1:
                    file = CreateManually();
                    break;
                case 2:
                    file = fileManager.CreateRandomly();
                    break;
                case 3:
                    file = CreateFromStringManually();
                    break;
                case 4:
                    file = fileManager.CreateFromStringRandomly();
                    break;
            }

            try
            {
                fileManager.Add(file);
                Console.WriteLine("File has been added!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private MyFile CreateManually()
        {
            Console.Write("[Adding File] ");
            string name = MyFileReader.ReadName();
            Printer.PrintFileTypesMenu();
            Console.Write("[Adding File] ");
            FileType type = MyFileReader.ReadType();
            Console.Write("[Adding File] ");
            int size = MyFileReader.ReadSize();
            Console.Write("[Adding File] ");
            DateTime date = MyFileReader.ReadDate();

            return new MyFile(name, type, size, date);
        }

        private MyFile CreateFromStringManually()
        {
            Console.Write("[Adding File] Input file description (Name | Type | Size | Date) --> ");
            string input = Console.ReadLine();

            MyFile.TryParse(input, out MyFile file);

            if (file == null)
            {
                Console.WriteLine("Incorect input format!");
                CreateFromStringManually();
            }

            return file;
        }

        // case 2: Show
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

        // case 3: Search
        private int SearchFileOption()
        {            
            int option = 0;

            try
            {
                Console.Write("Insert search property --> ");
                option = Reader.ReadInt32(0, 4);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Please, input number from the specified range!");
                option = SaveFileOption();
            }
            catch (Exception)
            {
                Console.WriteLine("Please, input only integer number!");
                option = SaveFileOption();
            }
            
            return option;
        }

        private void SearchFileSwitch(int property)
        {
            FileManager foundFiles = null;

            switch (property)
            {
                case 1:
                    foundFiles = fileManager.Find(MyFileReader.ReadName());
                    break;
                case 2:
                    foundFiles = fileManager.Find(MyFileReader.ReadSize());
                    break;
                case 3:
                    Printer.PrintFileTypesMenu();
                    foundFiles = fileManager.Find(MyFileReader.ReadType());
                    break;
                case 4:
                    foundFiles = fileManager.Find(MyFileReader.ReadDate());
                    break;
                case 0:
                    break;
            }

            ShowFiles(foundFiles);
        }

        // case 4: Delete
        private void DeleteFile()
        {
            ShowFiles(fileManager);
            int position = 0;

            try
            {
                Console.Write($"Choose the number of file you want to delete [1; {fileManager.Count}] --> ");
                position = Reader.ReadInt32(1, fileManager.Count);
                fileManager.RemoveAt(position - 1);
            }
            catch (InvalidOperationException ex) 
            {
                Console.WriteLine(ex.Message); 
            }
            catch (FormatException)
            {
                Console.WriteLine("Please, input olny integer number!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                DeleteFile();
            }            
        }

        // case 6: File Write
        private int SaveFileOption()
        {
            int option = 0;

            try
            {
                Console.Write("Input file save option --> ");
                option = Reader.ReadInt32(0, 2);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Please, input number from the specified range!");
                option = SaveFileOption();
            }
            catch (Exception)
            {
                Console.WriteLine("Please, input only integer number!");
                option = SaveFileOption();
            }

            return option;
        }

        private void SaveFileSwitch(int option)
        {
            string path = "D:\\Работы ВУЗ\\Курс 2.1\\ООП\\ЛР 7\\Saved Files";

            Console.Write($"Input file name --> ");
            string name = Console.ReadLine();

            bool isWriten = false;
            switch (option)
            {
                case 1:
                    isWriten = DataWriter.WriteToCsvFile(fileManager, $"{path}\\{name}.csv");
                    break;
                case 2:
                    isWriten = DataWriter.WriteToJsonFile(fileManager, $"{path}\\{name}.json");
                    break;  
                case 0:
                    break;
            }

            if (isWriten)
                Console.WriteLine("The file was successly writen");
            else
                Console.WriteLine("Something went wrong");
        }

        // case 7: File Read
        private int LoadFileOption()
        {
            int option = 0;

            try
            {
                Console.Write("Input file load option --> ");
                option = Reader.ReadInt32(0, 2);
            }
            catch (OverflowException)
            {
                Console.WriteLine("Please, input number from the specified range!");
                option = LoadFileOption();
            }
            catch (Exception)
            {
                Console.WriteLine("Please, input only integer number!");
                option = LoadFileOption();
            }

            return option;
        }
        
        private void LoadFileSwitch(int option)
        {
            string path = "D:\\Работы ВУЗ\\Курс 2.1\\ООП\\ЛР 7\\Saved Files";
            string name = string.Empty;

            switch (option)
            {
                case 1:
                    FilesPrinter.PrintFilesInFolder(path, FileType.csv);

                    Console.Write($"Input file name --> ");
                    name = Console.ReadLine();

                    DataReader.ReadFromCsvFile($"{path}\\{name}.csv", ref fileManager);
                    break;
                case 2:
                    FilesPrinter.PrintFilesInFolder(path, FileType.json);

                    Console.Write($"Input file name --> ");
                    name = Console.ReadLine();

                    DataReader.ReadFromJsonFile($"{path}\\{name}.json", ref fileManager);
                    break;
                case 0:
                    break;
            }

            Console.WriteLine("FIles was successfully loaded!");
        }        
    }
}