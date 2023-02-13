using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleUp : MonoBehaviour {

	Vector3 velo = Vector3.zero;	
	public Transform target;
	public GameObject nameInput;
	public GameObject rankTitle;
	public GameObject ranking;

	float timer = 0.0f;
	public float activeTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer+= Time.deltaTime;
		if(timer > activeTime){
			transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velo, 0.35f);
		}

		if(timer > activeTime+3.0f){
			nameInput.gameObject.SetActive(true);
			rankTitle.gameObject.SetActive(true);
			ranking.gameObject.SetActive(true);

		}

		
		
	}
}
