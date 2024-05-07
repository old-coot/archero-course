using System.Collections;
using UnityEngine;

namespace archero
{
    [CreateAssetMenu(fileName = nameof(MagicMissleEffect), menuName = "Effects/ContinuousEffect/" + nameof(MagicMissleEffect))]
    public class MagicMissleEffect : ContinuousEffect
    {
        [SerializeField] private MagicMissle _magicMisslePrefab;
        [SerializeField] private float _bulletSpeed;


        protected override void Produce()
        {
            base.Produce();
            _effectsManager.StartCoroutine(Effectprocess());
        }

        private IEnumerator Effectprocess()
        {
            int number = 4;
            Enemy[] nearestEnemies = _enemyManager.GetNearest(_player.transform.position, number);
            if (nearestEnemies.Length > 0)
            {
                for (int i = 0; i < nearestEnemies.Length; i++)
                {
                    Vector3 position = _player.transform.position;
                    MagicMissle magicMissle = Instantiate(_magicMisslePrefab, position, Quaternion.identity);
                    magicMissle.Init(nearestEnemies[i], 20, _bulletSpeed);
                    yield return new WaitForSeconds(0.2f);
                }
            }
        }
    }
}
