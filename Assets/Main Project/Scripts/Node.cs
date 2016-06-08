using UnityEngine;
using System.Collections.Generic; // To access lists


/*
 * Based on the tutorial from Lynda.com
 * The node only has the index value upon creation
 * To really mimic the proper and common functions
 * of A* on games, you should include X and Y values
 * to calculate the distance from start to goal
 * 
 */

public class Node {

	public List<Node> adjacent = new List<Node>();
	public Node previous = null;
	public string label = "";

	private int nodeX = 0;
	private int nodeY = 0;


	public void Clear (){
		previous = null;
	}

	public void SetNodeX(int x){
		nodeX = x;
	}
	
	public void SetNodeY(int y){
		nodeY = y;
	}

	
	public int GetNodeX(){
		return nodeX;
	}

	public int GetNodeY(){
		return nodeY;
	}

}
