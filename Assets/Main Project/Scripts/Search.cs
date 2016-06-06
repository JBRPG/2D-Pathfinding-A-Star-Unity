using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * We will do the path-finding search through A-Star (A*)
 *
 * 
*/

public class Search
{

	public Graph graph;
	public List<Node> reachable;
	public List<Node> explored;
	public List<Node> path;
	public Node goalNode;
	public int iterations;
	public bool finished;

	public Search (Graph _graph)
	{
		this.graph = _graph;
	}

	public void Start (Node start, Node goal)
	{

		reachable = new List<Node> ();
		reachable.Add (start);

		goalNode = goal;

		/*
		 * Make a new blank graph
		 * by erasing previous data stored, if any
		 */

		explored = new List<Node> ();
		path = new List<Node> ();
		iterations = 0;

		for (int i  = 0; i < graph.nodes.Length; ++i) {
			graph.nodes [i].Clear ();
		}

	}

	public void Step ()
	{
		if (path.Count > 0) {
			return;
		}

		if (reachable.Count == 0) {
			finished = true;
			return;
		}

		iterations++;

		Node node = ChooseNode ();
		if (node == goalNode) {
			while (node != null) {
				path.Insert (0, node);
				node = node.previous;
			}

			finished = true;
			return;
		}


		reachable.Remove (node);
		explored.Add (node);

		for (int i = 0; i < node.adjacent.Count; ++i) {
			AddAdjacent (node, node.adjacent [i]);
		}

	}

	public void AddAdjacent (Node Node, Node adjacent)
	{
		if (FindNode (adjacent, explored) || FindNode (adjacent, reachable)) {
			return;
		}

		adjacent.previous = Node;
		reachable.Add (adjacent);
	}

	public int GetNodeIndex (Node node, List<Node> node_list)
	{
		for (int i = 0; i < node_list.Count; ++i) {
			if (node == node_list [i]) {
				return i;
			}
		}

		return -1;
	}

	public bool FindNode (Node node, List<Node> list)
	{
		return GetNodeIndex (node, list) >= 0;
	}

	/*
	 * 
	 * For simplicity purposes of tutorial,
	 * We simply randomly select a node for path-finding purposes.
	*/

	public Node ChooseNode ()
	{
		return reachable [Random.Range (0, reachable.Count)];
	}



}
