using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchingState: HeroBaseState
{
    float research_timer;
    public override void EnterState(BasicHeroScript bhs)
    {
        bhs.StopRightThere();
        bhs.isWorking = true;
        bhs.anim.SetBool("researching", true);
        bhs.flask.SetActive(true);

        research_timer = bhs.currentResearchTime;

    }

    public override void UpdateState(BasicHeroScript bhs)
    {
        research_timer -= Time.deltaTime * bhs.specialTimeMultiplier;


        bhs.progressBar.SetActive(true);
        bhs.bar.transform.localScale = new Vector3(1.91f * ((bhs.currentResearchTime - research_timer) / bhs.currentResearchTime), bhs.bar.transform.localScale.y, bhs.bar.transform.localScale.z);

        if (research_timer < 0)
        {
            //bhs.Destroying(bhs.resourceObject);
            bhs.progressBar.SetActive(false);
            bhs.rps.ResearchEnded(bhs.researchId);
            bhs.SwitchState(bhs.idleState);
        }

    }

    public override void ExitState(BasicHeroScript bhs)
    {
        bhs.isWorking = false;
        bhs.anim.SetBool("researching", false);
        bhs.flask.SetActive(false);
    }
}

