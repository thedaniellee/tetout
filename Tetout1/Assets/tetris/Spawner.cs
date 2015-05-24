using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] groups;
	
	void Start(){
		spawnNext ();
	}

	public void spawnNext() {
		// Random Index
		if (Grid.maxHeight () < Grid.h - 5) {
			int i = Random.Range(0, groups.Length);
			
			// Spawn Group at current Position
			int xOff = Random.Range (2, Grid.w - 2); //Grid.minHeight();
			//int off = 1;
			//xOff = Mathf.Clamp(xOff, off, Grid.w - off);
			Vector3 v = new Vector3(xOff, Grid.h - 4, 0);
			GameObject o = Instantiate (groups [i],
			                            new Vector3 (v.x + xOff - Grid.off, v.y, v.z),
			                            Quaternion.identity) as GameObject;
			o.layer = 8;
		}
	}

	public void Update() {
		if (Grid.maxHeight () < 0) {
			spawnNext ();
		}
	}
}
