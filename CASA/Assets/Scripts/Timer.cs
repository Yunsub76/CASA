using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	GameObject gameManager;
	public float countTime = 0;
	public float gameTimeCount;
	public GameObject Num_A;   // 5초
	public GameObject Num_B;
	public GameObject Num_C;
	public GameObject Num_D;
	public GameObject Num_E;
	public GameObject Num_Start;
	bool countdown = true;
	//public GameObject nameObj;
	//public GameObject message;

	// Use this for initialization
	void Awake() 
	{
		gameManager = GameObject.Find("GameManager");
		countTime = 0;		
	}

	// Update is called once per frame
	void Update()
	{
		if (countdown == true) {
			if (countTime < 5)
			{
				countTime = countTime + Time.deltaTime;
			}

			if (countTime > 0)
			{
				Num_A.SetActive(true);
			}

			if (countTime > 1)
			{
				Num_A.SetActive(false);
				Num_B.SetActive(true);
			}

			if (countTime > 2)
			{
				Num_B.SetActive(false);
				Num_C.SetActive(true);
			}

			if (countTime > 3)
			{
				Num_C.SetActive(false);
				Num_D.SetActive(true);
			}

			if (countTime > 4)
			{
				Num_D.SetActive(false);
				Num_E.SetActive(true);
			}

			if (countTime >= 5)
			{
				//nameObj.SetActive(false);
				//message.SetActive(false);
				Num_E.SetActive(false);
				Num_Start.SetActive(true);
				DisableStart();
				countdown = false;
			}
		}
	}
	void DisableStart()
    {
		Invoke("GameStart",1.5f);
    }

	void GameStart()
    {
		Num_Start.SetActive(false);
		gameManager.GetComponent<ActivateUI>().UIActivate();

    }
}
