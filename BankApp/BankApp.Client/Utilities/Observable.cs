using System.Collections.Generic;

namespace BankApp.Client.Utilities
{
    public class Observable<T>
    {
        public T Value { get; private set; }

        private List<Observer<T>> _observers;
        public Observable(T value)
        {
            // TODO: implement observable logic
            ;
        }

        public void SetValue(T value)
        {
            // TODO: implement set value logic
            ;
        }

        public void AddObserver(Observer<T> observer)
        {
            // TODO: implement add observer logic
            ;
        }

        public void RemoveObserver(Observer<T> observer)
        {
            // TODO: implement remove observer logic
            ;
        }

        private void NotifyObservers()
        {
            // TODO: implement notify observers logic
            ;
        }
    }
}