using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour {
	GameObject moveWater1;
	GameObject moveWater2;
	GameObject moveWater3;
	bool play;
	float mw1;
	float mw2;
	float mw3;

	// Use this for initialization
	void Start () {
		moveWater1 = GameObject.Find("MoveWater 1");
		moveWater2 = GameObject.Find("MoveWater 2");
		moveWater3 = GameObject.Find("MoveWater 3");
		play = true;
		mw1 = moveWater1.transform.position.x;
		mw2 = moveWater2.transform.position.x;
		mw3 = moveWater3.transform.position.x;


	}
	
	// Update is called once per frame
	void Update () {
        while (play)
        {
			moveWater1.transform.position = new Vector3(1, 0, 0);
			moveWater2.transform.position = new Vector3(1, 0, 0);
			moveWater3.transform.position = new Vector3(1, 0, 0);
            if (mw1 == 750)
            {
				moveWater1.transform.position = new Vector3(-1000, 0, 0);
            }
			else if (mw2 == 750)
			{
				moveWater2.transform.position = new Vector3(-1000, 0, 0);
			}
			else if (mw3 == 750)
			{
				moveWater3.transform.position = new Vector3(-1000, 0, 0);
			}


		}
	}
}
