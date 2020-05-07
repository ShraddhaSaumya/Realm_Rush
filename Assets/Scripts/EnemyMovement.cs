using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem goalParticle;
    
    // Start is called before the first frame update
    void Start()
    {
        Path_Finder path_finder = FindObjectOfType<Path_Finder>();
        var path = path_finder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<WayPoint> path)
    {
        print("Starting patrol");
        foreach (WayPoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        selfKill();
    }
    private void selfKill()
    {
        var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vfx.Play();
        float delay = vfx.main.duration;
        Destroy(vfx.gameObject, delay);
        Destroy(gameObject);
    }
}