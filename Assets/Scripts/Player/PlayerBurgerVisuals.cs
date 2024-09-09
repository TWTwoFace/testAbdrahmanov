using UnityEngine;

namespace testAbdrahmanov.Visuals.Props
{
    public class PlayerBurgerVisuals : MonoBehaviour
    {
        [SerializeField] private GameObject _burger;

        private void Awake()
        {
            _burger.SetActive(false);
        }

        public void Show()
        {
            _burger.SetActive(true);
        }

        public void Hide()
        {
            _burger.SetActive(false);
        }
    }
}
