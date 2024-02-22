using UnityEngine;
using TMPro;

namespace GameUI 
{
    public class BoardSlot : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _score;

        public void FillSlot(string name, string score)
        {
            ClearSlot();
            _name.text = name;
            _score.text = score;
        }
        private void ClearSlot()
        {
            _name.text = null;
            _score.text = null;
        }
    }
}
