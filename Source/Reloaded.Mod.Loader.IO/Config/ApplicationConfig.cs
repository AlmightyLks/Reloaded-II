﻿using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Reloaded.Mod.Loader.IO.Interfaces;
using Reloaded.Mod.Loader.IO.Weaving;

namespace Reloaded.Mod.Loader.IO.Config
{
    public class ApplicationConfig : ObservableObject, Mod.Interfaces.IApplicationConfig, IConfig
    {
        /// <summary>
        /// The name of the configuration file as stored on disk.
        /// </summary>
        public const string ConfigFileName = "AppConfig.json";
        public string AppId { get; set; } = "reloaded.application.template";
        public string AppName { get; set; } = "Reloaded Application Template";
        public string AppLocation { get; set; } = "";
        public string AppArguments { get; set; } = "";
        public string AppIcon { get; set; } = "Icon.png";
        public string[] EnabledMods { get; set; } = new string[0];

        public ApplicationConfig()
        {

        }

        public ApplicationConfig(string appId, string appName, string appLocation)
        {
            AppId = appId;
            AppName = appName;
            AppLocation = appLocation;
        }

        /*
           ---------
           Utilities
           --------- 
        */

        /// <summary>
        /// Returns the name of the executable, with extension.
        /// </summary>
        public string GetExecutableName() => Path.GetFileName(AppLocation);

        /// <summary>
        /// Writes the configuration to a specified file path.
        /// </summary>
        public static void WriteConfiguration(string path, ApplicationConfig config)
        {
            var _applicationConfigLoader = new ConfigReader<ApplicationConfig>();
            _applicationConfigLoader.WriteConfiguration(path, config);
        }

        /*
            ---------
            Overrides
            ---------
        */

        /* Useful for debugging. */
        public override string ToString()
        {
            return $"AppName: {AppName}, AppLocation: {AppLocation}";
        }

        /*
           ------------------------
           Overrides: Autogenerated
           ------------------------
        */

        protected bool Equals(ApplicationConfig other)
        {
            return string.Equals(AppName, other.AppName) &&
                   string.Equals(AppLocation, other.AppLocation) && 
                   string.Equals(AppArguments, other.AppArguments) && 
                   string.Equals(AppIcon, other.AppIcon) && 
                   Enumerable.SequenceEqual(EnabledMods, other.EnabledMods);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != this.GetType())
                return false;

            return Equals((ApplicationConfig)obj);
        }

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (AppName != null ? AppName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AppLocation != null ? AppLocation.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AppArguments != null ? AppArguments.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (AppIcon != null ? AppIcon.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (EnabledMods != null ? EnabledMods.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}
