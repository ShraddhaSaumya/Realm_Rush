using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_Finder : MonoBehaviour
{
    Dictionary<Vector2Int,WayPoint> grid = new Dictionary<Vector2Int,WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();
    bool isRunning = true;
    WayPoint SearchCenter;
    List<WayPoint> path = new List<WayPoint>();

    public WayPoint StartWP, EndWP; // Public vs serializeField : p- change can happen from diff scripts- allowed
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<WayPoint> GetPath()
    {
        if (path.Count == 0)
        {
            LoadBlocks();
            ColorStartandEnd();
            BreadthFirstSearch();
            FormPath();
        }
        return path;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void FormPath()
    {
        path.Add(EndWP);
        WayPoint previous = EndWP.exploredFrom;
        while (previous != StartWP)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(StartWP);
        path.Reverse();
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(StartWP);
        while (queue.Count > 0 && isRunning)
        {
            SearchCenter = queue.Dequeue();
            HaltIfEndFound();
            ExploreNeighbours();
            SearchCenter.isExplored = true;
        }
    }

    private void HaltIfEndFound()
    {
        if (SearchCenter == EndWP)
        {
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions)
        {
            Vector2Int NeighbourCoordinates = SearchCenter.GetGridPos() + direction;
            if(grid.ContainsKey(NeighbourCoordinates))
            {
                QueueNewNeighbours(NeighbourCoordinates);
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int NeighbourCoordinates)
    {
        WayPoint neighbour = grid[NeighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {

        }
        else
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = SearchCenter;
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
    }

    // Update is called once per frame
    void Update()
    {
    }
}
