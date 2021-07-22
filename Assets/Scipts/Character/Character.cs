using Assets.Scipts.Building;
using Assets.Scipts.Components;
using Assets.Scipts.ResourceManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.Character
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private ResourceManager resourceManager;
        [SerializeField] private BuildingPlace buildingPlace;

        [SerializeField] private HealthComponent healthComponent;
        [SerializeField] private AttackComponent attackComponent;
        [SerializeField] private AttackComponent2 attackComponent2;
        [SerializeField] private ColliderComponent colliderComponent;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var buildingPlace = collision.gameObject.GetComponent<BuildingPlace>();

            if (buildingPlace != null)
            {
                this.buildingPlace = buildingPlace;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            var buildingPlace = collision.gameObject.GetComponent<BuildingPlace>();

            if (buildingPlace != null)
            {
                this.buildingPlace = null;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (buildingPlace != null)
                {
                    BuildBuilding();
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                var a = GetAllHealthComponent(colliderComponent.CollidersInRadius.ToArray());

                for (int i = 0; i < a.Length; i++)
                {
                    attackComponent.ApplyDamage(a[i]);
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                var a = GetAllHealthComponent(colliderComponent.CollidersInRadius.ToArray());
                for (int i = 0; i < a.Length; i++)
                {
                    attackComponent2.ApplyDamage(a[i]);
                }
            }
        }
        public void BuildBuilding()
        {
            //if (resourceManager.GetResource(re).Value < buildingPlace.GetUpgradePrice())
            //{
            //    Debug.LogError("Incorrect money amount");
            //    return;
            //}

            //resourceManager.Money.Value -= buildingPlace.GetUpgradePrice();

            //buildingPlace.Build();
        }

        private HealthComponent2[] GetAllHealthComponent(Collider2D[] colliders)
        {
            List<HealthComponent2> healthComponents = new List<HealthComponent2>();
            for (int i = 0; i < colliders.Length; i++)
            {
                Component component;
                if (colliders[i].gameObject.TryGetComponent(typeof(HealthComponent2), out component))
                {
                    healthComponents.Add((HealthComponent2)component);
                }
            }
            return healthComponents.ToArray();
        }
    }
}
