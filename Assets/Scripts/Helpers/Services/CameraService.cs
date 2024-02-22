using UnityEngine;

namespace Helpers.Services
{
    class CameraService : Service<Camera>
    {
        private Camera _uiCamera;

        public void SetUICamera(Camera uiCamera)
        {
            _uiCamera = uiCamera;
        }
        public Camera GetUICamera()
        {
            return _uiCamera;
        }
    }
}
