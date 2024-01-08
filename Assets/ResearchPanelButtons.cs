using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchPanelButtons : MonoBehaviour
{

    public ResearchPanelScripts rps;
    
    public void MakeWeapon()
    {
        rps.ResearchChoose(rps.makeWeapon);
    }

    public void GhostBullets()
    {
        rps.ResearchChoose(rps.ghostBullets);
    }

    public void PlusDamage()
    {
        rps.ResearchChoose(rps.plusDamage);
    }

}
