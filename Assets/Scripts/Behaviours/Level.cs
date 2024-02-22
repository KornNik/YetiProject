using UnityEngine;

namespace Behaviours 
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _boundsParent;
        [SerializeField] private Snake _snake;
        [SerializeField] private YetiSpawner _yetiSpawner;

        public void LoadLevelObjects()
        {

        }
        public void DeleteLevelObjects()
        {
            Destroy(_boundsParent.gameObject);
            Destroy(_yetiSpawner.gameObject);
        }
    }
}
