using UnityEngine;
using System.Collections;


public class Graph {

	public int rows;
	public int columns;

	public Node[] nodes;


	/*
	 * In C#, you can have commas (,) inside the array brackets (arr[])
	 * to represent multi-dimension arrays
	 * 
	 * Example: arr[,] is the same as arr[][]
	 * 
	 * 
	 * 
	 * When creating a simple grid-based graph for path-finding,
	 * 0 represents path tile
	 * 1 represents solid tile
	 * 
	 */

	public Graph (int[,] grid){ 
		rows = grid.GetLength(0);
		columns = grid.GetLength(1);

		nodes = new Node[grid.Length];

		for (int i  = 0; i < nodes.Length; ++i){
			Node node = new Node();
			node.label = i.ToString();
			nodes[i] = node;
		}

		for (int r = 0; r < rows; ++r){
			for (int c = 0; c < columns; ++c){
				Node node = nodes[columns * r + c];

				if (grid[r,c] == 1){
					continue;
				}

				//Up
				if (r > 0){
					node.adjacent.Add(nodes[columns * (r-1) + c]);
				}
				
				// Right
				if (c < columns - 1){
					node.adjacent.Add(nodes[columns * r + c + 1]);
				}

				// Down
				if (r < rows-1){
					node.adjacent.Add(nodes[columns * (r+1) + c]);
				}

				// Left
				if (c > 0){
					node.adjacent.Add(nodes[columns * r + c - 1]);
				}



			}
		}

	}

}
