using Core.Models;
using Core.Models.Abstractions;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Core.Utilites.Configuration
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> _sConfiguration;
        public static IConfiguration Configuration => _sConfiguration.Value;

        static Configurator()
        {
            _sConfiguration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath ?? throw new InvalidOperationException())
                .AddJsonFile("appsettings.json");

            var appSettingFiles = Directory.EnumerateFiles(basePath ?? string.Empty, "appsettings.*.json");

            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();
        }

        public static AppSettings AppSettings
        {
            get
            {
                var appSettings = new AppSettings();
                var child = Configuration.GetSection("AppSettings");
                appSettings.URL = child["URL"];

                return appSettings;
            }
        }

        public static List<User?> Users
        {
            get
            {
                List<User?> users = new();
                var child = Configuration.GetSection("Users");
                foreach (var section in child.GetChildren())
                {
                    var user = new User
                    {
                        Password = section["Password"],
                        Username = section["Username"],
                        JWT = section["JWT"]
                    };
                    user.UserType = section["UserType"]?.ToLower() switch
                    {
                        "admin" => UserType.Admin,
                        "user" => UserType.User,
                        _ => user.UserType
                    };

                    users.Add(user);
                }

                return users;
            }
        }

        public static User? Admin => Users.Find(u => u?.UserType == UserType.Admin);

        public static User? UserByUsername(string username) => Users.Find(u => u?.Username == username);

        public static string? BrowserType => Configuration[nameof(BrowserType)];
    }
}