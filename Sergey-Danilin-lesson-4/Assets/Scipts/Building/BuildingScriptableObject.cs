using Assets.Scipts.Components;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Building", menuName = "ScriptableObjects/Building")]
public class BuildingScriptableObject : ScriptableObject
{
    public string nameBuilding;
    public string description;

    public int priceToBuild;
    public int health;

    public Sprite sprite;
}
