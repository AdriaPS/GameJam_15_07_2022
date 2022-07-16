using Codetox.Core;
using Codetox.Variables;
using UnityEngine;
using UnityEngine.Pool;

public class EffectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private ValueReference<int> poolSize;
    [SerializeField] private ValueReference<float> lifeTime;

    private ObjectPool<GameObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(
            () =>
            {
                var p = Instantiate(prefab);
                p.SetActive(false);
                return p;
            },
            o => o.SetActive(true),
            o => o.SetActive(false),
            o => Destroy(o.gameObject),
            defaultCapacity: poolSize.Value
        );
    }

    public void SpawnEffect(GameObject source)
    {
        var p = _pool.Get();

        p.transform.position = source.transform.position;
        p.gameObject.Coroutine().WaitForSeconds(lifeTime.Value).Invoke(() => _pool.Release(p)).Run();
    }
}