using System;
using System.Drawing;
using System.Reflection;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Support
{
    public class Result
    {
        private readonly string _name;
        private readonly string _command;
        private readonly string _shortcut;
        private readonly ImageSource _image;
        private readonly Action<Result> _function; 

        /// <summary>Gets the display nome of the search result</summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>Gets the search result's actual command</summary>
        public string Command
        {
            get { return _command; }
        }

        /// <summary>Gets the filename of the shortcut on disk this result was read from</summary>
        public string Shortcut
        {
            get { return _shortcut; }
        }

        /// <summary>Gets a WPF TmageSource for the icon to display for the search result</summary>
        public ImageSource Image
        {
            get { return _image; }
        }

        public void Execute()
        {
            _function(this);
        }

        public Result(string name, string command, string shortcut, Action<Result> function)
        {
            _name = name;
            _command = command;
            _shortcut = shortcut;
            _function = function;
            if (!string.IsNullOrEmpty(_command))
            {
                _image = ToImageSource(Icon.ExtractAssociatedIcon(_command));    
            }
            
        }

        public override string ToString()
        {
            return _name;
        }

        private static ImageSource ToImageSource(Icon icon)
        {
            ImageSource imageSource = Imaging.CreateBitmapSourceFromHIcon(
                icon.Handle,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());

            return imageSource;
        }
    }
}