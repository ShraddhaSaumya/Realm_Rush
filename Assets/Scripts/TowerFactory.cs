using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int MaxTower = 5;
    [SerializeField] Tower towerPrefab;
    Queue<Tower> queueTower = new Queue<Tower>();

    public void AddTower(WayPoint baseWayPoint)
    {
        int noOfTowers = queueTower.Count;
        if (noOfTowers < MaxTower)
        {
            InstantiateNewTower(baseWayPoint);       
        }
        else
        {
            MoveExistingTower(baseWayPoint);
        }
    }

    private void InstantiateNewTower(WayPoint baseWayPoint)
    {
        var newTower = Instantiate(towerPrefab, baseWayPoint./*here world is the transform so error*/transform.position,
                              Quaternion.identity);
        baseWayPoint.isPlaceable = false;

        newTower.baseWayPoint = baseWayPoint;
        baseWayPoint.isPlaceable = false;
        queueTower.Enqueue(newTower);
    }

    private void MoveExistingTower(WayPoint newbaseWayPoint)
    {
        var oldTower = queueTower.Dequeue();
        oldTower.baseWayPoint.isPlaceable = true;
        newbaseWayPoint.isPlaceable = false;
        oldTower.baseWayPoint = newbaseWayPoint;
        oldTower.transform.position = newbaseWayPoint.transform.position;
        queueTower.Enqueue(oldTower);
    }
}
