using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Support;

namespace Search
{
    public class Cache
    {
        private readonly List<Result> _cachedItems;

        public Cache()
        {
            _cachedItems = new List<Result>();
            LoadStartMenu(@"C:\\ProgramData\\Microsoft\\Windows\\Start Menu\\Programs");
        }

        public IEnumerable<Result> CachedResults
        {
            get { return _cachedItems; }
        }        

        private void LoadStartMenu(string path)
        {
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
                        link.TargetPath, file,Execute);
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

        private void Execute(Result res)
        {
            System.Diagnostics.Process.Start(res.Command);
        }

    }
}