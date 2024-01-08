using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : HeroBaseState
{
    Vector3 currentPos;
    float timer;
    public override void EnterState(BasicHeroScript bhs)
    {
        bhs.arms.transform.localScale = new Vector3(1, bhs.arms.transform.localScale.y, bhs.arms.transform.localScale.z);
    }

    public override void UpdateState(BasicHeroScript bhs)
    {
        if (Vector2.Distance(bhs.transform.position, currentPos) < 2f * Time.deltaTime)
        {         
            timer += Time.deltaTime;
            if(timer > 0.3f)
            {
                bhs.StopRightThere();
                bhs.SwitchState(bhs.idleState);
            }
        }

        else
        {
            timer = 0;
        }

            
        currentPos = bhs.transform.position;
    }

    public override void ExitState(BasicHeroScript bhs)
    {

    }
}
