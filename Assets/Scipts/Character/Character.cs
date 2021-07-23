﻿using Assets.Scipts.Building;
using Assets.Scipts.Components;
using Assets.Scipts.ResourceManage;
using Assets.Scipts.Resources;
using Assets.Scipts.SkillTree.SkillPowerUp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scipts.Character
{
    public class Character : MonoBehaviour
    {
       // [SerializeField] private ResourceManager resourceManager;
        [SerializeField] private BuildingPlace buildingPlace;

        [SerializeField] private HealthComponent healthComponent;
        [SerializeField] private AttackComponent attackComponent;
        [SerializeField] private ColliderComponent colliderComponent;

        [SerializeField] private HealOnLowHealth healhtAbility;

        //[SerializeField] private ResourceScriptableObject res;
        [ContextMenu("test")]
        private void test()
        {
            if(healhtAbility.CanUseAbility(healthComponent))
            {
                IEnumerator heal = healhtAbility.UseAbility(healthComponent);
                StartCoroutine(heal);
            }
            //((IAttackComponent)attackComponent).ApplyDamage(healthComponent);
        }
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
                MakeAttack();
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                var a = GetComponent<SkillTreeCharacter>();
                if(a.graph.Nodes[0].State == SkillPointState.Learned)
                {
                    GetComponentInChildren<SuperAttack>().UseAbility(this);
                }
            }
        }

        public void MakeAttack()
        {
            var a = GetAllHealthComponent(colliderComponent.CollidersInRadius.ToArray());

            for (int i = 0; i < a.Length; i++)
            {
                attackComponent.ApplyDamage(a[i]);
            }
        }

        public void BuildBuilding()
        {
            var  wood =ResourceManager.Instance.GetResource(ResourceType.wood);
            //if (resourceManager.GetResource(re).Value < buildingPlace.GetUpgradePrice())
            //{
            //    Debug.LogError("Incorrect money amount");
            //    return;
            //}

            //resourceManager.Money.Value -= buildingPlace.GetUpgradePrice();

            //buildingPlace.Build();
        }

        private HealthComponent[] GetAllHealthComponent(Collider2D[] colliders)
        {
            List<HealthComponent> healthComponents = new List<HealthComponent>();
            for (int i = 0; i < colliders.Length; i++)
            {
                Component component;
                if (colliders[i].gameObject.TryGetComponent(typeof(HealthComponent), out component))
                {
                    healthComponents.Add((HealthComponent)component);
                }
            }
            return healthComponents.ToArray();
        }
    }
}
