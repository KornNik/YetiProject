using UnityEngine;
using Helpers.Extensions;
using Helpers.AssetsPath;
using Helpers.Services;
using Data;

namespace Controllers
{
    class CamerasInitializer
    {
        private CamerasData _camerasData;
        public void Initialization()
        {
            CamerasDataInitialization();
            MainCameraInitialization();
        }
        private void CamerasDataInitialization()
        {
            var dataResources = CustomResources.Load<CamerasData>(DatasAssetPath.DatasPath[Helpers.DataTypes.CameraData]);
            _camerasData = dataResources;
        }
        private void MainCameraInitialization()
        {
            var mainCameraResource = CustomResources.Load<Camera>(CamerasAssetPath.CamerasPath[Helpers.CameraTypes.MainCamera]);
            var mainCameraObject = Object.Instantiate(mainCameraResource, _camerasData.GetMainCameraPosition(), Quaternion.identity);
            Services.Instance.CameraService.SetObject(mainCameraObject);
        }
    }
}
