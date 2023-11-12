using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Martyniuk_program
{
    public class FileManager : IEnumerable<MyFile>, IMyFileCreator, ICollection
    {
        private List<MyFile> files;

        public FileManager()
        {
            files = new List<MyFile>(100);
        }

        public FileManager(int capacity)
        {
            files = new List<MyFile>(capacity);
        }

        public int Count => files.Count;

        public int Capacity => files.Capacity;

        public object SyncRoot => ((ICollection)files).SyncRoot;

        public bool IsSynchronized => ((ICollection)files).IsSynchronized;

        public MyFile this[int index]
        {
            get { return files[index]; }
            set { files[index] = value; }
        }

        public void Add(MyFile file)
        {
            if (IsDuplicate(file))
                throw new DuplicateNameException("This file already exist!");

            if (Count == Capacity)
                throw new OverflowException("Max amount of files has been added already!");

            files.Add(file);
        }

        public void Add(MyFile file, bool canDuplicate)
        {
            if (Count == Capacity)
                throw new OverflowException("Max amount of files has been added already!");

            files.Add(file);
        }

        public void RemoveAt(int index)
        {
            files.RemoveAt(index);
            GC.Collect();
        }

        public FileManager Find(string name)
        {
            var filesList = files.FindAll(f => f.Name == name);

            if (filesList.Count == 0)
                return null;

            return ListToFileManager(filesList);
        }

        public FileManager Find(int size)
        {
            var filesList = files.FindAll(files => files.Size == size);

            if (filesList.Count == 0)
                return null;

            return ListToFileManager(filesList);
        }

        public FileManager Find(FileType type)
        {
            var filesList = files.FindAll(files => files.Type == type);

            if (filesList.Count == 0)
                return null;

            return ListToFileManager(filesList);
        }

        public FileManager Find(DateTime date)
        {
            var filesList = files.FindAll(files => files.CreationDate == date);

            if (filesList.Count == 0)
                return null;

            return ListToFileManager(filesList);
        }

        public void Clear()
        {
            files.Clear();
        }

        public IEnumerator<MyFile> GetEnumerator() { return files.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        public MyFile CreateRandomly()
        {
            string name = RandomFileProperties.GetName();
            FileType type = RandomFileProperties.GetType();
            ushort size = RandomFileProperties.GetSize();
            DateTime date = RandomFileProperties.GetDate();

            MyFile file = new MyFile(name, type, size, date);

            return file;
        }

        public MyFile CreateFromStringRandomly()
        {
            string input = RandomFileProperties.GetFileInfo();
            MyFile.TryParse(input, out MyFile file);

            return file;
        }

        public void CopyTo(Array array, int index)
        {
            int i = index;
            foreach (MyFile file in files)
            {
                array.SetValue(file, i++);
            }
        }

        private bool IsDuplicate(MyFile newFile)
        {
            foreach (MyFile file in files)
            {
                if (newFile.GetHashCode() == file.GetHashCode())
                    return true;
            }

            return false;
        }

        private FileManager ListToFileManager(List<MyFile> files)
        {
            FileManager fileManager = new FileManager(files.Capacity);

            foreach (MyFile file in files)
            {
                fileManager.Add(file);
            }

            return fileManager;
        }
    }
}
