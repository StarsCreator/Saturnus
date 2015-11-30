using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CollectionMtLib;
using Saturnus.Models.Interfaces;
using Support;
using Support.Interfaces;

namespace Saturnus.Models
{
    public class PluginHost : IPluginHost
    {
        private List<IPlugin> _plugins;

        public void LoadPlugins(string path)
        {
            var pluginFiles = Directory.GetFiles(path, "*.dll");
            _plugins = new List<IPlugin>();

            foreach (var assembly in pluginFiles.Select(Assembly.LoadFile))
            {
                try
                {
                    foreach (var p in from t in assembly.GetTypes() where (from i in t.GetInterfaces() let c = i.TypeInitializer select i).Any(i => i.Name == "IPlugin") select (IPlugin) Activator.CreateInstance(t))
                    {
                        _plugins.Add(p);
                    }
                }
                catch
                {
                    //TODO:Add to Log
                    Console.WriteLine("Ошибка загрузки плагина {0}", assembly.FullName);
                }
            }
        }

        public void RegisterPlugins(CollectionMtWithAsyncObservableCollectionReadOnlyCopy<Result> results)
        {
            foreach (var plugin in _plugins)
            {
                plugin.Collection = results;
            }
        }

        public void RemovePlugins(IPlugin plugin)
        {
            _plugins.Remove(plugin);
        }

        public IEnumerable<IPlugin> Plugins
        {
            get { return _plugins; }
        }
    }
}