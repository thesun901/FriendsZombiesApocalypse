using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret_script : MonoBehaviour
{
    public GameObject target_zombie;
    public GameObject discharge;
    public GameObject bullet;
    public GameObject effect;
    public Animator anim;

    public float reload_default;
    public float reload;
    public int defaultHp;
    public int hp;
    bool shoot;
    // Start is called before the first frame update
    void Start()
    {
        reload = reload_default;
    }

    // Update is called once per frame
    void Update()
    {
        if (target_zombie)
        {
            Vector3 dir = target_zombie.transform.position - discharge.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            discharge.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            if (target_zombie.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            }

            if (target_zombie.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            }
        }

        if(target_zombie)
        {
            reload -= Time.deltaTime;

            if (reload <= 0.1f && !shoot)
            {
                anim.SetTrigger("shot");
                shoot = true;
            }

            if (reload <= 0)
            {
                Instantiate(bullet, discharge.transform.position, discharge.transform.rotation);
                reload = reload_default;
                shoot = false;
                
            }
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "enemy" && !target_zombie)
        {
            GameObject zom = collision.gameObject;
            target_zombie = zom;
        }


        //script to choose closest enemy
        else if (collision.tag == "enemy" && target_zombie)
        {
            if(Vector2.Distance(target_zombie.transform.position, this.transform.position) > Vector2.Distance(collision.transform.position, this.transform.position))
            {
                GameObject zom = collision.gameObject;
                target_zombie = zom;
            }
        }
    }

    public void TurretDestroyed()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
