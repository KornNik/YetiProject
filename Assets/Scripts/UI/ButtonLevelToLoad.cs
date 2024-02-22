using UnityEngine;
using Controllers;
using Data;

namespace GameUI
{
    class ButtonLevelToLoad : MonoBehaviour
    {
        [SerializeField] private LevelData _levelData;

        public void LoadLevel()
        {
            Debug.Log("Loaded");
            LevelController.GetInstance().LoadLevel(_levelData);
        }
    }
}
