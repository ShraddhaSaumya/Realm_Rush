using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WayPoint> path;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
        print("I'm at Start again");
    }

    IEnumerator FollowPath()
    {
        print("Starting patrol");
        foreach (WayPoint wayPoint in path)
        {
            transform.position = wayPoint.transform.position;
            print("Visiting:"+ wayPoint);
            yield return new WaitForSeconds(1f);
        }
        print("Ending patrol");
    }
}