using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public GameObject building;
    public GameObject effect;
    public void FinishedBuilding()
    {
        Instantiate(building, new Vector3(transform.position.x, transform.position.y, building.transform.position.z), Quaternion.identity);
        Instantiate(effect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Destroy(gameObject);
    }


}
