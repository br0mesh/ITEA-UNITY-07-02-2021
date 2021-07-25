using Assets.Scipts.SkillTree.Graph;
using Assets.Scipts.SkillTree.SkillPowerUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUIView : MonoBehaviour
{
    [SerializeField] private Text skillName;
    [SerializeField] private Image skillImage;

    private AbilityNode abilityNode;
    public void Init(AbilityNode abilityData)
    {
        abilityNode = abilityData;

        skillImage.sprite = abilityData.abilityData.Sprite;
        skillName.text = abilityData.abilityData.Name;

        SetState(abilityData.State);
    }

    public void SetState(SkillPointState state)
    {
        switch (state)
        {
            case SkillPointState.Closed:
                skillImage.color = Color.red;
                break;
            case SkillPointState.Opened:
                skillImage.color = Color.white;
                break;
            case SkillPointState.Learned:
                skillImage.color = Color.blue;
                break;
            default:
                break;
        }
    }
}
