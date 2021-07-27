using Assets.Scipts.SkillTree.Graph;
using System.Collections.Generic;
using UnityEngine;
using System;

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
        UpdatePanelUI();

        skillUIHolder.gameObject.SetActive(value);
    }

    public void OnEnable()
    {
        SkillUIView.OnUpdateState += UpdatePanelUI;
    }
    private void UpdatePanelUI()
    {
        for (int i = 0; i < abilityDatas.Length; i++)
        {
            abilityDatas[i].UpdateState();
            skillUIViews[i].Init(abilityDatas[i]);
        }
    }
}
