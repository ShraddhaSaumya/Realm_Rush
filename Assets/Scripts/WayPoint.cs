using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    //Sample try
    Vector3 touchPosWorld;

    public bool isExplored = false;
    const int gridSize = 10;
    Vector2Int gridPos;
    public WayPoint exploredFrom;  // public fine as it is data class
    public bool isPlaceable = true;

   /* private void OnMouseOver()
     {
         if (Input.GetMouseButtonDown(0)) // left click
         {
             if (isPlaceable)
             {
                 FindObjectOfType<TowerFactory>().AddTower(this);
             }
             else
             {
                 print(" Tower not placeable");
             }
         }
     }*/

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize),
        Mathf.RoundToInt(transform.position.z / gridSize));
    }

    private void Update()
    {
        //Mouse changes position on screen almost every frame. 
        //Hence ray should be updated every frame according to mouse position. 

        /*if (Input.touchCount > 0         // touch: if greater than 0 or take ==1 
            && Input.GetTouch(0).phase == TouchPhase.Began)      // sabse pehla touch would start the begin wala phase
        {
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);       // jahan touch kara wahan ka position ko input lekar screen se world

            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);
                     //converting vector3 to vector2

            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);    // raycast sends the ray where you touch in the screen from world and it is sent in forward direction

            Debug.Log(hitInformation);

            if (hitInformation.collider != null && isPlaceable)      // jahan hit kiya wahan par if there is collider i.e. null nahi hai and isPlaceable tab 
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
                        // function to insert the tower at this posn.
            }
        }*/

        RaycastHit hit;
       
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
           
            
            if (Physics.Raycast(ray/*transform.position, transform.TransformDirection(Vector3.forward)*/, out hit))
            {
               // WayPoint baseWayPoint = hit.collider.getComponent<WayPoint>();
                if (hit.collider != null && isPlaceable)
                {
                    FindObjectOfType<TowerFactory>().AddTower(this);
                }
            }
        }
    }

}
