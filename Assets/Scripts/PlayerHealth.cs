using System;
using UnityEngine;

namespace archero
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;
        private float _currenHealth;

        public event Action<float, float> OnHealthChange;
        public event Action OnDie;

        private void Start()
        {
            SetHealth(_maxHealth);
        }

        public void TakeDamage(float value)
        {
            float newHealth = _currenHealth - value;
            newHealth = Math.Max(newHealth, 0f);
            SetHealth(newHealth);
            if (newHealth == 0)
            {
                Die();
            }
        }

        private void SetHealth(float value)
        {
            _currenHealth = value;
            OnHealthChange?.Invoke(_currenHealth, _maxHealth);
        }

        private void Die()
        {
            OnDie?.Invoke();
            Debug.Log("Die");
        }
    }
}
