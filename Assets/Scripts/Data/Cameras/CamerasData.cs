using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CameraData", menuName = "Data/Camera/CameraData")]
    class CamerasData : ScriptableObject
    {
        [SerializeField] private Vector3 _mainCameraPosition;

        public Vector3 GetMainCameraPosition()
        {
            return _mainCameraPosition;
        }
    }
}
