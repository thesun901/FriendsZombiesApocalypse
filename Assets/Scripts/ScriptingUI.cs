using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptingUI : MonoBehaviour
{
    public BasicHeroScript[] bhs;
    public GameObject[] healthBar;
    public GameObject[] hungerBar;
    public GameObject teamPanel;
    public GameObject buildPanel;
    public GameObject researchPanel;
    public GameObject symbol;
    public GameObject popUp;
    public Text message;
    public controller controller;
    public CameraScipt cameraScipt;
    public Image[] heroImage;
    public Sprite tombstone;

    void Start()
    {
        popUp.SetActive(false);
        ExitPanel();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i <= healthBar.Length - 1; i++)
        {
            healthBar[i].transform.localScale = new Vector3(bhs[i].healthPoints / bhs[i].defaultHp, healthBar[i].transform.localScale.y, healthBar[i].transform.localScale.z);
        }

        for (int i = 0; i <= hungerBar.Length - 1; i++)
        {
            hungerBar[i].transform.localScale = new Vector3(bhs[i].hunger / bhs[i].defaultHunger, hungerBar[i].transform.localScale.y, hungerBar[i].transform.localScale.z);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            HeroPick(1);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            HeroPick(2);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            HeroPick(3);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            HeroPick(4);

        if (Input.GetKeyDown(KeyCode.Alpha5))
            HeroPick(5);
    }

    public void HeroPick(int pick)
    {
        controller.heroId = bhs[pick - 1].id;
        cameraScipt.CenterCamera();
    }

    public void OpenTeamPanel()
    {
        ExitPanel();
        teamPanel.SetActive(true);
    }

    public void ExitPanel()
    {
        symbol.SetActive(false);
        teamPanel.SetActive(false);
        buildPanel.SetActive(false);
        researchPanel.SetActive(false);
    }

    public void PopUp(string information)
    {
        //it might seem little confusing - its all about starting over Fade animation on the text - if script won't disable it in the first place - the animation wouldn't reset
        popUp.SetActive(false);
        popUp.SetActive(true);
        message.text = information;
    }

    public void DeadHero(int id)
    {
        heroImage[id].sprite = tombstone;
    }
}
