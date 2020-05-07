using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public bool isExplored = false;
    const int gridSize = 10;
    Vector2Int gridPos;
    public WayPoint exploredFrom;  // public fine as it is data class
    public bool isPlaceable = true;
    [SerializeField] Tower towerPrefab;

    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            if (isPlaceable)
            {
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                isPlaceable = false;
            }
            else
            {
                print(" Tower not placeable");
            }
        }
    }

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize));
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
