using UnityEngine;
using UnityEngine.UI;

namespace archero
{
    public class PlayerHealthBar : MonoBehaviour
    {
        [SerializeField] private Image _scale;
        [SerializeField] private PlayerHealth _playerHealth;

        private void Awake()
        {
            _playerHealth.OnHealthChange += SetScale;
        }

        public void SetScale(float currentHealth, float maxHealth)
        {
            _scale.fillAmount = currentHealth / maxHealth;
        }
    }
}
