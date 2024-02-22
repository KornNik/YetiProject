using UnityEngine;

namespace Behaviours
{
    abstract class SwipeDetection
    {
        public static event OnSwipeInput SwipeEvent;
        public delegate void OnSwipeInput(Vector2 swipe);

        protected Vector2 _tapPosition;
        protected Vector2 _swipeDelta;

        protected float _deadZone = 50f;
        protected bool _isSwiping;

        public SwipeDetection()
        {
            Initilize();
        }

        protected virtual void Initilize()
        {

        }

        public virtual void UpdateControls()
        {
            CheckSwipe();
        }
        protected virtual bool IsTouchingScreeen()
        {
            if (Input.touchCount != 0)
            {
                return true;
            }
            else { return false; }
        }
        protected virtual void CheckSwipe()
        {
            if (_swipeDelta.magnitude > _deadZone)
            {
                if (SwipeEvent != null)
                {
                    if (Mathf.Abs(_swipeDelta.x) > Mathf.Abs(_swipeDelta.y))
                    {
                        SwipeEvent(_swipeDelta.x > 0 ? Vector2.right : Vector2.left);
                    }
                    else
                    {
                        SwipeEvent(_swipeDelta.y > 0 ? Vector2.up : Vector2.down);
                    }
                }
                ResetSwipe();
            }
        }
        protected virtual void ResetSwipe()
        {
            _isSwiping = false;
            _tapPosition = Vector2.zero;
            _swipeDelta = Vector2.zero;
        }
    }
}
