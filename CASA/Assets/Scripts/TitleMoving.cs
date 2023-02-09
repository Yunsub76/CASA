using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleMoving : MonoBehaviour {

	// 주석처리 한 코드들은 특정 시간에 active 설정해주는 것
	// float timer = 0.0f;
	// public float activeTime;
	// public GameObject title;

	Vector3 velo = Vector3.zero;
	public Transform target;
	//Vector3 target = new Vector3(0,100,0);

	void Start () {
		
	}
	
	void Update () {
		// timer += Time.deltaTime;
		
		// if(timer > activeTime){
		// 	title.gameObject.SetActive(true);
		// }

		Move();

	
	}

	void Move(){
		transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velo, 0.35f);
	}
}
