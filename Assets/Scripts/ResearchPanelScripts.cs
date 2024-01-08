using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchPanelScripts : MonoBehaviour
{
    public int currentId;
    public ResearchTable researchTable;
    public Research[] research;
    public BasicHeroScript bhs;
    public ScriptingUI scriptingUI;

    public GameObject researchPanel;

    [Header("MiniPanel")]
    public GameObject miniPanel;
    public Text title;
    public Text description;
    public Image img;

    public ResearchBase currentResearch;
    public ResearchMakeWeapon makeWeapon = new ResearchMakeWeapon();
    public ResearchPlusDamage plusDamage = new ResearchPlusDamage();
    public ResearchGhostBullets ghostBullets = new ResearchGhostBullets();

    void Start()
    {
        scriptingUI = GameObject.Find("GlobalScripts").GetComponent<ScriptingUI>();

    }

    void Update()
    {

    }

    public void ResearchActivated(ResearchTable rt)
    {
        researchTable = rt;
        bhs = researchTable.bhs;
        researchPanel.SetActive(true);
        miniPanel.SetActive(false);
    }

    public void StartResearch()
    {

        if(currentResearch.isResearched == false)
        {        
            bhs.StartResearch(currentResearch.time, currentResearch);
            scriptingUI.ExitPanel();
        }

        else
        {
            scriptingUI.PopUp("This research has alredy been done!" );
            ExitMiniPanel();
        }
    }

    public void ResearchChoose(ResearchBase res)
    {
        currentResearch = res;
        miniPanel.SetActive(true);
        title.text = currentResearch.name.ToString();
        description.text = currentResearch.desc.ToString();
        img.sprite = currentResearch.img;
    }


    public void ExitMiniPanel()
    {
        miniPanel.SetActive(false);
    }

    public void ResearchEnded(ResearchBase res)
    {
        currentResearch = res;
        scriptingUI.PopUp("Research '" + currentResearch.name + "' done!");
        currentResearch.OnResearchEnded(this);
    }



}
