using UnityEngine;
using Helpers.Singleton;

namespace Controllers
{
    class TimeController : PersistanceSingleton<TimeController>
    {
        private const float DEFAULT_PAUSE_TIME_VALUE = 0f;
        private const float DEFAULT_NORMAL_TIME_VALUE = 1f;
        public void PauseTime()
        {
            Time.timeScale = DEFAULT_PAUSE_TIME_VALUE;
        }
        public void ResumeTime()
        {
            Time.timeScale = DEFAULT_NORMAL_TIME_VALUE;
        }
    }
}
