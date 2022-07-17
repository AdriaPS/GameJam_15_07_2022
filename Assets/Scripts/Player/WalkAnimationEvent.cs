using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class WalkAnimationEvent : MonoBehaviour
    {
        public UnityEvent onStep;
        
        public void OnStep()
        {
            onStep?.Invoke();
        }
    }
}