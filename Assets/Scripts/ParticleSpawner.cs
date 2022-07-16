using Codetox.Core;
using Codetox.Variables;
using UnityEngine;
using UnityEngine.Pool;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private ValueReference<int> poolSize;

    private ObjectPool<ParticleSystem> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<ParticleSystem>(
            () =>
            {
                var p = Instantiate(particles);
                p.Stop();
                return p;
            },
            actionOnDestroy: o => Destroy(o.gameObject),
            defaultCapacity: poolSize.Value
        );
    }

    public void SpawnParticles(GameObject source)
    {
        var p = _pool.Get();

        p.transform.position = source.transform.position;
        p.Play();
        p.gameObject.Coroutine().WaitForSeconds(p.main.duration).Invoke(() => _pool.Release(p)).Run();
    }
}