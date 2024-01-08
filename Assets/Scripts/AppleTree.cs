using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public float defaultAppleTime;
    float appleTimer;
    public GameObject apples;
    public AstarPath AsPath;
    // Start is called before the first frame update
    void Start()
    {
        apples.SetActive(false);
        this.gameObject.tag = "Untagged";
        AsPath = GameObject.Find("A*").GetComponent<AstarPath>();

        if(AsPath)
        AsPath.Scan();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.tag != "loot")
        {
            appleTimer += Time.deltaTime;
            if(appleTimer > defaultAppleTime)
            {
                this.gameObject.tag = "loot";
                appleTimer = 0;
                apples.SetActive(true);

            }
        }
    }
}
