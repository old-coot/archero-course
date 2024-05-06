using UnityEngine;

namespace archero
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float _speed;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _rotationLerpRate = 3f;

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
    }
}
