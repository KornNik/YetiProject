using UnityEngine;

namespace Behaviours 
{
    [RequireComponent(typeof(Collider2D))]
    class Bound : MonoBehaviour, IInteractor
    {
        [SerializeField] private Collider2D _collider;

        private void Awake()
        {
            if (ReferenceEquals(_collider, null))
            {
                _collider = GetComponent<Collider2D>();
            }
        }

        public void Interacte(IInteractable interactable)
        {
            interactable.Interacted();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var interactable = collision.GetComponent<IInteractable>();
            var snake = interactable as Snake;
            if (snake)
            {
                Interacte(snake);
            }
        }
    }
}
