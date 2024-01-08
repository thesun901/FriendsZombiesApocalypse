using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchGhostBullets : ResearchBase
{    public ResearchGhostBullets()
    {
        name = "Ghost Bullets";
        desc = "Bullets don't collide with environment";
        time = 60;
        isResearched = false;
    }

    public override void OnResearchChoose(ResearchPanelScripts rps)
    {
        
    }

    public override void OnResearchEnded(ResearchPanelScripts rps)
    {
        isResearched = true;
    }
}
