using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ItemMoving : MonoBehaviour {

	public GameObject trash;
	public GameObject score;
	public float sec=0;
	

	// Use this for initialization
	void Start () {
		StartCoroutine(Item());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Item(){
		while(true){
			
			if(sec == 0){
				trash.gameObject.SetActive(true);
				yield return new WaitForSeconds(3.0f);
				trash.gameObject.SetActive(false);
				sec = 1;				
			}

			if(sec == 1){
				score.gameObject.SetActive(true);
				yield return new WaitForSeconds(3.0f);
				score.gameObject.SetActive(false);
				sec = 0;
			}

		}
	}
}
