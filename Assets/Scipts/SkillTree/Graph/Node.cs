using Assets.Scipts.SkillTree.SkillPowerUp;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "GraphNode", menuName = "ScriptableObjects/Graph")]
public class Node : ScriptableObject
{

    public int neededLevel;

    public bool doneAdditionalRequirements;

    
    

    [SerializeField] private CharacterStats characterStats; 

    [SerializeField]
    private List<Node> neighbors;
    public List<Node> Neighbors
    {
        get
        {
            if (neighbors == null)
            {
                neighbors = new List<Node>();
            }

            return neighbors;
        }
    }
    public static T Create<T>(string name)
where T : Node
    {
        T node = CreateInstance<T>();
        
        string path = string.Format("Assets/{0}.asset", name);
        AssetDatabase.CreateAsset(node, path);

        return node;
    }

    #region SkillTree
    [SerializeField] private SkillPointState state;
    public SkillPointState State { get => state; }
    public void UpdateState()
    {
        if (state == SkillPointState.Learned)
        {
            return;
        }

        state = SkillPointState.Opened;

        for (int i = 0; i < neighbors.Count; i++)
        {
            
            if (doneAdditionalRequirements == false /*|| neededLevel>=characterStats.CharacterLevel*/)
            {
                state = SkillPointState.RequiredtSmth;
            }

            if (neighbors[i].State != SkillPointState.Learned)
            {
                state = SkillPointState.Closed;
            }
        }
    }
    #endregion //SkillTree
}
[Serializable]
public enum SkillPointState
{
    Closed, Opened, Learned, RequiredtSmth
}
