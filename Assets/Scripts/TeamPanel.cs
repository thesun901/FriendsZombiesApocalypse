using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamPanel : MonoBehaviour
{
    public ScriptingUI scriptingUI;
    public BasicHeroScript[] bhs;
    public GameObject[] healthBar;
    public GameObject[] hungerBar;
    public GameObject teamPanel;
    public string mode;

    public Sprite food;
    public Sprite meds;

    public GameObject symbolObj;
    public Image symbol;

    void Start()
    {
        mode = "null";
        symbolObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        symbolObj.transform.position = new Vector2(Input.mousePosition.x + 55, Input.mousePosition.y - 55);

        for (int i = 0; i <= healthBar.Length - 1; i++)
        {
            healthBar[i].transform.localScale = new Vector3(bhs[i].healthPoints / bhs[i].defaultHp, healthBar[i].transform.localScale.y, healthBar[i].transform.localScale.z);
        }

        for (int i = 0; i <= hungerBar.Length - 1; i++)
        {
            hungerBar[i].transform.localScale = new Vector3(bhs[i].hunger / bhs[i].defaultHunger, hungerBar[i].transform.localScale.y, hungerBar[i].transform.localScale.z);
        }
    }

    public void ClickedHero(int hero)
    {
        if(mode == "food")
        {
            if (GameInformations.food > 0)
            {
                bhs[hero - 1].hunger += 45;
                GameInformations.food -= 1;
            }

            else
            {
                scriptingUI.PopUp("Not enough food!");
            }
        }

        if(mode == "meds")
        {
            if (GameInformations.meds > 0)
            {
                bhs[hero - 1].healthPoints += 3;
                GameInformations.meds -= 1;
            }

            else
            {
                scriptingUI.PopUp("Not enough medicaments!");
            }
        }
    }

    public void ModeChoose(string modeName)
    {
        mode = modeName;

        if (modeName == "food")
        {
            symbolObj.SetActive(true);
            symbol.sprite = food;
        }

        if (modeName == "meds")
        {
            symbolObj.SetActive(true);
            symbol.sprite = meds;
        }
    }

    public void ExitTeamPanel()
    {
        mode = "null";
        symbolObj.SetActive(false);
        teamPanel.SetActive(false);
    }

}
