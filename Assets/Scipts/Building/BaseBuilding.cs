using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuilding : MonoBehaviour
{
    [SerializeField] private BaseBuilding builingUpgradePrefab;
    public BaseBuilding BuildingToUpgrade { get=> builingUpgradePrefab; }

    private bool isBuilded;
    public bool IsBuilded { get => isBuilded; }

    [SerializeField] private int price;
    public int Price { get=> price; }
    public void Init()
    {

    }

    public void DestroyBuiling()
    {
        Destroy(gameObject);
    }
    public void Build()
    {
        isBuilded = true;
    }
}
