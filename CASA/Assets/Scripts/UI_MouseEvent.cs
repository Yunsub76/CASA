using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_MouseEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnMouseEnter(){
		Destroy(this.gameObject);
		Debug.Log("EE");
	}

	void OnMouseUp(){
		Debug.Log("EE");
		Destroy(this.gameObject);
	}

}
