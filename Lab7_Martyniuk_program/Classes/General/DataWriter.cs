using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace Lab7_Martyniuk_program
{
    public class DataWriter
    {
        public static bool WriteToJsonFile(FileManager myFiles, string path)
        {
            try
            {
                if (myFiles.Count == 0) 
                    return false;

                string jsonString = string.Empty;

                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(FileManager));

                using (FileStream file = new FileStream(path, FileMode.Create))
                {
                    json.WriteObject(file, myFiles);
                    file.Close();
                }

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public static bool WriteToCsvFile(FileManager myFiles, string path)
        {
            try
            {
                if (myFiles.Count == 0)
                    return false;

                List<string> lines = new List<string>();

                foreach (var file in myFiles)
                {
                    lines.Add(file.ToString());
                }

                File.WriteAllLines(path, lines);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
