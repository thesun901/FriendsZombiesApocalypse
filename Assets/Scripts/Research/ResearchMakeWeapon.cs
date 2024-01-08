using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchMakeWeapon : ResearchBase
{
    public ResearchMakeWeapon()
    {
        name = "Make own weapon fesdfasd";
        desc = "Didn't find any weapon around? No problem make your own!";
        time = 10;
        isResearched = true;
    }

    public override void OnResearchChoose(ResearchPanelScripts rps)
    {

    }

    public override void OnResearchEnded(ResearchPanelScripts rps)
    {
        isResearched = true;
        Debug.Log("cool");
    }
}
