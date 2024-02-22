using System.Collections.Generic;

namespace Helpers.Observer
{
    abstract class BaseSubject<T> : ISubject<T>
    {
        private List<IObserver<T>> _observers;

        public BaseSubject()
        {
            _observers = new List<IObserver<T>>();
        }

        public void Attach(IObserver<T> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }
        public void UnAttach(IObserver<T> observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
            }
        }

        public void Notify(T updateInfo)
        {
            for (int i = 0; i < _observers.Count; i++)
            {
                _observers[i].UpdateObserver(updateInfo);
            }
        }
    }
}
