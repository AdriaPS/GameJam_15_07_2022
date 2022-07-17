using UnityEngine;

namespace UI
{
    public class HealingPointSpinEffect : MonoBehaviour
    {
        public float rotationSpeed;

        private void Update()
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}