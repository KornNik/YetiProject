using UnityEngine;
using Helpers.PoolObjects;

namespace Behaviours
{
    class Segment : MonoBehaviour, IPoolable
    {
        protected Transform _poolTransform;

        public Transform PoolTransform { get => _poolTransform; set => _poolTransform = value; }
        public GameObject PoolableObject { get => gameObject; set => PoolableObject.SetActive(value); }

        public void ReturnToPool()
        {
            transform.SetParent(PoolTransform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            PoolableObject.SetActive(false);

            if (!PoolTransform)
            {
                Destroy(gameObject);
            }
        }

        public void ActiveObject()
        {
            gameObject.SetActive(true);
            transform.SetParent(null);
        }
    }
}
