using System;
using _Assets.Scripts.MVVM.Commands;
using _Assets.Scripts.MVVM.Models;
using VContainer.Unity;

namespace _Assets.Scripts.MVVM.ViewModels
{
    public class HealthViewModel : IInitializable, IDisposable
    {
        private HealthModel _model;
        public ICommand IncreaseHealthCommand;
        public ICommand DecreaseHealthCommand;
        public event Action<int> OnHealthChanged;

        public int Health => _model.Health;

        private void HealthChanged(int health) => OnHealthChanged?.Invoke(health);

        public void Initialize()
        {
            _model = new HealthModel(100, 100);
            _model.OnHealthChanged += HealthChanged;
            IncreaseHealthCommand = new IncreaseHealthCommand(_model);
            DecreaseHealthCommand = new DecreaseHealthCommand(_model);
        }

        public void Dispose() => _model.OnHealthChanged -= HealthChanged;
    }
}