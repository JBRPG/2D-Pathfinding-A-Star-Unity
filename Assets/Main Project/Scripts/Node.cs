using UnityEngine;
using System.Collections.Generic; // To access lists

public class Node {

	public List<Node> adjacent = new List<Node>();
	public Node previous = null;
	public string label = "";


	public void Clear (){
		previous = null;
	}

}
