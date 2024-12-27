using _Assets.Scripts.MVVM.ViewModels;
using TMPro;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.MVVM.Views
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI health;
        [Inject] private HealthViewModel _healthViewModel;

        private void Awake()
        {
            _healthViewModel.OnHealthChanged += UpdateHealth;
            UpdateHealth(_healthViewModel.Health);
        }

        private void UpdateHealth(int health)
        {
            this.health.text = health.ToString();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _healthViewModel.DecreaseHealthCommand.Execute();
            }

            if (Input.GetMouseButtonDown(1))
            {
                _healthViewModel.IncreaseHealthCommand.Execute();
            }
        }
    }
}