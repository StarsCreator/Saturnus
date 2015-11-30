using System;
using System.Collections.Generic;
using CollectionMtLib;

namespace Support.Interfaces
{
    public interface IPlugin
    {
        #region Info

        string PluginName { get; } // имя плагина
        string DisplayPluginName { get; } // имя плагина, которое отображается
        string PluginDescription { get; } // описание плагина
        string Author { get; } // имя автора
        Version Version { get; } // версия

        #endregion

        CollectionMtWithAsyncObservableCollectionReadOnlyCopy<Result> Collection { set; }  //?
        void HintChanged(string input);
        //event Action<IEnumerable<Result>> Response;
    }
}