using Assets.Scipts.Building;
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

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private int characterLevel;

    public int CharacterLevel { get => characterLevel; }

    [SerializeField] private float movementSpeed;

    public float MovementSpeed { get => movementSpeed; }

    public void changeStats (SpeedPowerUp skill)
    {
        movementSpeed += skill.SpeedPower;
        skill.usedAbility = true;
    }
}