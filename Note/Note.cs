using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using CollectionMtLib;
using Support;
using Support.Interfaces;

namespace Note
{
    public class Note : IPlugin
    {
        #region Info

        private readonly string _pluginName = "Note";
        private readonly string _displayPluginName = "Записная книжка";
        private readonly string _pluginDescription = "Запись и чтение заметок";
        private readonly string _author = "Stars";
        private readonly Version _version = new Version(0, 0, 0, 1);
        private readonly char[] _symbols = new[] {'n', 'т'};

        public string PluginName
        {
            get { return _pluginName; }
        }

        public string DisplayPluginName
        {
            get { return _displayPluginName; }
        }

        public string PluginDescription
        {
            get { return _pluginDescription; }
        }

        public string Author
        {
            get { return _author; }
        }

        public Version Version
        {
            get { return _version; }
        }

        #endregion

        public IEnumerable<char> Symbols
        {
            get { return _symbols; }
        }

        public CollectionMtWithAsyncObservableCollectionReadOnlyCopy<Result> Collection { get; set; }

        public void Action(string input)
        {
            var sb = new StringBuilder();
            var text = Assembly.GetExecutingAssembly().Location;
            sb.Append(text.Remove(text.LastIndexOf('\\') + 1));
            sb.Append("Notes");
            if (!Directory.Exists(sb.ToString())) Directory.CreateDirectory(sb.ToString());
            sb.Append("\\");
            sb.Append(DateTime.Now.ToString("ddMMyy-hhmm"));
            sb.Append(".txt");

            File.WriteAllText(sb.ToString(), input);
        }

        public void HintChanged(string input)
      {
            if (input.ToLower().Contains("note"))
            {
                //Collection.Add(new Result("Добавить запись","",""));
            }
        }

        //public event Action<IEnumerable<Result>> Response;
    }
}