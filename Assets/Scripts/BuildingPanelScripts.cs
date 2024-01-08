using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingPanelScripts : MonoBehaviour
{
    public GameResources resources;
    public ScriptingUI scriptingUI;
    public Building[] building;
    public BuildingPanelFrame buildingPanelFrame;
    public GameObject frame;
    public GameObject buildingPanel;  

    int id;
 

    void Start()
    {
        buildingPanelFrame = frame.GetComponent<BuildingPanelFrame>();
        scriptingUI.ExitPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildingChoose(int buildingNumber)
    {
        frame.SetActive(true);
        id = buildingNumber;

        buildingPanelFrame.Description(building[id]);
    }

    public void Build()
    {
        if (GameInformations.wood >= building[id].woodCost && GameInformations.stone >= building[id].rockCost && GameInformations.tech >= building[id].techCost && GameInformations.food >= building[id].foodCost && GameInformations.meds >= building[id].medCost && GameInformations.gasoline >= building[id].gasCost)
        { 
        Instantiate(building[id].building);
            scriptingUI.ExitPanel();
        }

        else
        {
            scriptingUI.PopUp("too few resources!");
        }
    }

    public void OpenPanel()
    {
        buildingPanel.SetActive(true);
        frame.SetActive(false);
    }

}
