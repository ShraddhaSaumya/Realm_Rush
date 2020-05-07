using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitpoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;

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
        //Important to instantiate the particle effect before destroying this object
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        float delay = vfx.main.duration;
        Destroy(vfx.gameObject, delay);
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitpoints = hitpoints - 1;
        hitParticlePrefab.Play();
    }
}
