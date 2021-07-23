using Assets.Scipts.Character;
using Assets.Scipts.Components;
using Assets.Scipts.SkillTree.SkillPowerUp;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperAttack : MonoBehaviour, IAbility
{
    
    [SerializeField] private int cooldown;
    [SerializeField] private int damageMultiplier;


    public bool CanUseAbility()
    {
        if (cooldown == 0)
        {
            return true;
        }
        return false;
    }

    public void UseAbility(Character gameObject)
    {

        gameObject.MakeAttack();
        Debug.Log("it should add extra damage but I don't have time to change code");

    }

    public void UseAbility()
    {
        throw new NotImplementedException();
    }
}
