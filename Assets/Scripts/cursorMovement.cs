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
            //Debug.Log(hit.collider.name);
            lastHit = hit.collider.gameObject.GetComponent<gridElement>();

            if (Input.GetMouseButtonDown(1))
            {
                SetCursorButton(0);
            }
        }
    }

    public void SetCursorButton(int input)
    {
        switch (input)
        {
            case 0:
                //remove gridElement
                //Debug.Log("666");
                lastHit.SetDisable();
                break;
            case 1:
                // add x+
                break;
            case 2:
                // add x-
                break;
            case 3:
                // add z+
                break;
            case 4:
                // add z-
                break;
            case 5:
                // add y+
                break;
            case 6:
                // add y-
                break;
        }
    }
    
    
    
    
    
    
    
    
    
}
