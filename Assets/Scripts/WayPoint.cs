using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    //[SerializeField] Color ExploredColor;
    public bool isExplored = false;
    const int gridSize = 10;
    Vector2Int gridPos;
    public WayPoint exploredFrom;

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
      /*  if (isExplored)
        {
            exploredFrom.SetTopColor(Color.gray); // means waypoint.setTopColor
        }
        else
        {
            SetTopColor(Color.black);
        }*/
    }
}
