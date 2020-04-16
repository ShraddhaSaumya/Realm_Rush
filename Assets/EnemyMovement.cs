using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Block> path;

    // Start is called before the first frame update
    void Start()
    {
        printAllWayPoints();   
    }

    private void printAllWayPoints()
    {
        foreach (Block wayPoint in path)
            print(wayPoint.name);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
