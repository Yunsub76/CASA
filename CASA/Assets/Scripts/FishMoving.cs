using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMoving : MonoBehaviour {
	public Transform target;
	public float speed =0.1f;

	private Vector3 startPos;


	// Use this for initialization
	void Start () {
		startPos = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed);

		if(this.gameObject.transform.position == target.position){
			//this.gameObject.transform.localEulerAngles.y -= 180;   // rotation y 값 -180
			this.gameObject.transform.position = startPos;   // 타겟위치를 스타트로 바꾸기
		}
	}
}
