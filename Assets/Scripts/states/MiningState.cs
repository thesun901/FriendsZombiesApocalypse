using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningState : HeroBaseState
{
    float mining_timer;
    public override void EnterState(BasicHeroScript bhs)
    {
        bhs.isWorking = true;
        bhs.anim.SetBool("chopping", true);
        bhs.pickaxe.SetActive(true);

        mining_timer = bhs.defaultMiningTime;

        if (bhs.resourceObject.transform.position.x < bhs.transform.position.x)
        {
            bhs.arms.transform.localScale = new Vector3(-1, bhs.arms.transform.localScale.y, bhs.arms.transform.localScale.z);
        }
    }

    public override void UpdateState(BasicHeroScript bhs)
    {
        mining_timer -= Time.deltaTime * bhs.specialTimeMultiplier;


        bhs.progressBar.SetActive(true);
        bhs.bar.transform.localScale = new Vector3(1.91f * ((bhs.defaultMiningTime - mining_timer) / bhs.defaultMiningTime), bhs.bar.transform.localScale.y, bhs.bar.transform.localScale.z);

        if (mining_timer < 0)
        {
            bhs.Destroying(bhs.resourceObject);
            bhs.progressBar.SetActive(false);            
            GameInformations.stone += 5;
            bhs.AsPath.Scan();
            bhs.hunger -= 20;
            bhs.SwitchState(bhs.idleState);
        }

    
    }

    public override void ExitState(BasicHeroScript bhs)
    {
        bhs.isWorking = false;
        bhs.anim.SetBool("chopping", false);
        bhs.pickaxe.SetActive(false);
    }
}
