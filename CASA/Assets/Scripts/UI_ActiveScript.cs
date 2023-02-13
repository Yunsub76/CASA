using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ActiveScript : MonoBehaviour {
	public GameObject activeObject;

	float timer = 0.0f;
	public float activeTime;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer>activeTime){
			activeObject.gameObject.SetActive(true);
		}
	}
}
