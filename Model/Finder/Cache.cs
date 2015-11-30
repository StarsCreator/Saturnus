using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.IO;
using Support;

namespace Model.Finder
{
    public class Cache : INotifyPropertyChanged
    {
        // the search hint
        private string _hint;
        // list of cached items that are able be found by the search
        private readonly List<Result> _cachedItems;
        // collection of results that match the search hint
        private readonly AsyncObservableCollection<Result> _results;

        public Cache()
        {
            _cachedItems = new List<Result>();
            _results = new AsyncObservableCollection<Result>();

            // load start menu items
            //LoadStartMenu(Environment.GetFolderPath(Environment.SpecialFolder.StartMenu));
            LoadStartMenu(@"C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs");
            //LoadStartMenu(Environment.GetEnvironmentVariable("ALLUSERSPROFILE") + @"\Start Menu");
            //LoadStartMenu(@"c:\Work");
            // A default hint. Not really necessary but can be handy during testing.
            //_hint = "Calc";
        }

        public string Hint
        {
            get { return _hint; }
            set
            {
                _hint = value;
                _results.Clear();
                if (_hint.Length > 0)
                {
                    foreach (
                        var sr in
                            _cachedItems.Where(sr => string.Compare(_hint, 0, sr.Name, 0, _hint.Length, true) == 0))
                    {
                        _results.Add(sr);
                    }
                }

                OnPropertyChanged(new PropertyChangedEventArgs("Hint"));
            }
        }

        public ReadOnlyObservableCollection<Result> Results
        {
            get { return new ReadOnlyObservableCollection<Result>(_results); }
        }

        private void LoadStartMenu(string path)
        {
            //var dir = new DirectoryInfo(path);
            //foreach (var file in dir.GetFileSystemInfos())
            //    Console.WriteLine(file.FullName);
            //foreach (var pat in dir.GetDirectories()
            //    .Where(d => !d.Attributes.HasFlag(FileAttributes.NotContentIndexed)))
            //{
            //    foreach (var directoryInfo in pat.GetDirectories())
            //    {
            //        LoadStartMenu(directoryInfo.FullName);
            //    }
            //}

            var shell = new IWshRuntimeLibrary.WshShell();

            try
            {
                //var files = Directory.GetFiles(path);

                foreach (var file in Directory.GetFiles(path))
                {
                    var fileinfo = new FileInfo(file);

                    if (fileinfo.Extension.ToLower() != ".lnk") continue;
                    var link = shell.CreateShortcut(file) as IWshRuntimeLibrary.WshShortcut;
                    var sr = new Result(fileinfo.Name.Substring(0, fileinfo.Name.Length - 4),
                        link.TargetPath, file);
                    _cachedItems.Add(sr);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                foreach (var dir in Directory.GetDirectories(path))
                {
                    LoadStartMenu(dir);
                }
            }
        }

        #region INotifyPropertyChaned

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var h = PropertyChanged;
            if (h != null)
                h(this, e);
        }

        #endregion
    }
}