using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Building")]
public class BuildingScriptableObject : ScriptableObject
{
    public string buildingName;
    public string value;
    public int health;
    public GameObject Prefab;
}
