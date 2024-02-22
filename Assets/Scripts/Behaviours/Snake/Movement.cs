using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controllers;
using Helpers.Observer;

namespace Behaviours
{
    class Movement : IMovable, IEventListener<SnakeEvent>
    {
        private Rigidbody2D _rigidbody;
        private GameObject _snakeGameObject;
        private WaitForSeconds _waitForMove;
        private Vector2 _directionMovement = Vector2.right;
        private IEnumerator _coroutine;
        private List<Transform> _segments;

        public Movement(Rigidbody2D rigidbody, GameObject snakeGameObject, List<Transform> segments)
        {
            _rigidbody = rigidbody;
            _snakeGameObject = snakeGameObject;
            _waitForMove = new WaitForSeconds(0.3f);
            _segments = segments;
            this.EventStartListening();
        }
        ~Movement()
        {
            this.EventStopListening();
        }
        public void ChangeDirection(Vector2 newDirection)
        {
            _directionMovement = newDirection;
        }
        public void StartMoving()
        {
            _coroutine = MovementCoroutine();
            CoroutineController.GetInstance().AddCoroutine(_coroutine);
        }
        public void StopMoving()
        {
            if (!ReferenceEquals(_coroutine, null))
            {
                CoroutineController.GetInstance().RemoveCoroutine(_coroutine);
            }
        }
        public void Move(Vector2 movement)
        {
            for (int i = _segments.Count - 1; i > 0; i--)
            {
                _segments[i].position = _segments[i - 1].position;
            }
            var nextPosition = RoundedPosition(_rigidbody.position + movement);
            _rigidbody.MovePosition(nextPosition);
        }
        private Vector2 RoundedPosition(Vector2 position)
        {
            Vector2 roundedPosition;
            roundedPosition = new Vector2(Mathf.Round(position.x), Mathf.Round(position.y));

            return roundedPosition;
        }
        public IEnumerator MovementCoroutine()
        {
            while (_snakeGameObject.activeInHierarchy)
            {
                yield return _waitForMove;
                Move(_directionMovement);
            }
            CoroutineController.GetInstance().RemoveCoroutine(_coroutine);
            yield return null;
        }

        public void OnEventTrigger(SnakeEvent eventType)
        {
            if (eventType.IsDead)
            {
                StopMoving();
            }
        }
    }
}
