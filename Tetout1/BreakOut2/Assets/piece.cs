using UnityEngine;
using System.Collections;

public class piece : MonoBehaviour {

	// Use this for initialization
	public void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
		Vector3 pos = transform.position;
		float y = pos.y - 0.1F;
		transform.position = new Vector3 (pos.x, y, 0);
		if (y < -25) {
			Destroy (gameObject);
		}
	}
}
