using System.Collections;
using System.Collections.Generic;
using Codetox.Core;
using Codetox.Variables;
using UnityEngine;

public class Melee_Shield : MonoBehaviour
{
    public Variable<float> speed;

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed.Value * Time.deltaTime, 0);
    }

    public void RotateEnemy()
    {
        transform.Rotate(0, 180, 0);
        speed.Value *= -1.0f;
    }
}

