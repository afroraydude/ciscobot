using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ciscobot.Internal
{
    public class Config
    {
        public string token;

        public Config()
        {
            string currentDirectory = Environment.CurrentDirectory;
            string configFile = $"{currentDirectory}/config.json";
            string contents = File.ReadAllText(configFile);

            var json = JObject.Parse(contents);

            token = json["token"].ToString();
        }
    }
}