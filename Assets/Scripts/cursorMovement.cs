using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorMovement : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;

    private gridElement lastHit;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("gridElement"))
        {
            this.transform.position = hit.collider.transform.position;
            
            lastHit = hit.collider.gameObject.GetComponent<gridElement>();

            if (Input.GetMouseButtonDown(1))
            {
                SetCursorButton(0);
            }
        }
    }

    public void SetCursorButton(int input)
    {
        coord coord = lastHit.GetCoord();
        int width = levelGenerator.instance.width;
        int height = levelGenerator.instance.height;
        
        switch (input)
        {
            case 0:
                //remove gridElement
                if (coord.y > 0)
                {
                    lastHit.SetDisable();
                }
                break;
            case 1:
                // add x+
                if (coord.x < width - 1)
                { 
                    levelGenerator.instance.gridElements[coord.x + width * (coord.z + width * coord.y ) + 1].SetEnable();
                }
                break;
            case 2:
                // add x-
                if (coord.x > 0)
                { 
                    levelGenerator.instance.gridElements[coord.x + width * (coord.z + width * coord.y ) - 1].SetEnable();
                }
                break;
            case 3:
                // add z+
                if (coord.z < width - 1)
                { 
                    levelGenerator.instance.gridElements[coord.x + width * (coord.z + 1 + width * coord.y )].SetEnable();
                }
                break;
            case 4:
                // add z-
                if (coord.z > 0)
                { 
                    levelGenerator.instance.gridElements[coord.x + width * (coord.z -1 + width * coord.y )].SetEnable();
                }
                break;
            case 5:
                // add y+
                if (coord.y < height - 1)
                { 
                    levelGenerator.instance.gridElements[coord.x + width * (coord.z + width * (coord.y + 1))].SetEnable();
                }
                break;
            case 6:
                // add y-
                if (coord.y > 0)
                { 
                    levelGenerator.instance.gridElements[coord.x + width * (coord.z + width * (coord.y - 1))].SetEnable();
                }
                break;
        }
    }
    
    
    
    
    
    
    
    
    
}
