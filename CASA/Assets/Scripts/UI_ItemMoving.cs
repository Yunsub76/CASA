using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ItemMoving : MonoBehaviour {

	public GameObject paper;
	public GameObject can;
	public GameObject plastic;
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
				score.gameObject.SetActive(true);
				yield return new WaitForSeconds(3.0f);
				score.gameObject.SetActive(false);
				sec = 1;				
			}

			if(sec == 1){
				paper.gameObject.SetActive(true);
				yield return new WaitForSeconds(3.0f);
				paper.gameObject.SetActive(false);
				sec = 2;
			}

			if(sec == 2){
				can.gameObject.SetActive(true);
				yield return new WaitForSeconds(3.0f);
				can.gameObject.SetActive(false);
				sec = 3;
			}

			if(sec == 3){
				plastic.gameObject.SetActive(true);
				yield return new WaitForSeconds(3.0f);
				plastic.gameObject.SetActive(false);
				sec = 0;
			}

		}
	}
}
