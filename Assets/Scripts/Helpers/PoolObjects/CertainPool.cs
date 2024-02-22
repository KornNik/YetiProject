using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Object = UnityEngine.Object;

namespace Helpers.PoolObjects
{
    sealed class CertainPool<T> : PoolObjects<T> where T : MonoBehaviour, IPoolable
    {
        private T _poolObject;

        public CertainPool(int capacityPool, Transform poolTransform, T poolObject) : base(capacityPool, poolTransform)
        {
            _objectPool = new Dictionary<T, HashSet<IPoolable>>();
            _poolObject = poolObject;
        }

        public override IPoolable GetObject()
        {
            IPoolable result;
            result = GetAllObjects(GetListObject(_poolObject));
            return result;
        }

        private IPoolable GetAllObjects(HashSet<IPoolable> poolables)
        {
            var ammunition = poolables.FirstOrDefault(a => !a.PoolableObject.activeSelf);
            if (ammunition == null)
            {
                var poolable = _poolObject;
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(poolable);
                    ReturnToPool(instantiate.transform);
                    instantiate.PoolTransform = _poolTransform;
                    poolables.Add(instantiate);
                }

                GetAllObjects(poolables);
            }
            ammunition = poolables.FirstOrDefault(a => !a.PoolableObject.activeSelf);
            return ammunition;
        }
    }
}
