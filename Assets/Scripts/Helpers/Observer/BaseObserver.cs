namespace Helpers.Observer
{
    abstract class BaseObserver<T> : IObserver<T>
    {
        private ISubject<T> _subject;

        public BaseObserver(ISubject<T> subject)
        {
            _subject.Attach(this);
        }
        ~BaseObserver()
        {
            _subject.UnAttach(this);
        }

        public abstract void UpdateObserver(T info);
    }
}
