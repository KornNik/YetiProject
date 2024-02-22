using System;
using UnityEngine;
using Helpers.PoolObjects;
using Helpers.Observer;

namespace Behaviours
{
    [RequireComponent(typeof(Collider2D))]
    class Collectable : MonoBehaviour, IInteractable, IPoolable
    {
        [SerializeField] private Collider2D _collider;
        [SerializeField, Range(0, 10)] private int _scoreNumber = 1;
        [SerializeField] private float yRandomSpawn;
        [SerializeField] private float xRandomSpawn;

        protected Transform _poolTransform;

        public Transform PoolTransform { get => _poolTransform; set => _poolTransform = value; }
        public GameObject PoolableObject { get => gameObject; set => PoolableObject.SetActive(value); }

        private void Awake()
        {
            if (ReferenceEquals(_collider, null))
            {
                _collider.GetComponent<Collider2D>();
            }
        }

        public void Interacted()
        {
            ReturnToPool();
            CollectableEvent.Trigger(_scoreNumber);
        }
        private void SetRandomSpawn()
        {
            Vector2 randomVector = Helpers.Extensions.MathExtender.CalculateCoordinatesRounded(yRandomSpawn, xRandomSpawn);
            Vector3 newPosition = new Vector3(randomVector.x,randomVector.y, 1f);
            transform.position = newPosition;
        }

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
            SetRandomSpawn();
        }
    }
}
