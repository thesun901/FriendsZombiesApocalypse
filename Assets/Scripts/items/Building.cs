using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Building
{
    public int id;
    public string name;

    public int woodCost;
    public int rockCost;
    public int techCost;
    public int foodCost;
    public int medCost;
    public int gasCost;

    public string description;
    public Sprite image;

    public GameObject building;
}
