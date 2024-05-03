using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;
using TestProject.General;
using System.Text.RegularExpressions;

namespace TestProject.Data
{
    public class DataManager : IDataLoader
    {
        //private string _path = Application.streamingAssetsPath + "/" + "Data" + "/";

        public int[,] LoadData(string nameFile)
        {
            if (string.IsNullOrWhiteSpace(nameFile) || !StringIsValid(nameFile))
            {
                Debug.LogError($"{TextMessages.ERROR_NAME_FILE} {nameFile}");
                return null;
            }

            var file = Resources.Load<TextAsset>(nameFile);
            //var file = File.ReadAllText(_path + nameFile + ".json");

            if (file == null)
            {
                Debug.LogError($"{TextMessages.ERROR_LOAD_JSON} {nameFile}");
                return null;
            }

            try
            {
                //var jsonData = JsonConvert.DeserializeObject<JsonData>(file);
                var jsonData = JsonConvert.DeserializeObject<JsonData>(file.text);
                return jsonData?.Values ?? throw new InvalidOperationException($"{TextMessages.INVALID_JSON}{nameFile}");
            }
            catch (JsonException ex)
            {
                Debug.LogError($"{nameFile}. {ex.Message}");
                return null;
            }
        }

        private static bool StringIsValid(string nameFile)
        {
            return !string.IsNullOrEmpty(nameFile) && !Regex.IsMatch(nameFile, @"[^a-zA-z\d_]");
        }
    }
}