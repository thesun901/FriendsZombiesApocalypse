using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public abstract class ResearchBase
{
    public string name;
    public string desc;
    public float time;
    public Sprite img;
    public bool isResearched = false;

    public abstract void OnResearchChoose(ResearchPanelScripts rps);
    public abstract void OnResearchEnded(ResearchPanelScripts rps);
}
