using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour {
	public float S;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update() {

		if (transform.position.x >= 750)
		{
			transform.position = new Vector3(-750, 133 + 58, 6- 23.46576f);
		}
		else 
		{ 
		transform.position = new Vector3(transform.position.x + S, 133 + 58, 6 - 23.46576f);
		Debug.Log(transform.position.x);
		}
	}
}
