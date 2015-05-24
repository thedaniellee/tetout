using UnityEngine;
using System.Collections;

public class floor : MonoBehaviour {

	// Use this for initialization
	public void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
	
	}

	public void OnTriggerEnter(Collider other) {
		GameObject g = other.gameObject;
		/*
		Transform t = g.transform;
		if (t.parent != null) {
			Transform t2 = t.parent;
			if(t2.childCount <= 1) {
				GameObject g2 = t2.gameObject;
				Destroy (g2);
			}
		}
		Destroy(g);
		*/
		if (g.name == "ball") {
			//game over, skrub
			Destroy (g);
		}
	}
}
