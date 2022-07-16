using Codetox.Core;
using Codetox.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace FX
{
    public class HitFX3DController : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
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
                Invoke(() => meshRenderer.material.SetInt(IsGlowing, 1)).
                WaitForSeconds(glowingTime.Value).
                Invoke(
                    () =>
                    {
                        meshRenderer.material.SetInt(IsGlowing, 0);
                        meshRenderer.material.SetInt(IsFlickering, 1);
                    }).
                WaitForSeconds(flickeringTime.Value).
                Invoke(() =>
                {
                    meshRenderer.material.SetInt(IsFlickering, 0);
                    onFinished?.Invoke();
                });
        }

        public void DoFX()
        {
            meshRenderer.material.SetInt(IsGlowing, 0);
            meshRenderer.material.SetInt(IsFlickering, 0);
            _coroutine.Run();
        }
    }
}