using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuildings : MonoBehaviour
{
    [SerializeField] private BuildingScriptableObject scriptableObject;
    [SerializeField] private GameObject spawnPoint;
    //private GameObject prefab;
    private void Start()
    {
        //prefab = scriptableObject.Prefab;
        Instantiate(scriptableObject.Prefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

   
}
