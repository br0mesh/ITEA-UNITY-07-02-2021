using Assets.Scipts.SkillTree.Graph;
using Assets.Scipts.SkillTree.SkillPowerUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanelUI : MonoBehaviour
{
    [SerializeField] private GameObject skillUIviewPrefab;

    [SerializeField] private RectTransform skillUIHolder;

    private AbilityNode[] abilityDatas;
    private List<SkillUIView> skillUIViews;

    public void Init(AbilityNode[] abilityDatas)
    {

        this.abilityDatas = abilityDatas;
        skillUIViews = new List<SkillUIView>(abilityDatas.Length);

        SetupAbilities();
    }

    private void SetupAbilities()
    {
        for (int i = 0; i < abilityDatas.Length; i++)
        {
            SkillUIView skillUIView = Instantiate(skillUIviewPrefab, skillUIHolder).GetComponent<SkillUIView>();

            if (skillUIView != null)
            {
                skillUIView.Init(abilityDatas[i]);
                skillUIViews.Add(skillUIView);
            }
        }
    }
    public void SetActive(bool value)
    {
        skillUIHolder.gameObject.SetActive(value);
    }
}
