using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPanelFrame : MonoBehaviour
{
    public Text buildingName;
    public Text buildingDescription;
    public Image buildingImage;
    public Image[] resourceImage;
    public Text[] resourceAmount;
    public GameObject[] resourceGameObject;
    public Sprite[] resourceSprites;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Description(Building building)
    {
        foreach (GameObject obj in resourceGameObject)
        {
            obj.SetActive(false);
        }

        buildingName.text = building.name;
        buildingDescription.text = building.description;
        buildingImage.sprite = building.image;

        int resourcesNumber;
        resourcesNumber = 0;
        if(building.woodCost > 0)
        {
            resourceGameObject[resourcesNumber].SetActive(true);
            resourceImage[resourcesNumber].sprite = resourceSprites[0];
            resourceAmount[resourcesNumber].text = building.woodCost.ToString();

            if (resourcesNumber < 3)
                resourcesNumber++;
        }

        if (building.rockCost > 0)
        {
            resourceGameObject[resourcesNumber].SetActive(true);
            resourceImage[resourcesNumber].sprite = resourceSprites[1];
            resourceAmount[resourcesNumber].text = building.rockCost.ToString();

            if (resourcesNumber < 3)
                resourcesNumber++;
        }

        if (building.techCost > 0)
        {
            resourceGameObject[resourcesNumber].SetActive(true);
            resourceImage[resourcesNumber].sprite = resourceSprites[2];
            resourceAmount[resourcesNumber].text = building.techCost.ToString();

            if (resourcesNumber < 3)
                resourcesNumber++;
        }

        if (building.foodCost > 0)
        {
            resourceGameObject[resourcesNumber].SetActive(true);
            resourceImage[resourcesNumber].sprite = resourceSprites[3];
            resourceAmount[resourcesNumber].text = building.foodCost.ToString();

            if(resourcesNumber < 3)
               resourcesNumber++;
        }

        if (building.medCost > 0)
        {
            resourceGameObject[resourcesNumber].SetActive(true);
            resourceImage[resourcesNumber].sprite = resourceSprites[4];
            resourceAmount[resourcesNumber].text = building.medCost.ToString();

            if (resourcesNumber < 3)
                resourcesNumber++;
        }

        if (building.gasCost > 0)
        {
            resourceGameObject[resourcesNumber].SetActive(true);
            resourceImage[resourcesNumber].sprite = resourceSprites[5];
            resourceAmount[resourcesNumber].text = building.gasCost.ToString();

            if (resourcesNumber < 3)
                resourcesNumber++;
        }

    }
}
