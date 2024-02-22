using System;

namespace Helpers.Services
{
    abstract class Service<T>
    {
        public event Action ObjectIsLoaded;

        private T _servicesObject;
        public T ServicesObject => _servicesObject;

        public Service()
        {

        }
        ~Service()
        {

        }

        public virtual void SetObject(T servicesObject)
        {
            _servicesObject = servicesObject;
            ObjectIsLoaded?.Invoke();
        }
    }
}
