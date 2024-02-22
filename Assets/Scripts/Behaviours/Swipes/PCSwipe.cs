using UnityEngine;

namespace Behaviours
{
    class PCSwipe : SwipeDetection
    {
        public override void UpdateControls()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isSwiping = true;
                _tapPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                ResetSwipe();
            }
            base.UpdateControls();
        }
        protected override void CheckSwipe()
        {
            _swipeDelta = Vector2.zero;
            if (_isSwiping)
            {
                _swipeDelta = (Vector2)Input.mousePosition - _tapPosition;
            }
            base.CheckSwipe();
        }
    }
}
