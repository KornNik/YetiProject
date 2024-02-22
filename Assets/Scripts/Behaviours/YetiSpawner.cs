using UnityEngine;
using Helpers.PoolObjects;
using Helpers.Observer;

namespace Behaviours
{
    class YetiSpawner : MonoBehaviour, IEventListener<CollectableEvent>,IEventListener<SnakeEvent>
    {
        [SerializeField] private Collectable _prefabsCollectable;
        [SerializeField, Range(1, 5)] private int _poolCapacity;

        private CertainPool<Collectable> _collectablesPool;
        private Collectable _currentCollectable;

        private void OnEnable()
        {
            this.EventStartListening<CollectableEvent>();
            this.EventStartListening<SnakeEvent>();
        }
        private void OnDisable()
        {
            this.EventStopListening<CollectableEvent>();
            this.EventStopListening<SnakeEvent>();
        }

        private void Awake()
        {
            _collectablesPool = new CertainPool<Collectable>(_poolCapacity, transform, _prefabsCollectable);
            GetProjectile();
        }

        public void GetProjectile()
        {
            _currentCollectable = _collectablesPool.GetObject() as Collectable;
            if (_currentCollectable is Collectable)
            {
                _currentCollectable.ActiveObject();
            }
        }

        public void OnEventTrigger(CollectableEvent eventType)
        {
            GetProjectile();
        }

        public void OnEventTrigger(SnakeEvent eventType)
        {
            _currentCollectable.ReturnToPool();
        }
    }
}
