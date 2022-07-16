using UnityEngine;

public class Debugger : MonoBehaviour
{
    public void Log(string message)
    {
        Debug.Log(message);
    }
    
    public void Log(Vector2 message)
    {
        Debug.Log(message);
    }
}