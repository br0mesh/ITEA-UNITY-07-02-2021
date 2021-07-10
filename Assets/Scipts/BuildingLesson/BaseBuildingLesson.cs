using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuildingLesson : MonoBehaviour
{
    [SerializeField] private GameObject buildingPrefab;
    [SerializeField] private Transform buildingPlace;
    public void Init()
    {

    }
    public void Spawn(Transform parent)
    {
        Instantiate(buildingPrefab, parent);
    }
}
