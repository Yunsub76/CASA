using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour {
	public float S;
	bool xy = true;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update() {

		if (transform.position.x >= 150)
		{
			xy = false;
		}
		else if(transform.position.x <= -150)
		{
			xy = true;
		}
		if (xy == true) 
		{
			transform.position = new Vector3(transform.position.x + S, transform.position.y, transform.position.z);
			//Debug.Log(transform.position.x);
		}
		if (xy == false)
		{
			transform.position = new Vector3(transform.position.x - S, transform.position.y, transform.position.z);
			//Debug.Log(transform.position.x);
		}
	}
}
