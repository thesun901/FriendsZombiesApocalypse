using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ZombieScript : MonoBehaviour
{
    public GameObject targetCenter;
    public GameObject target;
    public GameObject attack;
    public AIDestinationSetter AiDes;
    public AIPath AiPath;
    public Animator anim;
    public Rigidbody2D rgb;
    public float penalty = 1f;
    public int hp;
    float attackTimer;
    float buggingTimer1;
    float buggingTimer2;
    public bool isDead;


    // Start is called before the first frame update
    void Start()
    {
        AiDes = GetComponent<AIDestinationSetter>();
        AiPath = GetComponent<AIPath>();
        anim = GetComponent<Animator>();
        InvokeRepeating(nameof(RandomRotation), 2f, 8f);
        hp = Random.Range(3, 10);
        rgb = GetComponent<Rigidbody2D>();
        attackTimer = 1;
        isDead = false;
     
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Vector2.Distance(AiDes.target.position, this.transform.position) < 5f)
        {
            anim.SetBool("attacking", true);
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                attackTimer = 1;
                Instantiate(attack, new Vector3(transform.position.x, transform.position.y, attack.transform.position.z), Quaternion.identity);
            }
        }
        else
        {
            anim.SetBool("attacking", false);
        }

        if(AiDes.target.gameObject.tag == "Finish" )
        {
            AiDes.target = target.transform;
        }
        
    }

    void RandomRotation()
    {
        int center_rotation;
        center_rotation = Random.Range(0, 360);
        targetCenter.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, center_rotation);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if(other.tag == "Player" || other.tag == "ally")
        {

            if (AiDes.target == target.transform || Vector2.Distance(AiDes.target.position, this.transform.position) > Vector2.Distance(other.transform.position, this.transform.position))
            {
                Transform destination;
                destination = other.transform;
                AiDes.target = destination;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "ally")
        {
            AiDes.target = target.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            hp -= GameInformations.damage;
            anim.SetTrigger("hurt");
        }


        if (hp <= 0 && isDead == false)
        {
            anim.SetBool("Death", true);
            isDead = true;
            AiPath.maxSpeed = 0;
            target = this.gameObject;
            Invoke("DestroyZombie", 0.6f);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        //preventing zombies from bugging on each other
        
    }

    public void DestroyZombie()
    {
        Destroy(gameObject);
    }

}
