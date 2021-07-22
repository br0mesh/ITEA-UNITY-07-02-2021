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
            ActiveNode nodeA = Node.Create<ActiveNode>("NodeA");
            ActiveNode nodeB = Node.Create<ActiveNode>("NodeB");
            PassiveNode nodeC = Node.Create<PassiveNode>("NodeC");
            PassiveNode nodeD = Node.Create<PassiveNode>("NodeD");
            nodeA.Neighbors.Add(nodeB);
            nodeC.Neighbors.Add(nodeB);
            nodeD.Neighbors.Add(nodeA);
            nodeD.Neighbors.Add(nodeC);

            // Add nodes to graph.
            graph.AddNode(nodeA);
            graph.AddNode(nodeB);
            graph.AddNode(nodeC);
            graph.AddNode(nodeD);
        }
        [MenuItem("Window/Graph Serialization Example/Update Graph")]
        public static void UpdateGraph()
        {
            Graph graph = Selection.activeObject as Graph;

            if(graph == null)
            {
                Debug.LogError("Please choose graph object and try again");
                return;
            }

            graph.UpdateGraph();
        }
    }
}
