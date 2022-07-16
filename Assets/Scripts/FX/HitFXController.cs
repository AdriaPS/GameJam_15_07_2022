using Codetox.Core;
using Codetox.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace FX
{
    public class HitFXController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private ValueReference<float> glowingTime;
        [SerializeField] private ValueReference<float> flickeringTime;

        public UnityEvent onFinished;
        
        private CoroutineBuilder _coroutine;
        private static readonly int IsGlowing = Shader.PropertyToID("_isGlowing");
        private static readonly int IsFlickering = Shader.PropertyToID("_isFlickering");

        private void Awake()
        {
            _coroutine = gameObject.
                Coroutine(cancelOnDisable: true, destroyOnFinish: false).
                Invoke(() => spriteRenderer.material.SetInt(IsGlowing, 1)).
                WaitForSeconds(glowingTime.Value).
                Invoke(
                    () =>
                    {
                        spriteRenderer.material.SetInt(IsGlowing, 0);
                        spriteRenderer.material.SetInt(IsFlickering, 1);
                    }).
                WaitForSeconds(flickeringTime.Value).
                Invoke(() =>
                {
                    spriteRenderer.material.SetInt(IsFlickering, 0);
                    onFinished?.Invoke();
                });
        }

        public void DoFX()
        {
            spriteRenderer.material.SetInt(IsGlowing, 0);
            spriteRenderer.material.SetInt(IsFlickering, 0);
            _coroutine.Run();
        }
    }
}