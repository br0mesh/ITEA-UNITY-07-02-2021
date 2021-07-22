using Assets.Scipts.Components;
using UnityEngine;

public class TemplateBuilding : MonoBehaviour
{

    public BuildingScriptableObjects Building;
    public HealthComponent healthComponent;

    public string buildingName;
    public string description;

    public int priceToBuild;
    public int health;

    private void Start()
    {
        this.buildingName = Building.buildingName;
        this.description = Building.description;
        this.priceToBuild = Building.priceToBuild;
        this.health = Building.health;

        GetComponent<SpriteRenderer>().sprite = Building.picture;
        GetComponent<HealthComponent>().Health = Building.health;
       
    }

}
