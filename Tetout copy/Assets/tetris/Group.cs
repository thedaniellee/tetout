using UnityEngine;
using System.Collections;

public class Group : MonoBehaviour {

	float speed = 0.1F;

	bool isValidGridPos() {        
		foreach (Transform child in transform) {
			Vector2 v = Grid.roundVec2(child.position);
			
			// Not inside Border?
			if (!Grid.insideBorder(v))
				return false;
			
			// Block in grid cell (and not part of same group)?
			if (Grid.grid[(int)v.x + Grid.off, (int)v.y] != null &&
			    Grid.grid[(int)v.x + Grid.off, (int)v.y].parent != transform)
				return false;
		}
		return true;
	}

	void updateGrid() {
		// Remove old children from grid
		for (int y = 0; y < Grid.h; y++)
			for (int x = 0; x < Grid.w; x++)
				if (Grid.grid[x, y] != null)
					if (Grid.grid[x, y].parent == transform)
						Grid.grid[x, y] = null;
		
		// Add new children to grid
		foreach (Transform child in transform) {
			Vector2 v = Grid.roundVec2(child.position);
			Grid.grid[(int)v.x + Grid.off, (int)v.y] = child;
		}        
	}

	void Update() {
		transform.position += new Vector3(0, -speed, 0);
		
		// See if valid
		if (isValidGridPos()) {
			// It's valid. Update grid.
			updateGrid();
		} else {
			// It's not valid. revert.
			transform.position += new Vector3(0, speed, 0);
			// Spawn next Group
			FindObjectOfType<Spawner>().spawnNext();
			// Disable script
			enabled = false;
		}
	}
}
