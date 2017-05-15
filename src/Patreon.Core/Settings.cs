using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Patreon.Core
{
    public class Settings
    {
        private string _path;

        public Settings(string path)
        {
            _path = path;
        }

        public ApiSettings ApiSettings { get; set; }
        public AccessTokenSettings AccessTokenSettings { get; set; }

        public void Load()
        {
            var profilePath = Path.Combine(Directory.GetCurrentDirectory(), _path);
            var profileConfigPath = Path.Combine(profilePath, "config");
            ApiSettings = new ApiSettings();
            AccessTokenSettings = new AccessTokenSettings();
            LoadApiSettings(profileConfigPath);
            LoadTokenSettings(profileConfigPath);
        }

        public void LoadApiSettings(string path)
        {
            var configFile = Path.Combine(path, "api.json");
            ApiSettings.Load(configFile);
        }
        public void LoadTokenSettings(string path)
        {
            var configFile = Path.Combine(path, "token.json");
            AccessTokenSettings.Load(configFile);
        }

        public void SaveApiSettings(string path)
        {
            var configFile = Path.Combine(path, "api.json");
            ApiSettings.Save(configFile);
        }
        public void SaveTokenSettings(string path)
        {
            var configFile = Path.Combine(path, "token.json");
            AccessTokenSettings.Save(configFile);
        }

        public void Save()
        {
            var profilePath = Path.Combine(Directory.GetCurrentDirectory(), _path);
            var profileConfigPath = Path.Combine(profilePath, "config");

            SaveApiSettings(profileConfigPath);
            SaveTokenSettings(profileConfigPath);
        }
    }
}
