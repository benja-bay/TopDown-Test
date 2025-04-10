using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class EnemyAIUtility
{
    public static void ChaseTarget(Rigidbody2D rb2d, Transform chaser, Transform target, float moveSpeed)
    {
        if (rb2d == null || chaser == null || target == null)
            return;

        Vector2 direction = (target.position - chaser.position).normalized;
        rb2d.velocity = direction * moveSpeed;
    }
}