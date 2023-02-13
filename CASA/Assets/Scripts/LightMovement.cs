using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour {
	public float lightS;
	public float lightH;
	bool loc = true;
	bool locH = true;
	private bool positive;
	Light lightColor;
	bool colorChange = false; //색 변환이 일어났는지 true/false
	public Color positiveTargetColor;
	public Color negativeTargetColor;
	public float colorSpeed;
	int score;
	GameObject gameManager;
	float positiveChangeSpeed = 0;

	void Awake()
    {
		gameManager = GameObject.Find("GameManager");
		score = gameManager.GetComponent<ScoreManager>().score;
	}
	void Start () {
		
		lightColor = GetComponent<Light>();
		positiveChangeSpeed = 0.05f; //포인트를 얻을때마다 조명 색이 변하는 속도

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x >= 250 ) {loc = false;}
		else if(transform.position.x <= -250) {loc = true;}
		
		if (transform.position.y >= 100) {locH = false;}
		else if (transform.position.y <=30) {locH = true;}

		// Light Color Changing 빛의 색을 바꾸는 조건문입니다.
		if (gameManager.GetComponent<GenerateFallingTrash>().positive == true)
		{
			if (gameManager.GetComponent<ScoreManager>().changeLightNum > 0)
			{
				if (colorChange == false) 
					PositiveColor();
			}
			else if (gameManager.GetComponent<ScoreManager>().changeLightNum == 0)
				colorChange = false;
		}
		else if (gameManager.GetComponent<GenerateFallingTrash>().positive == false) 
			NegativeColor();

		// Light Movement function 
		Transform();
	}

	void Transform()
    {
		if (loc == true)transform.position = new Vector3(transform.position.x + lightS, transform.position.y, transform.position.z);
		else if (loc == false)transform.position = new Vector3(transform.position.x - lightS, transform.position.y, transform.position.z);

		if (locH == true)transform.position = new Vector3(transform.position.x, transform.position.y + lightH, transform.position.z);
		else if (locH == false)transform.position = new Vector3(transform.position.x, transform.position.y - lightH, transform.position.z);
		
	}
	void PositiveColor()
	{
		if (lightColor.color.r <= positiveTargetColor.r) 
			lightColor.color = new Color(lightColor.color.r + positiveChangeSpeed, lightColor.color.g, lightColor.color.b);
		else 
			lightColor.color = new Color(lightColor.color.r - positiveChangeSpeed, lightColor.color.g, lightColor.color.b);
		if (lightColor.color.g <= positiveTargetColor.g) 
			lightColor.color = new Color(lightColor.color.r, lightColor.color.g + positiveChangeSpeed, lightColor.color.b);
		else 
			lightColor.color = new Color(lightColor.color.r, lightColor.color.g - positiveChangeSpeed, lightColor.color.b);
		if (lightColor.color.b <= positiveTargetColor.b) 
			lightColor.color = new Color(lightColor.color.r, lightColor.color.g, lightColor.color.b + positiveChangeSpeed);
		else 
			lightColor.color = new Color(lightColor.color.r, lightColor.color.g, lightColor.color.b - positiveChangeSpeed);

		gameManager.GetComponent<ScoreManager>().changeLightNum -= 1;
		colorChange = true;
		//Debug.Log(name + "변환");



	}
	void NegativeColor()
    {
		if (lightColor.color.r <= negativeTargetColor.r) 
			lightColor.color = new Color(lightColor.color.r + colorSpeed, lightColor.color.g, lightColor.color.b);
		else 
			lightColor.color = new Color(lightColor.color.r - colorSpeed, lightColor.color.g, lightColor.color.b);
		if (lightColor.color.g <= negativeTargetColor.g)
			lightColor.color = new Color(lightColor.color.r, lightColor.color.g + colorSpeed, lightColor.color.b);
		else
			lightColor.color = new Color(lightColor.color.r, lightColor.color.g - colorSpeed, lightColor.color.b);
		if (lightColor.color.b <= negativeTargetColor.b)
			lightColor.color = new Color(lightColor.color.r, lightColor.color.g, lightColor.color.b + colorSpeed);
		else
			lightColor.color = new Color(lightColor.color.r, lightColor.color.g, lightColor.color.b - colorSpeed);
	}
	
}
