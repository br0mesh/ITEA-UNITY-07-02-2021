using Assets.Scipts.Components;
using UnityEngine;

public class BuildingComponent : MonoBehaviour
{
    [SerializeField] private BuildingScriptableObject building;
    public BuildingScriptableObject Building { get => building; }

    public HealthComponent HealthComponent { get => healthComponent; }

    private HealthComponent healthComponent;
    private SpriteRenderer spriteRenderer;

    public void Init(BuildingScriptableObject building)
    {
        this.building = building;
        healthComponent.Health = building.health;
        spriteRenderer.sprite = building.sprite;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("Sprite Renderer == null");
        }

        healthComponent = GetComponent<HealthComponent>();

        if (healthComponent == null)
        {
            Debug.LogError("Health Component == null");
        }
    }
}
