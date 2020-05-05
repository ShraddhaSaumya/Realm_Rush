﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitpoints = 10;

    // Start is called before the first frame update
    void Start()
    {
            
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitpoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitpoints = hitpoints - 1;
        print(hitpoints);
    }
}