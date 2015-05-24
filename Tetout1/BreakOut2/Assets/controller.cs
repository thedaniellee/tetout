using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
	
	public GameObject blockPrefab;
	public GameObject piecePrefab;

	float prevTime;

	Vector2[][] types;

	// Use this for initialization
	public void Start () {
		prevTime = Time.time;
		types = new Vector2[][] {
			new Vector2[]{
				//square
				new Vector2(0, 0),
				new Vector2(1, 0),
				new Vector2(0, 1),
				new Vector2(1, 1)
			},
			new Vector2[]{
				//line
				new Vector2(0, 0),
				new Vector2(0, 1),
				new Vector2(0, 2),
				new Vector2(0, 3)
			},
			new Vector2[]{
				//line
				new Vector2(0, 0),
				new Vector2(1, -1),
				new Vector2(1, 0),
				new Vector2(1, 1)
			},
			new Vector2[]{
				//line
				new Vector2(0, 0),
				new Vector2(0, 1),
				new Vector2(1, 1),
				new Vector2(1, 2)
			},
			new Vector2[]{
				//line
				new Vector2(0, 0),
				new Vector2(0, -1),
				new Vector2(1, -1),
				new Vector2(1, -2)
			},
			new Vector2[]{
				//line
				new Vector2(0, 0),
				new Vector2(0, 1),
				new Vector2(1, 1),
				new Vector2(2, 1)
			},
			new Vector2[]{
				//line
				new Vector2(0, 0),
				new Vector2(0, -1),
				new Vector2(1, -1),
				new Vector2(2, -1)
			}
		};
	}
	
	// Update is called once per frame
	public void Update () {
		if (Time.time - prevTime > 1F) {
			int xOff = Random.Range(-5, 6);
			int yOff = 15;
			GameObject piece = Instantiate (piecePrefab, new Vector3 (xOff, yOff, 0), Quaternion.identity) as GameObject;
			Vector2[] v = types[Random.Range(0, types.Length)];
			for (int i = 0; i < v.Length; i++) {
				//int switcher = Random.Range (0, 3);
				Vector2 v2 = v[i];
				GameObject block = Instantiate (blockPrefab, new Vector3(v2.x + xOff, v2.y + yOff, 0), Quaternion.identity) as GameObject;
				block.transform.SetParent (piece.transform);
				Rigidbody rb = block.rigidbody;
				rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
			}
			piece.AddComponent("piece");
			prevTime = Time.time;
		}
	}
}
