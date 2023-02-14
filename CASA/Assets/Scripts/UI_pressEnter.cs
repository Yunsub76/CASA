using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_pressEnter : MonoBehaviour {
	public GameObject nextUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)){
			Destroy(this.gameObject);
			nextUI.SetActive(true);
		}
		
	}
}
