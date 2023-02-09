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

	void Move(){
		transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velo, 0.35f);
	}
	
	// IEnumerator titleMove(){
	// 	while(true){
	// 		Move();
	// 		yield return new WaitForSecondsRealtime(0.1f);

	// 		//target.transform.position.y+= 100;

	// 		//Move(target2);
	// 	}

	// }

	// void Start(){
	// 	StartCoroutine(titleMove());
	// }

	void Update(){
		Move();

		// if (this.gameObject.transform.position == target.transform.position){
		// 	Debug.Log("Done");
		// }
	}
	
}
