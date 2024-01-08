using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootScript : MonoBehaviour
{
    public GameObject stuff;
    public int meds;
    public int food;
    public int tech;

    void Start()
    {

    }

    public void Looted()
    {
        this.gameObject.tag = "Untagged";
        GameInformations.meds += meds;
        GameInformations.food += food;
        GameInformations.tech += tech;
        stuff.SetActive(false);
    }
}
