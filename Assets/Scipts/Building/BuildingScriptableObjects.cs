using Assets.Scipts.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "ScriptableObjects/Buildings")]
public class BuildingScriptableObjects : ScriptableObject
{


    public string buildingName;
    public string description;

    public int priceToBuild;
    public int health;

    public Sprite picture;

    public void Print()
    {
        Debug.Log(buildingName + ": " + description + " Will cost you:" + priceToBuild);
    }

}
