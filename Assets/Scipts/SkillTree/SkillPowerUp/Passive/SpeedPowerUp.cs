using Assets.Scipts.SkillTree.SkillPowerUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour, IAbility
{
    [SerializeField] CharacterStats characterStats;
    [SerializeField] float speedPowerUp;
    public bool usedAbility;
    public float SpeedPower { get => speedPowerUp; }
    public bool CanUseAbility()
    {
        return false;
    }

    public void UseAbility()
    {
        if (!usedAbility)
        {
            characterStats.changeStats(this);
        }
    }

}
