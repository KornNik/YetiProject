using UnityEngine;
using Behaviours;

namespace Inputs
{
    class BaseInputs : MonoBehaviour
    {
        private SwipeDetection _swipe;

        public SwipeDetection SwipeDetection => _swipe;

        private void Awake()
        {
            Initialization();
        }
        private void Update()
        {
            _swipe.UpdateControls();
        }

        public void Initialization()
        {
            if (Application.isMobilePlatform)
            {
                _swipe = new MobileSwipe();
            }
            else
            {
                _swipe = new PCSwipe();
            }
        }
    }
}
