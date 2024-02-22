using UnityEngine;
using Behaviours;

namespace Data
{
    [CreateAssetMenu(fileName ="LevelData",menuName ="Data/Level/LevelData")]
    class LevelData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Level _levelPrefab;
        [SerializeField] private Vector3 _levelPosition;

        public string GetName()
        {
            return _name;
        }
        public Level GetPrefab()
        {
            return _levelPrefab;
        }
        public Vector3 GetLevelPosition()
        {
            return _levelPosition;
        }
    }
}
