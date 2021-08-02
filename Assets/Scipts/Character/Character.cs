using Assets.Scipts.Building;
using Assets.Scipts.Components;
using Assets.Scipts.Components.InputComponents;
using Assets.Scipts.Components.MovementComponents;
using Assets.Scipts.ResourceManage;
using Assets.Scipts.Resources;
using Assets.Scipts.SkillTree.Graph;
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
        [SerializeField] private HealthComponent healthComponent;
        [SerializeField] private Collider2D healthCollider;

        [SerializeField] private AttackComponent attackComponent;
        [SerializeField] private ColliderComponent attackCollider;
        [SerializeField] private BlockComponent blockComponent;

        [SerializeField] private CharacterBaseInputComponent inputComponent;
        [SerializeField] private MovementComponent movementComponent;
        [SerializeField] private CharacterAnimatorComponent characterAnimatorComponent;


        private void Awake()
        {
            movementComponent.Init(transform);
            characterAnimatorComponent.Init(transform);
            blockComponent.Init(healthCollider);

            inputComponent.OnCharacterMove += movementComponent.Move;
            inputComponent.OnCharacterMove += characterAnimatorComponent.OnCharaterMove;
            inputComponent.OnCharacterAttack += characterAnimatorComponent.OnCharacterAttack;
            inputComponent.OnCharacterBlock += blockComponent.Block;
            characterAnimatorComponent.OnAttackExecuted += ExecuteAttack;
        }

        private void OnDestroy()
        {
            inputComponent.OnCharacterMove -= movementComponent.Move;
            inputComponent.OnCharacterMove -= characterAnimatorComponent.OnCharaterMove;
            inputComponent.OnCharacterAttack -= characterAnimatorComponent.OnCharacterAttack;
            inputComponent.OnCharacterBlock -= blockComponent.Block;
            inputComponent.OnCharacterAttack -= ExecuteAttack;
        }

        private void ExecuteAttack()
        {
            HealthComponent[] healthComponents = GetAllHealthComponent(attackCollider.CollidersInRadius.ToArray());

            attackComponent.ApplyDamage(healthComponents);
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
