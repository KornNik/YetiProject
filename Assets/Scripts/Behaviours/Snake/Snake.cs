using UnityEngine;
using Inputs;

namespace Behaviours
{
    [RequireComponent(typeof(Collider2D),typeof(Rigidbody2D),typeof(BaseInputs))]
    class Snake : MonoBehaviour, IInteractor, IInteractable
    {
        [SerializeField] private Collider2D _collider;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private BaseInputs _inputs;
        [SerializeField] private Segment _segmentPrefab;

        private IMovable _movement;
        private DeadRule _deadRule;
        private SegmentsRules _segmentsRule;

        private void Awake()
        {
            _segmentsRule = new SegmentsRules(_segmentPrefab, this);
            _movement = new Movement(_rigidbody, this.gameObject, _segmentsRule.Segments);
            _deadRule = new DeadRule(this);

            (_movement as Movement).StartMoving();
        }
        private void OnEnable()
        {
            SwipeDetection.SwipeEvent += OnSwipe;
        }
        private void OnDisable()
        {
            SwipeDetection.SwipeEvent -= OnSwipe;
        }

        public void OnSwipe(Vector2 movement)
        {
            (_movement as Movement).ChangeDirection(movement);
        }

        public void Interacte(IInteractable collectable)
        {
            collectable.Interacted();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var collectable = collision.gameObject.GetComponent<IInteractable>();

            if (collectable != null)
            {
                Interacte(collectable);
            }
        }

        public void Interacted()
        {
            _deadRule.Dead();
        }
    }
}
