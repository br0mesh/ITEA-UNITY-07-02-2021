using Assets.Scipts.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingComponenter : MonoBehaviour
{


    public List<BuildingScriptableObjects> Buildings;
    [SerializeField] TemplateBuilding template;

    // Start is called before the first frame update
    void Start()
    {
        MakeNewBuilding(0);

        MakeNewBuilding(1);
        

    }

    private void MakeNewBuilding(float index)
    {
        template.Building = Buildings[(int)index];
        template.healthComponent.Health = template.Building.health;
        Instantiate(template, new Vector3(index, 0.5f, 0f), Quaternion.identity);
    }

    private void UseScriptableObject()
    {
       // template.des
    }

}
