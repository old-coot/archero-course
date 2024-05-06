using UnityEngine;

namespace archero
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _rotationLerpRate = 3f;

        private float _attackTimer;
        [SerializeField] private float _attackPeriod = 1f;
        [SerializeField] private float _dps;

        private PlayerHealth _playerHealth;


        private void Start()
        {
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

    }
}
