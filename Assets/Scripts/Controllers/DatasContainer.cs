using Helpers.Singleton;
using Data;
using Helpers.Extensions;
using Helpers.AssetsPath;

namespace Controllers
{
    class DatasContainer : PersistanceSingleton<DatasContainer>
    {
        private LevelsBundle _levelsBundle;
        private void Awake()
        {
            _levelsBundle = CustomResources.Load<LevelsBundle>(DatasAssetPath.DatasPath[Helpers.DataTypes.LevelData]);
        }

        public LevelsBundle GetLevelsBundle()
        {
            return _levelsBundle;
        }
    }
}
