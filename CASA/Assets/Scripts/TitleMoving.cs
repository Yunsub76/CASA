using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleMoving : MonoBehaviour {

	Vector3 velo = Vector3.zero;
	public Transform target;
	public GameObject centerObject;

	void Move(){
		transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velo, 0.35f);
		
	}

	void Update(){
		//Move();


	}
	
	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "center"){
			//Debug.Log("DD");
			this.gameObject.GetComponent<titleUp>().enabled = true;
		}
	}

}
	

