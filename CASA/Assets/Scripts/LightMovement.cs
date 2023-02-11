using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour {
	public float lightS;
	public float lightH;
	bool loc = true;
	bool locH = true;
	public bool positive = true;
	Light lightColor;
	Color color;
	public Color positiveTargetColor;
	public Color negativeTargetColor;
	public float colorSpeed;
	bool gm; 


	void Start () {
		gm = GameObject.Find("GameManager").GetComponent<SliderTimer>().stopTimer;
		lightColor = GetComponent<Light>();
		lightColor.color = new Color(0.1960784f, 0.7843137f, 0.7843137f, 1f); // Basic Color
		
	}
	
	// Update is called once per frame
	void Update () {
		//Limit the moving range of light
		if (transform.position.x >= 250 ) {loc = false;}
		else if(transform.position.x <= -250) {loc = true;}
		
		if (transform.position.y >= 100) {locH = false;}
		else if (transform.position.y <=30) {locH = true;}

		// Light Color Changing 빛의 색을 바꾸는 조건문입니다.
		if (gm == false) Color();

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
	void Color()
    {

		if (positive == true) // positiveTargetColor색으로 변경
		{
			if (lightColor.color.r <= positiveTargetColor.r) lightColor.color = new Color(lightColor.color.r + colorSpeed, lightColor.color.g, lightColor.color.b);
			else lightColor.color = new Color(lightColor.color.r - colorSpeed, lightColor.color.g, lightColor.color.b);
			if (lightColor.color.g <= positiveTargetColor.g) lightColor.color = new Color(lightColor.color.r, lightColor.color.g + colorSpeed, lightColor.color.b);
			else lightColor.color = new Color(lightColor.color.r, lightColor.color.g - colorSpeed, lightColor.color.b);
			if (lightColor.color.b <= positiveTargetColor.b) lightColor.color = new Color(lightColor.color.r, lightColor.color.g, lightColor.color.b + colorSpeed);
			else lightColor.color = new Color(lightColor.color.r, lightColor.color.g, lightColor.color.b - colorSpeed);
		}
		else if (positive == false)  // negativeTargetColor색으로 변경
		{
			if (lightColor.color.r <= negativeTargetColor.r) lightColor.color = new Color(lightColor.color.r + colorSpeed, lightColor.color.g, lightColor.color.b);
			else lightColor.color = new Color(lightColor.color.r - colorSpeed, lightColor.color.g, lightColor.color.b);
			if (lightColor.color.g <= negativeTargetColor.g) lightColor.color = new Color(lightColor.color.r, lightColor.color.g + colorSpeed, lightColor.color.b);
			else lightColor.color = new Color(lightColor.color.r, lightColor.color.g - colorSpeed, lightColor.color.b);
			if (lightColor.color.b <= negativeTargetColor.b) lightColor.color = new Color(lightColor.color.r, lightColor.color.g, lightColor.color.b + colorSpeed);
			else lightColor.color = new Color(lightColor.color.r, lightColor.color.g, lightColor.color.b - colorSpeed);
		}
	}
}
