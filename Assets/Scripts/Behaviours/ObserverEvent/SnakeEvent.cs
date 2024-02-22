namespace Helpers.Observer
{
    struct SnakeEvent
    {
        private static SnakeEvent _loadingEvent;

        private bool _isDead;

        public SnakeEvent(bool isDead)
        {
            _isDead = isDead;
        }

        public bool IsDead => _isDead;

        public static void Trigger(bool isDead)
        {
            _loadingEvent._isDead = isDead;
            EventManager.TriggerEvent(_loadingEvent);
        }
    }
}

