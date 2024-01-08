using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTemplate : MonoBehaviour
{
    public GameObject building;
    public GameObject effect;

    [Header("costs of building")]
    public int woodCost;
    public int rockCost;
    public int techCost;
    public int foodCost;
    public int medCost;
    public int gasCost;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y);

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(building, new Vector3(transform.position.x, transform.position.y, building.transform.position.z), Quaternion.identity);
            Instantiate(effect, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            GameInformations.wood -= woodCost;
            GameInformations.stone -= rockCost;
            GameInformations.tech -= techCost;
            GameInformations.food -= foodCost;
            GameInformations.meds -= medCost;
            GameInformations.gasoline -= gasCost;
            Destroy(this.gameObject);
        }
    }
}
