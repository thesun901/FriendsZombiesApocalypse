using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;



public class Movement : MonoBehaviour
{
    AIDestinationSetter AiDes;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        AiDes = GetComponent<AIDestinationSetter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void FixedUpdate()
    {
        
    }
}
