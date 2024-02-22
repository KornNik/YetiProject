using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Helpers.Singleton;
using Helpers.Extensions;

namespace Controllers
{
    class CoroutineController : PersistanceSingleton<CoroutineController>
    {
        [SerializeField, ReadOnly] private Dictionary<IEnumerator, Coroutine> _coroutines;

        private void Awake()
        {
            _coroutines = new Dictionary<IEnumerator, Coroutine>();
        }
        private void OnDisable()
        {
            RemoveAllCoroutines();
        }
        public void AddCoroutine(IEnumerator routine)
        {
            if (!_coroutines.ContainsKey(routine))
            {
                _coroutines.Add(routine, StartCoroutine(routine));
            }
        }
        public void RemoveCoroutine(IEnumerator routine)
        {
            if (_coroutines.ContainsKey(routine))
            {
                StopCoroutine(routine);
                _coroutines.Remove(routine);
            }
        }
        public void RemoveAllCoroutines()
        {
            StopAllCoroutines();
            _coroutines.Clear();
        }
    }
}
