using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : HeroBaseState
{
    public override void EnterState(BasicHeroScript bhs)
    {
        bhs.arms.transform.localScale = new Vector3(1, bhs.arms.transform.localScale.y, bhs.arms.transform.localScale.z);
        bhs.flask.SetActive(false);
    }

    public override void UpdateState(BasicHeroScript bhs)
    {

    }

    public override void ExitState(BasicHeroScript bhs)
    {

    }
}
