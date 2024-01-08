using UnityEngine;

public class ShootingState : HeroBaseState
{
    float shooting_timer;

    public override void EnterState(BasicHeroScript bhs)
    {
        shooting_timer = 0;
        bhs.gun.SetActive(true);
        bhs.anim.SetBool("shooting", true);
    }

    public override void UpdateState(BasicHeroScript bhs)
    {
        if (bhs.target_zombie != null)
        {            
            Vector3 dir = bhs.target_zombie.transform.position - bhs.discharge.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            bhs.discharge.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);


            if (bhs.target_zombie.transform.position.x > bhs.transform.position.x)
            {
                bhs.arms.transform.localScale = new Vector3(-1, bhs.arms.transform.localScale.y, bhs.arms.transform.localScale.z);
            }

            if (bhs.target_zombie.transform.position.x < bhs.transform.position.x)
            {
                bhs.arms.transform.localScale = new Vector3(1, bhs.arms.transform.localScale.y, bhs.arms.transform.localScale.z);
            }

            shooting_timer += Time.deltaTime * bhs.specialTimeMultiplier;

            if (shooting_timer > 1)
            {
                shooting_timer = 0;
                bhs.anim.SetTrigger("shot");
                bhs.Shoot();
            }
        }        
        else
        {
            Debug.Log("Idle");
            bhs.SwitchState(bhs.idleState);
        }

    }

    public override void ExitState(BasicHeroScript bhs)
    {
        shooting_timer = 0f;
        bhs.gun.SetActive(false);
        bhs.anim.SetBool("shooting", false);
    }
}
