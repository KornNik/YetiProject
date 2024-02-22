using UnityEngine;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Helpers.PoolObjects
{
    abstract class PoolObjects <T>
    {
        protected Dictionary<T, HashSet<IPoolable>> _objectPool;
        protected readonly int _capacityPool;
        protected readonly Transform _poolTransform;

        public PoolObjects(int capacityPool, Transform poolTransform)
        {
            _capacityPool = capacityPool;
            _poolTransform = poolTransform;
        }

        public abstract IPoolable GetObject();

        protected virtual void ReturnToPool(Transform transform)
        {
            transform.SetParent(_poolTransform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
        }
        protected void RemovePool()
        {
            Object.Destroy(_poolTransform.gameObject);
        }
        protected HashSet<IPoolable> GetListObject(T type)
        {
            return _objectPool.ContainsKey(type) ? _objectPool[type] : _objectPool[type] = new HashSet<IPoolable>();
        }
    }
}
