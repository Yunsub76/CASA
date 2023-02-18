using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MissionAnm : MonoBehaviour {
	Vector3 velo = Vector3.zero;
	public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velo, 0.5f);
	}
}
