using Assets.Scipts.SkillTree.Graph;
using Assets.Scipts.SkillTree.SkillPowerUp;
using System;
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
        SetCollider();
    }

    private void SetCollider()
    {
        BoxCollider2D coll = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        coll.isTrigger = true;
        coll.size = new Vector2(100f, 100f);
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
    public void OnMouseEnter()
    {
        Debug.Log(abilityNode.abilityData.Name);
    }

    public static Action OnUpdateState;
    public void OnMouseDown()
    {
        if(abilityNode.State == SkillPointState.Opened)
        {
            abilityNode.MakeLearned();
            abilityNode.UpdateState();
            OnUpdateState?.Invoke();
        }
    }


}
