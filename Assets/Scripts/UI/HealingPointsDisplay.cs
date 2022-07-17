using System.Collections.Generic;
using System.Linq;
using Codetox.Variables;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class HealingPointsDisplay : MonoBehaviour
    {
        [SerializeField] private Variable<float> healingPoints;
        [SerializeField] private GameObject prefab;
        [SerializeField] private GameObject container;
        [SerializeField] private ValueReference<float> animationScale;
        [SerializeField] private ValueReference<float> animationTime;
        [SerializeField] private Ease animationEase;

        public UnityEvent onRemoveHealingPoint;

        private readonly List<GameObject> _icons = new();

        private void OnEnable()
        {
            SetHealingPoints(healingPoints.Value);
            healingPoints.OnValueChanged += SetHealingPoints;
        }

        private void OnDisable()
        {
            healingPoints.OnValueChanged -= SetHealingPoints;
        }

        private void SetHealingPoints(float value)
        {
            var amount = (int) value;
            var count = _icons.Count;

            while (count != amount)
            {
                if (count > amount) RemoveHealingPoint();
                else if (count < amount) AddHealingPoint();
                count = _icons.Count;
            }
        }

        private void AddHealingPoint()
        {
            var o = Instantiate(prefab, container.transform);
            
            _icons.Add(o);

            var backgroundImage = o.GetComponentInChildren<Image>();
            
            backgroundImage.material.SetInt("_isGlowing", 1);
            backgroundImage.transform.
                DOScale(backgroundImage.transform.localScale * animationScale.Value, animationTime.Value).
                SetEase(animationEase).
                SetLoops(2, LoopType.Yoyo).
                OnComplete(() => backgroundImage.material.SetInt("_isGlowing", 0));
            backgroundImage.transform.DOShakePosition(animationTime.Value, Vector2.one * 30, 50);
        }

        private void RemoveHealingPoint()
        {
            var o = _icons.Last();
            
            _icons.Remove(o);
            
            var backgroundImage = o.GetComponentInChildren<Image>();
            
            backgroundImage.material.SetInt("_isGlowing", 1);
            backgroundImage.transform.
                DOScale(backgroundImage.transform.localScale * animationScale.Value, animationTime.Value).
                SetEase(animationEase).
                OnComplete(() =>
                {
                    backgroundImage.material.SetInt("_isGlowing", 0);
                    Destroy(o);
                });
            backgroundImage.transform.DOShakePosition(animationTime.Value, Vector2.one * 30, 50);
            
            onRemoveHealingPoint?.Invoke();
        }
    }
}