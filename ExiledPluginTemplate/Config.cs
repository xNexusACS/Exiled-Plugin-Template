// Usings
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace ExiledPluginTemplate
{
    public class Config : IConfig // Config File, all of this will be generated in your config file when EXILED load the plugin
    {
        [Description("Indicate if the plugin is enabled or not")] // Small description of the config
        public bool IsEnabled { get; set; } = true; // Indicate if the plugin is enabled or not (true: will going to load | false: won't going to load)
        
        public bool Debug { get; set; } = false; // Indicate if the plugin will show debug logs in the console or not (true: will going to show debug messages | false: won't going to show debug messages)
        
        public bool EnableCassieSubtitles { get; set; } = true; // Indicate if the plugin will show Cassie Subtitles or not (true: will going to show Cassie Subtitles | false: won't going to show Cassie Subtitles) (Used in the Example Transpiler)
    }
}