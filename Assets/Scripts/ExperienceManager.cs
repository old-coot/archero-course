using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace archero
{
    public class ExperienceManager : MonoBehaviour
    {

        public UnityEvent<int> LevelUp;

        [SerializeField] private float _experience = 0;
        [SerializeField] private float _nextLevelExperience;

        [SerializeField] private TMP_Text _levelText;
        [SerializeField] private Image _experienceScale;

        [SerializeField] private EffectsManager _effectsManager;
        [SerializeField] private AnimationCurve _experienceCurve;

        private int _level;

        private void Awake()
        {
            _nextLevelExperience = _experienceCurve.Evaluate(0);
        }

        public void AddExperience(int value)
        {
            _experience += value;

            if (_experience >= _nextLevelExperience)
            {
                StartCoroutine(UpLevelCoroutine());
            }

            DisplayExperience();
        }

        private IEnumerator UpLevelCoroutine()
        {
            _level++;
            LevelUp?.Invoke(_level);
            Time.timeScale = 0;
            _levelText.text = _level.ToString();


            _experience = 0;
            _nextLevelExperience = _experienceCurve.Evaluate(_level);

            yield return new WaitForSecondsRealtime(1f);

            _effectsManager.ShowCards();

        }

        private void DisplayExperience()
        {
            _experienceScale.fillAmount = _experience / _nextLevelExperience;
        }
    }
}
