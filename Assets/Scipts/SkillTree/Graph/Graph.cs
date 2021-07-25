using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Graph : ScriptableObject
{
    [SerializeField]
    private List<Node> nodes;
    public List<Node> Nodes
    {
        get
        {
            if (nodes == null)
            {
                nodes = new List<Node>();
            }

            return nodes;
        }
    }

    public static Graph Create(string name)
    {
        Graph graph = CreateInstance<Graph>();

        string path = string.Format("Assets/{0}.asset", name);
        AssetDatabase.CreateAsset(graph, path);

        return graph;
    }

    public void AddNode(Node node)
    {
        Nodes.Add(node);
        //AssetDatabase.AddObjectToAsset(node, this);
        //AssetDatabase.SaveAssets();
    }
    public void UpdateGraph()
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            nodes[i].UpdateState();
        }
    }
    public static class CreateGraphExample
    {
        [MenuItem("Window/Graph Serialization Example/Create Graph")]
        public static void CreateGraph()
        {
            // Create graph.
            Graph graph = Graph.Create("NewGraph");

            // Create nodes.
            Node nodeA = Node.Create<Node>("HealOnLowHealth");
            SpriteNode nodeB = Node.Create<SpriteNode>("ComboAttackAbility");
            SpriteNode nodeC = Node.Create<SpriteNode>("ShieldAbility");

            nodeA.Neighbors.Add(nodeB);
            nodeC.Neighbors.Add(nodeB);

            // Add nodes to graph.
            graph.AddNode(nodeA);
            graph.AddNode(nodeB);
            graph.AddNode(nodeC);
        }
        [MenuItem("Window/Graph Serialization Example/Update Graph")]
        public static void UpdateGraph()
        {
            Graph graph = Selection.activeObject as Graph;

            if (graph == null)
            {
                Debug.LogError("Please choose graph object and try again");
                return;
            }

            graph.UpdateGraph();
        }
    }
}
