namespace Helpers.Observer
{
    interface ISubject<T>
    {
        void Attach(IObserver<T> observer);
        void UnAttach(IObserver<T> observer);
        void Notify(T info);
    }
}
