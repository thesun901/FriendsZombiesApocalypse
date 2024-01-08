using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootingState : HeroBaseState
{
    float looting_timer;
    public override void EnterState(BasicHeroScript bhs)
    {
        bhs.isWorking = true;
        bhs.anim.SetBool("looting", true);
        looting_timer = bhs.defaultLootingTime;
    }

    public override void UpdateState(BasicHeroScript bhs)
    {
        looting_timer -= Time.deltaTime * bhs.specialTimeMultiplier;

        bhs.progressBar.SetActive(true);
        bhs.bar.transform.localScale = new Vector3(1.91f * ((bhs.defaultLootingTime - looting_timer) / bhs.defaultLootingTime), bhs.bar.transform.localScale.y, bhs.bar.transform.localScale.z);

        if (looting_timer < 0)
        {
            looting_timer = bhs.defaultLootingTime;
            bhs.progressBar.SetActive(false);
            LootScript ls;
            ls = bhs.resourceObject.GetComponent<LootScript>();
            if(ls)
            ls.Looted();

            bhs.SwitchState(bhs.idleState);
        }

    }

    public override void ExitState(BasicHeroScript bhs)
    {
        bhs.AsPath.Scan();
        bhs.anim.SetBool("looting", false);
        bhs.isWorking = false;
    }
}
