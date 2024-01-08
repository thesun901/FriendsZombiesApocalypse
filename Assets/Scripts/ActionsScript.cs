using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ActionsScript : MonoBehaviour
{
    public Sprite[] items;
    public SpriteRenderer sr;
    public BasicHeroScript bhs;
    public string id;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Actions(string actionId)
    {
        if(actionId == "tree")
        {
            sr.sprite = items[1];
            id = "tree";
        }

        if (actionId == "rock")
        {
            sr.sprite = items[2];
            id = "rock";
        }

        if (actionId == "loot")
        {
            sr.sprite = items[3];
            id = "loot";
        }

        if (actionId == "build")
        {
            sr.sprite = items[4];          
            id = "build";
        }
    }

    private void OnMouseDown()
    {
        if(id == "tree")
        {
            bhs.StopRightThere();
            bhs.SwitchState(bhs.choppingState);                      
            gameObject.SetActive(false);
        }

        if (id == "rock")
        {
            bhs.StopRightThere();        
            bhs.SwitchState(bhs.miningState);
            gameObject.SetActive(false);
        }

        if (id == "loot")
        {
            bhs.StopRightThere();      
            bhs.SwitchState(bhs.lootingState);
            gameObject.SetActive(false);
        }

        if (id == "build")
        {
            bhs.StopRightThere();            
            bhs.SwitchState(bhs.buildingState);
            gameObject.SetActive(false);
        }
    }
}
