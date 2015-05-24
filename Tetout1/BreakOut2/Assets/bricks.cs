using UnityEngine;
using System.Collections;

public class bricks : MonoBehaviour {

	private bool stopped;
	private float speed = 0.03F;

	public GameObject blockPrefab;

	// Use this for initialization
	public void Start () {
		//populate with bricks
		int yOff = 10;
		for (int x = -10; x <= 10; x++) {
			for(int y = 0; y < 3; y++) {
				GameObject block = Instantiate (blockPrefab, new Vector3(x, y + yOff, 0), Quaternion.identity) as GameObject;
				block.transform.parent = transform;
				Rigidbody rb = block.rigidbody;
				rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
			}
		}
		stopped = false;
	}
	
	// Update is called once per frame
	public void Update () {
		if (!stopped) {
			Vector3 pos = transform.position;
			float y = pos.y - speed;
			transform.position = new Vector3 (pos.x, y, 0);
		}
	}
	
	public void OnCollisionEnter(Collision c) {
		GameObject o = c.gameObject;
		Debug.Log ("IN" + o.name);
		if (o.name == "piece floor") {
			stopped = true;
		} else if (o.name == "blockPrefab(Clone)") {
			o.transform.parent = transform;
		}
	}

	public void OnCollisionExit(Collision c) {
		GameObject o = c.gameObject;
		Debug.Log ("OUT" + o.name);
		if (o.name == "piece floor") {
			stopped = false;
		}
	}
}
