using Newtonsoft.Json;
using System;
using System.IO;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class JsonFileService : IJsonFileService
    {
        private readonly string pathToJsonFolder =
            Environment.CurrentDirectory + @"\JsonFile\answer.json";

        public byte[] ReadOfFile()
        {
            byte[] bytearr  = File.ReadAllBytes(pathToJsonFolder);
            return bytearr;
        }

        public void SaveOnFile(object Content)
        {
            using (StreamWriter file = File.CreateText(pathToJsonFolder))
            {
                var json = JsonConvert.SerializeObject(Content, Formatting.Indented);
                file.Write(json);
            }
        }


    }
}
