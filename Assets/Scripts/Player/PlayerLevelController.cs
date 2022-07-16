using System.Collections.Generic;
using System.Linq;
using Codetox.Variables;
using UnityEngine;

namespace Player
{
    public class PlayerLevelController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> levels;
        [SerializeField] private Variable<float> currentHealth;

        private void OnEnable()
        {
            levels.ForEach(o => o.SetActive(false));
            SetLevel(currentHealth.Value);
            currentHealth.OnValueChanged += SetLevel;
        }

        private void OnDisable()
        {
            currentHealth.OnValueChanged -= SetLevel;
        }

        public void SetLevel(float levelNumber)
        {
            var index = (int) levelNumber - 1;

            if (index < 0) index = 0;
            if (index >= levels.Count) index = levels.Count - 1;
            
            var level = levels[index];

            foreach (var o in levels.Where(o => o.activeSelf)) o.SetActive(false);

            level.SetActive(true);
        }
    }
}