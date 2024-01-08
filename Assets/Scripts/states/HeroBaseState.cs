using UnityEngine;

public abstract class HeroBaseState
{
    public abstract void EnterState(BasicHeroScript bhs);
    public abstract void UpdateState(BasicHeroScript bhs);
    public abstract void ExitState(BasicHeroScript bhs);
}
