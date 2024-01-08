using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingState : HeroBaseState
{
    float chopping_timer;
    public override void EnterState(BasicHeroScript bhs)
    {
        bhs.anim.SetBool("chopping", true);
        bhs.axe.SetActive(true);
        bhs.progressBar.SetActive(true);
        bhs.isWorking = true;
        chopping_timer = bhs.defaultChoppingTime;

        if (bhs.resourceObject.transform.position.x < bhs.transform.position.x)
        {
            bhs.arms.transform.localScale = new Vector3(-1, bhs.arms.transform.localScale.y, bhs.arms.transform.localScale.z);
        }
    }

    public override void UpdateState(BasicHeroScript bhs)
    {
        chopping_timer -= Time.deltaTime * bhs.specialTimeMultiplier;


        bhs.bar.transform.localScale = new Vector3(1.91f * ((bhs.defaultChoppingTime - chopping_timer) / bhs.defaultChoppingTime), bhs.bar.transform.localScale.y, bhs.bar.transform.localScale.z);


        if (chopping_timer < 0)
        {
            chopping_timer = bhs.defaultChoppingTime;
            bhs.Destroying(bhs.resourceObject);
            bhs.progressBar.SetActive(false);
            GameInformations.wood += 3;
            bhs.AsPath.Scan();
            bhs.hunger -= 20;
            bhs.SwitchState(bhs.idleState);
        }


    }

    public override void ExitState(BasicHeroScript bhs)
    {
        bhs.anim.SetBool("chopping", false);
        bhs.axe.SetActive(false);
        bhs.progressBar.SetActive(false);
        bhs.isWorking = false;
    }
}
