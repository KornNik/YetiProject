namespace Helpers.Observer
{
    struct CollectableEvent
    {
        private static CollectableEvent _loadingEvent;

        private int _score;

        public CollectableEvent(int score)
        {
            _score = score;
        }

        public int Score => _score;

        public static void Trigger(int score)
        {
            _loadingEvent._score = score;
            EventManager.TriggerEvent(_loadingEvent);
        }
    }
}
