namespace Helpers.Observer
{
    interface IObserver<T>
    {
        void UpdateObserver(T info);
    }
}
