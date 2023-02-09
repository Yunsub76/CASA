using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update() {

		if (transform.position.x >= 750)
		{
			transform.position = new Vector3(-750, -49 + 58, 174 - 23.46576f);
		}
		else 
		{ 
		transform.position = new Vector3(transform.position.x + 0.1f, -49 + 58, 174 - 23.46576f);
		Debug.Log(transform.position.x);
		}
	}
}
