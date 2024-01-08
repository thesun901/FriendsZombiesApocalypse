using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchPlusDamage : ResearchBase
{

    public ResearchPlusDamage()
    {
        name = "Plus damage";
         desc = "Increase Damage of your bullets";
         time = 60;       
         isResearched = false;
    }
    public override void OnResearchChoose(ResearchPanelScripts rps)
    {
         
    }

    public override void OnResearchEnded(ResearchPanelScripts rps)
    {
        isResearched = true;
        GameInformations.damage += 1;
    }
}
