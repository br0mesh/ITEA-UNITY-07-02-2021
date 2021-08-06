using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerComponent : MonoBehaviour
{
    public List<BuildingScriptableObject> Buildings;

    [SerializeField] GameObject buildingPrefab;

    private int numberOfBuildings = 4;
    private float wait = 3f;


    void Start()
    {
        StartCoroutine(BuildMore());
    }

    IEnumerator BuildMore()
    {
        for (int i = 0; i < numberOfBuildings; i++)
        {
            BuildNewBuildings(i);
            yield return new WaitForSeconds(wait);
        }
    }

    private void BuildNewBuildings(int index)
    {
        GameObject newBuilding = Instantiate(buildingPrefab, new Vector3(index, 0.5f, 0f), Quaternion.identity);
        BuildingComponent building = newBuilding.GetComponent<BuildingComponent>();

        if (building == null)
        {
            return;
        }

        building.Init(Buildings[index]);
    }
}
