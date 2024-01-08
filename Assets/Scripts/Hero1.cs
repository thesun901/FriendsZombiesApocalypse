using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero1 : BasicHeroScript
{
    public void Start()
    {
        base.bullet.tag = "hero";
    }
}
