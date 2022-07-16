using Codetox.Variables;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Image healthImage;
        [SerializeField] private Variable<float> playerHealth;
        [SerializeField] private ValueReference<float> animationScale;
        [SerializeField] private ValueReference<float> animationTime;
        [SerializeField] private Ease animationEase;
        [SerializeField] private Sprite[] sprites;

        private void Start()
        {
            var index = (int) playerHealth.Value - 1;
            healthImage.sprite = sprites[index];
        }

        private void OnEnable()
        {
            playerHealth.OnValueChanged += DisplayHealth;
        }

        private void OnDisable()
        {
            playerHealth.OnValueChanged -= DisplayHealth;
        }

        private void DisplayHealth(float health)
        {
            var index = (int) health - 1;
            healthImage.sprite = sprites[index];
            
            backgroundImage.material.SetInt("_isGlowing", 1);
            transform.
                DOScale(transform.localScale * animationScale.Value, animationTime.Value).
                SetEase(animationEase).
                SetLoops(2, LoopType.Yoyo).
                OnComplete(() => backgroundImage.material.SetInt("_isGlowing", 0));
            transform.DOShakePosition(animationTime.Value, Vector2.one * 30, 50);
        }
    }
}