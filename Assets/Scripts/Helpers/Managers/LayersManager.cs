using UnityEngine;

namespace Helpers.Managers
{
    static class LayersManager
    {
        #region Fields

        public const string UI = "UI";
        public const string DEFAULT = "Default";
        public const string GROUND = "Ground";

        public const int DEFAULT_LAYER = 0;

        #endregion


        #region Proeprties

        public static int DefaultLayer { get; }
        public static int UiLayer { get; }
        public static int Ground { get; }

        #endregion


        #region Class lifecycle

        static LayersManager()
        {
            DefaultLayer = LayerMask.GetMask(DEFAULT);
            UiLayer = LayerMask.GetMask(UI);
            Ground = LayerMask.GetMask(GROUND);
        }

        #endregion
    }
}
