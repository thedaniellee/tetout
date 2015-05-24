using UnityEngine;
using System.Collections;

public class paddleSpin : MonoBehaviour {

	float start;

	public void Start() {
		start = Time.time;
	}
	
	// Update is called once per frame
	public void Update () {
		float a = Time.time - start;
		float sin = Mathf.Sin (a/2F);
		float cos = Mathf.Cos (a/2F);
		/*
x = RotationAxis.x * sin(RotationAngle / 2)
y = RotationAxis.y * sin(RotationAngle / 2)
z = RotationAxis.z * sin(RotationAngle / 2)
w = cos(RotationAngle / 2)
		 */
		transform.rotation = new Quaternion (sin, 0, 0, cos);
	}
}
