using System.Collections;
using System.Collections.Generic;
using Codetox.Core;
using Codetox.Variables;
using UnityEngine;

public class Melee_Shield : MonoBehaviour
{
    public Variable<Vector2> playerPosition;
    public Variable<float> speed;
    public float minimumDistance;
    public bool isRotating;
    public GameObject weapon;

    void FixedUpdate()
    {
        if (!isRotating)
        {
            if (transform.DistanceTo(playerPosition.Value) > minimumDistance)
            {
                Vector2 pos = transform.position;
                transform.position = Vector2.MoveTowards(pos, new Vector2(playerPosition.Value.x, pos.y), speed.Value * Time.deltaTime);
            }
            else
            {
                //Start Attack Animation.
                //In Attack Animation make an Event that triggers the method to activate the sword trigger.
            }
        }

        if (!isRotating)
        {
            if (transform.DirectionTo(playerPosition.Value).x * transform.right.x < 0)
            {
                isRotating = true;
                Invoke("RotateEnemy", 1);
            }
        }
    }

    void RotateEnemy()
    {
        isRotating = false;
        transform.Rotate(0, 180, 0);
    }

    void ActivateSword()
    {
        weapon.SetActive(true);
    }
}

