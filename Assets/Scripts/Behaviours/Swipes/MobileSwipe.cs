using UnityEngine;

namespace Behaviours
{
    class MobileSwipe : SwipeDetection
    {
        public override void UpdateControls()
        {
            if (IsTouchingScreeen())
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    _isSwiping = true;
                    _tapPosition = Input.GetTouch(0).position;
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Canceled ||
                    Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    ResetSwipe();
                }
            }

            base.UpdateControls();
        }
        protected override void CheckSwipe()
        {
            _swipeDelta = Vector2.zero;
            if (_isSwiping)
            {
                _swipeDelta = (Vector2)Input.GetTouch(0).position - _tapPosition;
            }
            base.CheckSwipe();
        }
    }
}
