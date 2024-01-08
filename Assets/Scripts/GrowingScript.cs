using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingScript : MonoBehaviour
{
    public int growthTime;
    public GameObject plant;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Grow", growthTime);
    }

    void Grow()
    {
        Instantiate(plant, new Vector3(transform.position.x, transform.position.y, plant.transform.position.z), Quaternion.identity);
        Destroy(gameObject);
    }
}
