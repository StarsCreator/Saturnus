using Support.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using CollectionMtLib;
using Support;

namespace Search
{
    public class Finder : IPlugin
    {
        #region Info

        private readonly Version _version = new Version(0, 0, 0, 1);
        private readonly char[] _symbols = {'q', 'й'};

        public string PluginName
        {
            get { return "Magic Ball"; }
        }

        public string DisplayPluginName
        {
            get { return "8-Ball"; }
        }

        public string PluginDescription
        {
            get { return "Плагин для ответов на вопросы"; }
        }

        public string Author
        {
            get { return "Stars"; }
        }

        public Version Version
        {
            get { return _version; }
        }

        #endregion



        private readonly Cache _cache;

        public Finder()
        {
            _cache = new Cache();
        }

        public IEnumerable<char> Symbols { get; private set; }
        public CollectionMtWithAsyncObservableCollectionReadOnlyCopy<Result> Collection { private get; set; }

        public void HintChanged(string input)
        {
            foreach (var sr in _cache.CachedResults.Where(sr => string.Compare(input, 0, sr.Name, 0, input.Length, true) == 0))
            {
                Collection.Add(sr);
            }
        }
    }
}