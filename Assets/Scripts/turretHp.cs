using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretHp : MonoBehaviour
{
    public int hp;
    turret_script ts;
    // Start is called before the first frame update
    void Start()
    {
        ts = GetComponentInParent<turret_script>();
        hp = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "zombieAttack")
        {
            hp--;
            if(hp <= 0)
            {
                ts.TurretDestroyed();
            }
        }
    }
}
