using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public static int off = 5;
	public static int w = 11;
	public static int h = 30;
	public static int bottom = 3;
	public static Transform[,] grid = new Transform[w, h];

	public static Vector2 roundVec2(Vector2 v) {
		return new Vector2(Mathf.Round(v.x),
		                   Mathf.Round(v.y));
	}
	//insideBorder helpter Function 
	public static bool insideBorder(Vector2 pos) {
		return ((int)pos.x > 0 - Grid.off &&
		        (int)pos.x < w - Grid.off &&
		        (int)pos.y >= bottom);
	}
	//decreaseRow helper function 
	public static void decreaseRow(int y) {
		for (int x = 0; x < w; x++) {
			if (grid[x, y] != null) {
				// Move one towards bottom
				grid[x, y-1] = grid[x, y];
				grid[x, y] = null;
				
				// Update Block position
				grid[x, y-1].position += new Vector3(0, -1, 0);
			}
		}
	}

	public static int maxHeight() {
		for (int x = 0; x < w; x++) {
			for(int y = h - 1; y >= 0; y--) {
				if(grid[x, y] != null) return y;
			}
		}
		return -1; //no blocks
	}
	/*
	public static int minHeight() {
		int min = h;
		int x2 = 0;
		for (int x = 0; x < w; x++) {
			for(int y = h - 1; y >= 0; y--) {
				if(grid[x, y] != null) {
					if(y < min) {
						min = y;
						x2 = x;
					}
					break;
				}
			}
		}
		return x2;
	}
	*/
} 
