using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_itemRotation : MonoBehaviour {
	public float rotSpeed = 100f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0, rotSpeed*Time.deltaTime, 0));
	}
}
