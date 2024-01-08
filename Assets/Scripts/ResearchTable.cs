using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchTable : MonoBehaviour
{
    public GameObject square;
    public BasicHeroScript bhs;
    public ResearchPanelScripts rps;
    // Start is called before the first frame update
    void Start()
    {
        square.SetActive(false);
        rps = GameObject.Find("ResearchScripts").GetComponent<ResearchPanelScripts>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            square.SetActive(true);

            if(bhs == null)
            {
                bhs = collision.gameObject.GetComponent<BasicHeroScript>();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            square.SetActive(false);
            bhs = null;
        }
    }

    public void ResearchClick()
    {
        rps.ResearchActivated(this);
    }
}
