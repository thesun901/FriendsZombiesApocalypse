using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : HeroBaseState
{
    public override void EnterState(BasicHeroScript bhs)
    {
        bhs.basicHero.SetActive(false);
        bhs.gameObject.tag = "Finish";
        bhs.rgb.simulated = false;
        bhs.transform.position = new Vector3(bhs.transform.position.x, bhs.transform.position.y, 2);

        SpriteRenderer sr;
        sr = bhs.GetComponent<SpriteRenderer>();
        sr.sprite = bhs.tombstone;
    }

    public override void UpdateState(BasicHeroScript bhs)
    {

    }

    public override void ExitState(BasicHeroScript bhs)
    {

    }
}