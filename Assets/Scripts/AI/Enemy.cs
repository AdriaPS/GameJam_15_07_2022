using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        /*if (!isRotating)
        {
            Vector2 pos = transform.position;
            transform.position = Vector2.MoveTowards(pos, new Vector2(playerPosition.Value.x, pos.y), speed.Value * Time.deltaTime);
        }

        if (!isRotating)
        {
            if (transform.DirectionTo(playerPosition.Value).x * transform.right.x < 0)
            {
                isRotating = true;
                Invoke("RotateEnemy", 1);
            }
        }*/
    }
}
