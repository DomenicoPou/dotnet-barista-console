using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Windows;

namespace dotnet_barista_console.Handlers
{
    /// <summary>
    /// This data handler implements and handles a data folder with json files
    /// </summary>
    public static class DataHandler
    {
        // T will be the main configuartion class
        private static string dataFolderName = "Data";


        /// <summary>data
        /// Initial constructure  
        /// </summary>
        static DataHandler()
        {
        }


        /// <summary>
        /// Gets the data file full path depending on the configures type
        /// </summary>
        /// <returns>{ApplicationLocation}/Config/{TypeName}.json</returns>
        private static string GetConfigFile(string _fileName)
        {
            // Obtain file from application base directory. Using the folder name
            if (_fileName == null || _fileName == "")
                throw new ArgumentException("Filename is null or empty.");

            // Note this function assumes we are dealing with only JSON files
            string filePath = $@"{AppDomain.CurrentDomain.BaseDirectory}/{dataFolderName}/{_fileName}.json";

            if (!File.Exists(filePath))
                throw new ArgumentException($"File '{filePath}' doesn't exists.");

            // Return the data file
            return filePath;
        }


        /// <summary>
        /// Read the created data file.
        /// </summary>
        /// <returns>The object of the data type</returns>
        public static T? ReadConfig<T>(string _fileName)
        {
            // Get the congfiguration File
            string configFile = GetConfigFile(_fileName);
            
            // Deserialize Json to Object and Return It
            using (var fileStream = new FileStream(configFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var textReader = new StreamReader(fileStream))
            {
                string content = textReader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(content);
            }
        }
    }
}
