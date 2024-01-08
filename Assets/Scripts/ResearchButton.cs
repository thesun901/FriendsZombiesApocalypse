using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchButton : MonoBehaviour
{
    public ResearchTable rt;
    private void OnMouseDown()
    {
        Debug.Log("click click click");
        rt.ResearchClick();
    }

 
}
