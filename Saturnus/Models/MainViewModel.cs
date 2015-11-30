using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using CollectionMtLib;
using Support;

namespace Saturnus.Models
{
    public class MainViewModel:INotifyPropertyChanged
    {
        private bool _isOpen; 
        private string _hint;
        private Result _selectedResult;
        private readonly PluginHost _pluginHost;
        private readonly CollectionMtWithAsyncObservableCollectionReadOnlyCopy<Result> _results;

        private ICommand enterKeyCommand;

        public MainViewModel()
        {
            _results = new CollectionMtWithAsyncObservableCollectionReadOnlyCopy<Result>();
            _results.OnMtCollectionChanged += _results_OnMtCollectionChanged;

            _pluginHost = new PluginHost();
            //TODO: add path to string
            _pluginHost.LoadPlugins(Application.StartupPath);
            _pluginHost.RegisterPlugins(_results);
        }

        void _results_OnMtCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.Action == NotifyCollectionChangedAction.Add)
            {
                IsOpen = true;
            }
        }

        public string Hint
        {
            get { return _hint;}
            set
            {
                _hint = value;
                _results.Clear();
                if (_hint.Length == 0)
                {
                    IsOpen = false;
                    return;
                }
                foreach (var plugin in _pluginHost.Plugins)
                {
                    Task.Factory.StartNew(() => plugin.HintChanged(_hint));
                }
                
                GC.Collect();
            }
        }

        public IEnumerable<Result> Results
        {
            get { return _results; }
        }

        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }
            set
            {
                if (_isOpen == value) return;
                _isOpen = value;
                OnPropertyChanged("IsOpen");
            }
        }

        public Result SelectedResult
        {
            set { _selectedResult = value; }
        }

        public ICommand EnterKeyCommand
        {
            get
            {
                return new DelegateCommand
                {
                    //CanExecuteFunc = () => Application.Current.MainWindow == null,
                    CommandAction = () =>
                    {
                        _selectedResult.Execute();
                    }
                };
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
#endregion
    }
}