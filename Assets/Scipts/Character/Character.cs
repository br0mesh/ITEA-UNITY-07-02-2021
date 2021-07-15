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
        [SerializeField] private AttackComponent2 energyLeak;
        [SerializeField] private AttackComponent3 damage3;
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
                var b = GetAllEnergyComponent(colliderComponent.CollidersInRadius.ToArray());
                var a = GetAllHealthComponentFiering(colliderComponent.CollidersInRadius.ToArray());
                for (int i = 0; i < b.Length; i++)
                {
                    attackComponent.ApplyDamage(b[i]);
                    energyLeak.ApplyEnergyLeak(b[i]);
                   
                    damage3.ApplyEnergyLeak(a[i]);
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

        private HealthComponentFiering[] GetAllHealthComponentFiering(Collider2D[] colliders)
        {
            List<HealthComponentFiering> healthComponents = new List<HealthComponentFiering>();
            for (int i = 0; i < colliders.Length; i++)
            {
                Component component;
                if (colliders[i].gameObject.TryGetComponent(typeof(HealthComponentFiering), out component))
                {
                    healthComponents.Add((HealthComponentFiering)component);
                }
            }
            return healthComponents.ToArray();
        }

        /* Find energy components (added element)*/
        private HealthComponent2[] GetAllEnergyComponent(Collider2D[] colliders)
        {
            List<HealthComponent2> energyComponents = new List<HealthComponent2>();
            for (int i = 0; i < colliders.Length; i++)
            {
                Component component;
                if (colliders[i].gameObject.TryGetComponent(typeof(HealthComponent2), out component))
                {
                    energyComponents.Add((HealthComponent2)component);
                }
            }
            return energyComponents.ToArray();
        }
    }
}
