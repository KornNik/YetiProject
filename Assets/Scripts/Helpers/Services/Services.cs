using System;

namespace Helpers.Services
{
    sealed class Services
    {
        private static readonly Lazy<Services> _instance = new Lazy<Services>();

        public static Services Instance => _instance.Value;
        public CameraService CameraService { get; private set; }
        public LevelService LevelService { get; private set; }

        public Services()
        {
            Initialize();
        }

        private void Initialize()
        {
            CameraService = new CameraService();
            LevelService = new LevelService();
        }
    }
}
