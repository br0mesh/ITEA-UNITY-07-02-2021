using Assets.Scipts.ResourceManage;
using Assets.Scipts.Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceHarvestComponent : MonoBehaviour
{
    [SerializeField] private int resourceAmount;
    public int ResourceAmount { get => resourceAmount; }

    [SerializeField] private float timeToHarvest;
    public float TimeToHarvest { get => timeToHarvest; }

    [SerializeField] private ResourceScriptableObject resourceData;

    [SerializeField] private ResourceManager resourceManager;

    private IEnumerator harvestCoroutine;
    //private BaseResource baseResource;
    private void Start()
    {
        harvestCoroutine = Harvest();

        StartHarvest();
    }

    [ContextMenu("StartHarvest")]
    public void StartHarvest()
    {
        StartCoroutine(harvestCoroutine);
    }

    [ContextMenu("StopHarvest")]
    public void StopHarvest()
    {
        StopCoroutine(harvestCoroutine);
    }
    private IEnumerator Harvest()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToHarvest);

            resourceManager.AddResource(resourceData.Type, resourceAmount);
            //baseResource.Value += resourceAmount;
            Debug.Log("Resource harvested");
        }
    }
}
