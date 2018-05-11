using Plugin.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PluginManager
{
    public class CommandRegister
    {
        Dictionary<string, IPlugin> commands;

        public CommandRegister(string path)
        {
            commands = new Dictionary<string, IPlugin>();
            LoadPluginsFromDirectory(path);
        }

        private void LoadPluginsFromDirectory(string path)
        {
            var files = Directory.GetFiles(path, "*.dll");
            foreach (var file in files)
            {
                LoadPluginsFromFile(file);
            }
        }

        private void LoadPluginsFromFile(string file)
        {
            var assembly = Assembly.LoadFile(file);
            var pluginTypes = assembly.GetTypes().Where(type => typeof(IPlugin).IsAssignableFrom(type));

            foreach (var type in pluginTypes)
            {
                var instance = Activator.CreateInstance(type) as IPlugin;
                commands.Add(instance.Name, instance);
            }
        }

        public Dictionary<string, IPlugin> GetPlugins()
        {
            return commands;
        }

        public IPlugin GetPlugin(string commandKey)
        {
            // should be defensive
            return commands.FirstOrDefault(x => x.Key == commandKey).Value;
        }
    }
}
