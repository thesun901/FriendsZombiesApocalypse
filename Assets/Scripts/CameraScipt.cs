using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScipt : MonoBehaviour
{
    float speed = 35;
    float screenEdges = 7;
    public controller controller;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //moving camera by WASD buttons
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.D) )
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }


        if ( Input.mousePosition.y > Screen.height - screenEdges)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }

        if ( Input.mousePosition.y < screenEdges)
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }

        if ( Input.mousePosition.x > Screen.width - screenEdges)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (Input.mousePosition.x < screenEdges)
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            CenterCamera();
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0f) // forward
        {
            cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * 10;
            if(cam.orthographicSize > 50)
            {
                cam.orthographicSize = 50;
            }

            if (cam.orthographicSize < 5)
            {
                cam.orthographicSize = 5;
            }
        }
    }

    //centers camera on chosen hero
    public void CenterCamera()
    {
        transform.position = new Vector3(controller.heroes_pos[controller.heroId].position.x, controller.heroes_pos[controller.heroId].position.y, transform.position.z);
    }
}
