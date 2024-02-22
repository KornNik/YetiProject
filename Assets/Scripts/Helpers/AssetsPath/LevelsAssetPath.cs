using System.Collections.Generic;
using Helpers.Extensions;

namespace Helpers.AssetsPath
{
    sealed class LevelsAssetPath
    {
        public static readonly Dictionary<LevelTypes, string> LevelsPath = new Dictionary<LevelTypes, string>
        {
            {
                LevelTypes.First, StringBuilderExtender.CreateString
                (ResourcesPathManager.LEVEL_FOLDER,ResourcesPathManager.LEVEL_FIRST_NAME)
            }
        };
    }
}