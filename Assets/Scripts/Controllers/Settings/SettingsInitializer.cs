using UnityEngine;

namespace Controllers
{
    class SettingsInitializer
    {
        private const bool DEFAULT_CURSOR_STATE = true;
        private const CursorLockMode DEFAULT_CURSOR_LOCK_MODE = CursorLockMode.Confined;
        private const int DEFAULT_VSYNC_COUNT = 1;

        public void Initialization()
        {
            Cursor.lockState = DEFAULT_CURSOR_LOCK_MODE;
            Cursor.visible = DEFAULT_CURSOR_STATE;
            QualitySettings.vSyncCount = DEFAULT_VSYNC_COUNT;
        }
    }
}
