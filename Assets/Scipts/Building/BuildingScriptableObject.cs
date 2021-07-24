using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scipts.Building
{
    [CreateAssetMenu(fileName = "Buildings", menuName = "ScriptableObjects/Buildings", order = 1)]
    public class BuildingScriptableObject : ScriptableObject
    {
        [SerializeField] private GameObject buildingPrefab;
        public void Spawn(Transform loc)
        {
            Instantiate(buildingPrefab,loc);
        }
    }

}
