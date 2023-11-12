using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System;
using System.Runtime.Serialization.Json;

namespace Lab7_Martyniuk_program
{
    public class DataReader
    {
        public static void ReadFromJsonFile(string path, ref FileManager myFiles)
        {
            try
            {
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(FileManager));

                using (FileStream file = new FileStream(path, FileMode.Open))
                {
                    myFiles = (FileManager)json.ReadObject(file);
                    file.Close();
                }
            } 
            catch (IOException ex)
            {
                Console.WriteLine($"Reading Json file error: {ex.Message}");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ReadFromCsvFile(string path, ref FileManager myFiles)
        {
            try
            {
                List<string> lines = new List<string>();
                lines = File.ReadAllLines(path).ToList();

                foreach (string fileInfo in lines)
                {
                    MyFile.TryParse(fileInfo, out MyFile file);
                    if (file != null) myFiles.Add(file);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}
