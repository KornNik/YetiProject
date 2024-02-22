using System.Collections.Generic;
using Helpers.Extensions;

namespace Helpers.AssetsPath
{
    sealed class DatasAssetPath
    {
        public static Dictionary<DataTypes, string> DatasPath = new Dictionary<DataTypes, string>
        {
            {
                DataTypes.LevelData, StringBuilderExtender.CreateString
                (ResourcesPathManager.DATA_LEVEL_FOLDER,ResourcesPathManager.DATA_LEVEL_NAME) 
            },
            {
                DataTypes.CameraData,StringBuilderExtender.CreateString
                (ResourcesPathManager.DATA_CAMERA_FOLDER,ResourcesPathManager.DATA_CAMERA_NAME)
            }
        };
    }
}