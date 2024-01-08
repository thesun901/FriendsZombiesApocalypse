using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    Vector3 pos;

    public GameObject[] pointer;
    public Transform[] heroes_pos;
    public int heroId;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 5; i++)
            pointer[i].transform.position = heroes_pos[i].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pointer[heroId].transform.position = pos;
        }

    
    }

}
