﻿using UnityEngine;
using System.Collections;

public class paddle : MonoBehaviour {

	float speed = .3F;
	//float prevX = 0;

	// Use this for initialization
	public void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
		float xPos = transform.position.x;
		float x = Input.GetAxis ("Horizontal") * speed;
		xPos += x;
		float max = 6;
		xPos = Mathf.Clamp (xPos, -max, max);
		transform.position = new Vector3(xPos, -16, 0);
		//prevX = x;
	}
}
