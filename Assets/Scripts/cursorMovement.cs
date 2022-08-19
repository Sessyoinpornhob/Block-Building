using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorMovement : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    
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
        }
    }
}
