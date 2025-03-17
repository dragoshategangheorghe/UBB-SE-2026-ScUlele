using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace BankApp.Client.Utilities
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private readonly SynchronizationContext? _synchronizationContext;
        protected BaseViewModel()
        {
            // TODO: implement base view model logic
            ;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            // TODO: implement set property logic
            return default !;
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            // TODO: implement on property logic
            ;
        }

        protected void SetState<T>(Observable<T> observable, T value)
        {
            // TODO: implement set state logic
            ;
        }

        protected void RunOnUiThread(Action action)
        {
            // TODO: implement run on ui thread logic
            ;
        }

        public abstract void Dispose();
    }
}