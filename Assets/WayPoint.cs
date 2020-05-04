using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    const int gridSize = 10;
    Vector2Int gridPos;

    // Start is called before the first frame update
    void Start()
    {
        
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

    public void SetTopColor(Color color)
    {
        MeshRenderer topMR = transform.Find("Top").GetComponent<MeshRenderer>();
        topMR.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
