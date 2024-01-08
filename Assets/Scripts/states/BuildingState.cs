using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingState : HeroBaseState
{
    float building_timer;
    public override void EnterState(BasicHeroScript bhs)
    {
        building_timer = bhs.defaultBuildingTime;
        bhs.isWorking = true;

        bhs.anim.SetBool("building", true);
        bhs.hammer.SetActive(true);

        if (bhs.resourceObject.transform.position.x < bhs.transform.position.x)
        {
            bhs.arms.transform.localScale = new Vector3(-1, bhs.arms.transform.localScale.y, bhs.arms.transform.localScale.z);
        }
    }

    public override void UpdateState(BasicHeroScript bhs)
    {
        building_timer -= Time.deltaTime * bhs.specialTimeMultiplier;

        bhs.progressBar.SetActive(true);
        bhs.bar.transform.localScale = new Vector3(1.91f * ((bhs.defaultBuildingTime - building_timer) / bhs.defaultBuildingTime), bhs.bar.transform.localScale.y, bhs.bar.transform.localScale.z);

        if (building_timer < 0)
        {
            if (bhs.resourceObject)
            {
                building_timer = bhs.defaultBuildingTime;
                bhs.progressBar.SetActive(false);
                BuildingScript bs;
                bs = bhs.resourceObject.GetComponent<BuildingScript>();
                bhs.hunger -= 20;
                bs.FinishedBuilding();
                bhs.AsPath.Scan();
            }

            bhs.SwitchState(bhs.idleState);
        }
    }

    public override void ExitState(BasicHeroScript bhs)
    {
        bhs.isWorking = false;
        bhs.progressBar.SetActive(false);
        bhs.anim.SetBool("building", false);
        bhs.hammer.SetActive(false);
    }
}
