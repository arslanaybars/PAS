using Plugin.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace PluginManager
{
    public class PluginManager
    {
        // collection
        public Dictionary<string, IPlugin> commands = new Dictionary<string, IPlugin>();

        // single
        public IPlugin plugin;

        string pluginDirectory;

        public PluginManager()
        {
            // todo get plugin dll folder from appsettings
            pluginDirectory = System.IO.Directory.GetCurrentDirectory() + "\\PluginDlls";
            commands = GetPlugins();
        }

        public PluginManager(string pluginName)
        {
            // todo get plugin dll folder from appsettings
            pluginDirectory = System.IO.Directory.GetCurrentDirectory() + "\\PluginDlls"; 
            plugin = GetPlugin(pluginName);
        }

        public Dictionary<string, IPlugin> GetPlugins()
        {
            var commandRegistrator = new CommandRegister(pluginDirectory);
            return commandRegistrator.GetPlugins();
        }

        public IPlugin GetPlugin(string pluginName)
        {
            var pluginRegistrator = new CommandRegister(pluginDirectory);
            return pluginRegistrator.GetPlugin(pluginName);
        }
    }
}
