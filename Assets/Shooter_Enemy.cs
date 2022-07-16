using System;
using System.Collections;
using System.Collections.Generic;
using Codetox.Core;
using Codetox.Variables;
using UnityEngine;

public class Shooter_Enemy : MonoBehaviour
{
    public Transform shootingPoint;
    public Animator animator;
    public Variable<Vector2> player;
    public GameObject bullet;

    private void OnEnable()
    {
        if (transform.DirectionTo(player.Value).x * transform.right.x > 0)
        {
            transform.Rotate(0, 180, 0);
        }
    }

    public void Triggered()
    {
        InvokeRepeating("Attack", 0.5f, 2);
    }

    public void Attack()
    {
        animator.Play("RombusAttackAnim");
        Instantiate(bullet, shootingPoint);
    }

    public void CancelInvokeAttack()
    {
        CancelInvoke("Attack");
    }
}
