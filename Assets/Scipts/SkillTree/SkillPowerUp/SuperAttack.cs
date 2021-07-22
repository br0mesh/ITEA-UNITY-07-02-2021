using Assets.Scipts.Components;
using Assets.Scipts.SkillTree.SkillPowerUp;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAttack : IAbility
{
    
    [SerializeField]private int cooldown;
    [SerializeField] private int damageMultiplier;


    public bool CanUseAbility()
    {
        if (cooldown == 0)
        {
            return true;
        }
        return false;
    }

    public void UseAbility()
    {
        throw new System.NotImplementedException(); // need to improve 
    }

}
