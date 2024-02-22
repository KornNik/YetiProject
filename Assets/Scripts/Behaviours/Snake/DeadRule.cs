using UnityEngine;
using Helpers.Observer;

namespace Behaviours
{
    class DeadRule
    {
        [SerializeField] private Snake _snake;

        private bool _isDead;

        public DeadRule(Snake snake)
        {
            _isDead = false;
            _snake = snake;
        }

        public void Dead()
        {
            _snake.gameObject.SetActive(false);
            _isDead = true;
            SnakeEvent.Trigger(true);
        }
        public bool GetStatus()
        {
            return _isDead;
        }
    }
}
