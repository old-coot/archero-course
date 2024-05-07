using UnityEngine;

namespace archero
{

    [CreateAssetMenu(fileName = nameof(ShadowMisslesEffect), menuName = "Effects/ContinuousEffect/" + nameof(ShadowMisslesEffect))]
    public class ShadowMisslesEffect : ContinuousEffect
    {
        [Space(10)]

        [SerializeField] private ShadowMissle _shadowMissilePrefab;
        [SerializeField] private float _bulletSpeed;
        protected override void Produce()
        {
            base.Produce();

            Transform playerTransform = _player.transform;
            int number = 5;

            for (int i = 0; i < number; i++)
            {
                float angle = (360f / number) * i;
                Vector3 direction = Quaternion.Euler(0, angle, 0) * playerTransform.forward;
                ShadowMissle newBullet = Instantiate(_shadowMissilePrefab, playerTransform.position, Quaternion.identity);
                newBullet.Setup(direction * _bulletSpeed, 20, 2);
            }

        }
    }
}
