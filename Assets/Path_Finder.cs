using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_Finder : MonoBehaviour
{
    Dictionary<Vector2Int,WayPoint> grid = new Dictionary<Vector2Int,WayPoint>();
    public WayPoint StartWP, EndWP; // Public vs serializeField : p- change can happen from diff scripts- allowed
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.right,
        Vector2Int.left
    };

    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartandEnd();
        ExploreNeighbours();
    }

    private void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            Vector2Int CoordinatesToExplore = StartWP.GetGridPos() + direction;
            print("Exploring" + CoordinatesToExplore);
            try
            {
                grid[CoordinatesToExplore].SetTopColor(Color.gray); // means waypoint.setTopColor
            }
            catch
            {

            }
        }

    }

    private void ColorStartandEnd()
    {
        StartWP.SetTopColor(Color.green); //Color is a structure
        EndWP.SetTopColor(Color.cyan);
    }

    private void LoadBlocks()
    {
        var wayPoints = FindObjectsOfType<WayPoint>();
        foreach (WayPoint wayPoint in wayPoints)
        {
            var gridPos = wayPoint.GetGridPos();
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping overlapping block" + wayPoint);
            }
            else
            {
                grid.Add(gridPos, wayPoint);
            }
        }
        print("Loaded" + grid.Count + "blocks");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
