using testAbdrahmanov.Envieronment;
using UnityEngine;
using UnityEngine.UI;

namespace testAbdrahmanov.Visuals.UI
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private LoadingActionZone _loadingActionZone;
        [SerializeField] private Image _filler;

        private void Awake()
        {
            gameObject.SetActive(false);
            Subscribe();
        }

        private void Update()
        {
            _filler.fillAmount = _loadingActionZone.Progress;
        }

        private void Show()
        {
            gameObject.SetActive(true);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }


        private void Subscribe()
        {
            _loadingActionZone.Started += Show;
            _loadingActionZone.Finished += Hide;
            _loadingActionZone.Failed += Hide;
        }

        private void Unsubscribe()
        {
            _loadingActionZone.Started -= Show;
            _loadingActionZone.Finished -= Hide;
            _loadingActionZone.Failed -= Hide;
        }
        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            Unsubscribe();
        }
    }
}
