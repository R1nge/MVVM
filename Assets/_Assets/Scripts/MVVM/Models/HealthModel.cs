using System;

namespace _Assets.Scripts.MVVM.Models
{
    [Serializable]
    public class HealthModel
    {

        public HealthModel(int health, int maxHealth)
        {
            _health = health;
            _maxHealth = maxHealth;
        } 
        
        private int _health;

        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                OnHealthChanged?.Invoke(_health);
            }
        }

        public event Action<int> OnHealthChanged;

        private int _maxHealth;

        public int MaxHealth
        {
            get => _maxHealth;
            set
            {
                _maxHealth = value;
                OnMaxHealthChanged?.Invoke(_maxHealth);
            }
        }

        public event Action<int> OnMaxHealthChanged;

        public void DecreaseHealth(int amount)
        {
            Health -= amount;
        }

        public void IncreaseHealth(int amount)
        {
            Health += amount;
        }
    }
}