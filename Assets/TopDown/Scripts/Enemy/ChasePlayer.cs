using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    public float moveSpeed = 2f;
    Rigidbody2D rb2d;
    Transform target;
    Vector2 moveDirection;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
    }
    private void FixedUpdate()
    {
        if (target)
        {
            EnemyAIUtility.ChaseTarget(rb2d, transform, target, moveSpeed);
            //transform es el transform del objeto que persigue
            //target es el transform del objeto al que persigue
        }
    }
}
