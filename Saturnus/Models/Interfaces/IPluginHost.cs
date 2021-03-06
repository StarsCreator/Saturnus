﻿using System.Collections.Generic;
using CollectionMtLib;
using Support;
using Support.Interfaces;

namespace Saturnus.Models.Interfaces
{
    public interface IPluginHost
    {
        void LoadPlugins(string path);
        void RegisterPlugins(CollectionMtWithAsyncObservableCollectionReadOnlyCopy<Result> results );

        IEnumerable<IPlugin> Plugins { get; }

        void RemovePlugins(IPlugin plugin);
    }
}