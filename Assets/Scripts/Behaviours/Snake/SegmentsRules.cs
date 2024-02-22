using System.Collections.Generic;
using UnityEngine;
using Helpers.Observer;
using Helpers.PoolObjects;

namespace Behaviours
{
    class SegmentsRules : IEventListener<CollectableEvent>, IEventListener<SnakeEvent>
    {
        private const int POOL_CAPACITY = 10;

        private CertainPool<Segment> _collectablesPool;
        private List<Transform> _segments;
        private Segment _segmentPrefab;
        private Snake _snake;

        public SegmentsRules(Segment segmentPrefab,Snake snake)
        {
            _segments = new List<Transform>(5);
            _segmentPrefab = segmentPrefab;
            _snake = snake;
            _segments.Add(_snake.transform);
            _collectablesPool = new CertainPool<Segment>(POOL_CAPACITY, _snake.transform, _segmentPrefab);

            this.EventStartListening<CollectableEvent>();
            this.EventStartListening<SnakeEvent>();
        }
        ~SegmentsRules()
        {
            this.EventStopListening<CollectableEvent>();
            this.EventStopListening<SnakeEvent>();
        }

        public List<Transform> Segments => _segments;

        public void OnEventTrigger(CollectableEvent eventType)
        {
            AddSegment();
        }

        public void OnEventTrigger(SnakeEvent eventType)
        {
            ClearSegments();
        }

        private void AddSegment()
        {
            var newSegment = _collectablesPool.GetObject() as Segment;
            newSegment.ActiveObject();
            _segments.Add(newSegment.transform);
        }
        private void ClearSegments()
        {
            foreach (var item in _segments)
            {
                GameObject.Destroy(item.gameObject);
            }
            _segments.Clear();
        }
    }
}
