using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	

	// Update is called once per frame
	void Update () {
	}
	
	public void Enter(Collision c) {
		bricks br = GameObject.Find("brick holder").GetComponent<bricks>();		
		Debug.Log(br.gameObject.name);

	}