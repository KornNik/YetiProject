using UnityEngine;

namespace Helpers.PoolObjects
{
    interface IPoolable
    {
        Transform PoolTransform { get; set; }
        GameObject PoolableObject { get; set; }
        void ReturnToPool();
        void ActiveObject();
    }
}
