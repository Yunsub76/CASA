using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	private int countTime = 0;
	public GameObject Num_A;   // 5초
	public GameObject Num_B;
	public GameObject Num_C;
	public GameObject Num_D;
	public GameObject Num_E;
	public GameObject Num_Start;
	public GameObject nameObj;
	public GameObject message;

	// Use this for initialization
	void Start () {
		countTime = 0;		
	}
	
	// Update is called once per frame
	void Update () {
		if(countTime ==0){
			Time.timeScale = 0.0f;
		}

		if(countTime <= 920){
			countTime++;
		}


		if(countTime>120){
			Num_A.SetActive(true);
		}

		if(countTime>280){
			Num_A.SetActive(false);
			Num_B.SetActive(true);
		}

		if(countTime>440){
			Num_B.SetActive(false);
			Num_C.SetActive(true);
		}

		if(countTime>600){
			Num_C.SetActive(false);
			Num_D.SetActive(true);
		}

		if(countTime>760){
			Num_D.SetActive(false);
			Num_E.SetActive(true);
		}

		if(countTime>=920){
			nameObj.SetActive(false);
			message.SetActive(false);
			Num_E.SetActive(false);
			Num_Start.SetActive(true);
		}
	}
}
