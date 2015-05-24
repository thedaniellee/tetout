using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private float initialVelocity = 20F;

	private Rigidbody rb;

	private bool ballInPlay = false;

	// Use this for initialization
	public void Awake () {
		rb = GetComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
	}
	
	// Update is called once per frame
	public void Update () {
		if (Input.GetButtonDown ("Fire1") && !ballInPlay) {
			float x = transform.parent.position.x;
			transform.parent.gameObject.AddComponent("paddleSpin");
			transform.parent = null;
			ballInPlay = true;
			rb.isKinematic = false;
			rb.AddForce(new Vector3 (x, 10, 0));
		}

		if (ballInPlay) {
			Vector3 velocity = rb.velocity;
			velocity.Normalize ();
			rb.velocity = new Vector3(velocity.x * initialVelocity, velocity.y * initialVelocity, velocity.z * initialVelocity);
			Vector3 pos = rb.position;
			rb.position = new Vector3 (pos.x, pos.y, 0);
		}
	}

	public void OnCollisionEnter(Collision c) {
		GameObject o = c.gameObject;
		if (o.name == "blockPrefab(Clone)") {
			Destroy (o);
		}
	}
}
