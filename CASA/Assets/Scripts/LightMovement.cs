using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour {
	public float lightS;
	public float lightH;
	bool loc = true;
	bool locH = true;
	public bool mood = true;
	public bool moodchange = true;
	Light lightColor;
	Color color;
	float PMoodCr;
	float PMoodCg;
	float PMoodCb;
	float NMoodCr;
	float NMoodCg;
	float NMoodCb;


	void Start () {
		lightColor = GetComponent<Light>();
		lightColor.color = new Color(0.1960784f, 0.7843137f, 0.7843137f, 1f);
		PMoodCr = 0.3921569f;
		PMoodCg = 0.5882353f;
		PMoodCb = 1f;
		NMoodCr = 0f;
		NMoodCg = 0.5882353f;
		NMoodCb = 0f;

	}
	
	// Update is called once per frame
	void Update () {
		//Limit the moving range of light
		if (transform.position.x >= 250 ) 
		{
			loc = false;
		}
		else if(transform.position.x <= -250)
		{
			loc = true;
		}
		
		if (transform.position.y >= 100)
		{
			locH = false;
		}
		else if (transform.position.y <=30)
		{
			locH = true;
		}
		if (moodchange == true) Color();
		//Light Movement function 
		Transform();
	}

	void Transform()
    {
		if (loc == true)
		{
			transform.position = new Vector3(transform.position.x + lightS, transform.position.y, transform.position.z);
		}
		else if (loc == false)
		{
			transform.position = new Vector3(transform.position.x - lightS, transform.position.y, transform.position.z);
		}
		if (locH == true)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + lightH, transform.position.z);
		}
		else if (locH == false)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y - lightH, transform.position.z);
		}
	}
	void Color()
    {
		if (mood == true)
		{
			if (lightColor.color.r < PMoodCr) lightColor.color = new Color(lightColor.color.r + 0.001f, lightColor.color.g, lightColor.color.b);
			else if (lightColor.color.g > PMoodCg) lightColor.color = new Color(lightColor.color.r, lightColor.color.g - 0.001f, lightColor.color.b);
			else if (lightColor.color.b > PMoodCb) lightColor.color = new Color(lightColor.color.r, lightColor.color.g, lightColor.color.b + 0.001f);
		}
		else if (mood == false)
		{
			if (lightColor.color.r > NMoodCr) lightColor.color = new Color(lightColor.color.r - 0.001f, lightColor.color.g, lightColor.color.b);
			else if (lightColor.color.g > NMoodCg) lightColor.color = new Color(lightColor.color.r, lightColor.color.g - 0.001f, lightColor.color.b);
			else if (lightColor.color.b > NMoodCb) lightColor.color = new Color(lightColor.color.r, lightColor.color.g, lightColor.color.b - 0.001f);
		}
	}
}
