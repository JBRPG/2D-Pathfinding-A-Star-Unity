using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

/*
 *  
*/

public class PathFindingTest : MonoBehaviour {

	public GameObject mapGroup;

	// Use this for initialization
	void Start () {
		int[,] map =  new int [5,5]{

			// 0 represents open space
			// 1 represents solid wall


			/* Let's turn a hard-coded map
			 * into an editable checkbox
			 * with true being solid space
			 * and false being open space
			 * 
			*/

			// For simple test purpose, a simple 2d array map is hard-coded
			{0,1,0,0,0},
			{0,1,0,0,0},
			{0,1,0,0,0},
			{0,1,0,0,0},
			{0,0,0,0,0}
		};

		Graph graph = new Graph(map);

		Search search  = new Search(graph);
		search.Start (graph.nodes[0], graph.nodes[2]);

		while (!search.finished){
			search.Step();
		}

		// when search finished, print out the results
		print ("Search done. Path Length " + search.path.Count + " iterations " + search.iterations);

		ResetMapGroup(graph);

		foreach(Node node in search.path){
			GetImage(node.label).color = Color.red;
		}

	}

	private Image GetImage(string label){
		int id = Int32.Parse(label);
		GameObject tile = mapGroup.transform.GetChild(id).gameObject;
		return tile.GetComponent<Image>();

	}

	private void ResetMapGroup(Graph _graph){
		foreach(Node node in _graph.nodes){
			GetImage(node.label).color =
				node.adjacent.Count == 0 ? Color.grey : Color.white;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
