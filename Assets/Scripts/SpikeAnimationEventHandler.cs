using UnityEngine;
using UnityEngine.Events;

public class SpikeAnimationEventHandler : MonoBehaviour
{
    public UnityEvent onSpikeUp, onSpikeDown;

    public void OnSpikeUp()
    {
        onSpikeUp?.Invoke();
    }
    
    public void OnSpikeDown()
    {
        onSpikeDown?.Invoke();
    }
}