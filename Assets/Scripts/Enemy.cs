using UnityEngine;

namespace archero
{
    public class Enemy : MonoBehaviour
    {
        private Transform _playerTransform;
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _rotationLerpRate = 3f;

        private float _attackTimer;
        [SerializeField] private float _attackPeriod = 1f;
        [SerializeField] private float _dps;

        private PlayerHealth _playerHealth;

        [SerializeField] private float _health = 50f;
        [SerializeField] private GameObject _dieParticles;

        private EnemyManager _enemyManager;

        private void Start()
        {
        }

        public void Init(Transform playerTransform, EnemyManager enemyManager)
        {
            _playerTransform = playerTransform;
            _enemyManager = enemyManager;
        }


        private void Update()
        {
            if (_playerHealth)
            {
                _attackTimer += Time.deltaTime;
                if (_attackTimer > _attackPeriod)
                {
                    _playerHealth.TakeDamage(_dps * _attackPeriod);
                    _attackTimer = 0f;
                }
            }
        }

        private void FixedUpdate()
        {
            if (_playerTransform != null)
            {
                Vector3 toPlayer = _playerTransform.position - transform.position;
                Quaternion toPlayerRotation = Quaternion.LookRotation(toPlayer, Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation, toPlayerRotation, Time.deltaTime * _rotationLerpRate);
                _rigidbody.velocity = transform.forward * _speed;

                if (toPlayer.magnitude > 32f)
                {
                    transform.position += toPlayer * 1.95f;
                }

            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerHealth>() is PlayerHealth playerHealth)
            {
                _playerHealth = playerHealth;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<PlayerHealth>())
            {
                _playerHealth = null;
            }
        }

        public void SetDamage(float value)
        {
            _health -= value;
            if (_health <= 0)
            {
                Die();
            }

        }

        private void Die()
        {
            Instantiate(_dieParticles, transform.position, Quaternion.identity);
            _enemyManager.RemoveEnemy(this);
            Destroy(gameObject);
        }
    }
}
