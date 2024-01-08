using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoorsScript : MonoBehaviour
{
    public hiding_top hidingTop;
    Animator anim;
    bool phisicalDetector;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hidingTop.isInside == true)
        {
            anim.SetBool("detected", true);
        }

        if(hidingTop.isInside == false && phisicalDetector == false)
        {
            anim.SetBool("detected", false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(hidingTop.isInside == false && (collision.tag == "Player" || collision.tag == "enemy"))
        {
            anim.SetBool("detected", true);
            phisicalDetector = true;
        }    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "enemy")
        {
            anim.SetBool("detected", false);
            phisicalDetector = false;
        }
    }
}
