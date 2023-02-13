using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
	public static LightManager instance;
	public List<Light> lights;
	public List<Color> positiveTargetColor;
	public float positiveChangeSpeed = 0;
	//List<List<float>> positiveChangeSpeed2 = new List<List<float>>();
	public List<Color> negativeTargetColor;
	public float negativeChangeSpeed = 0;
	//List<List<float>> negativeChangeSpeed2 = new List<List<float>>();

	GameObject gameManager;
	int score;

	void Awake()
    {
		gameManager = GameObject.Find("GameManager");
		score = gameManager.GetComponent<ScoreManager>().score;
	}
	void Start()
	{
		/*
		for (int lightnum = 0; lightnum < 5; ++lightnum)
		{
			positiveChangeSpeed2.Add(new List<float>());
			positiveChangeSpeed2[lightnum].Add((lights[lightnum].color.r - positiveTargetColor[lightnum].r)/90);
			positiveChangeSpeed2[lightnum].Add((lights[lightnum].color.g - positiveTargetColor[lightnum].g)/90);
			positiveChangeSpeed2[lightnum].Add((lights[lightnum].color.b - positiveTargetColor[lightnum].b)/90);
		}
		for (int lightnum = 0; lightnum < 5; ++lightnum)
		{
			negativeChangeSpeed2.Add(new List<float>());
			negativeChangeSpeed2[lightnum].Add((lights[lightnum].color.r - negativeTargetColor[lightnum].r)/90);
			negativeChangeSpeed2[lightnum].Add((lights[lightnum].color.g - negativeTargetColor[lightnum].g)/90);
			negativeChangeSpeed2[lightnum].Add((lights[lightnum].color.b - negativeTargetColor[lightnum].b)/90);
		}
		*/

	}
	void Update()
	{
		if (gameManager.GetComponent<GenerateFallingTrash>().positive == true)
		{
			if (gameManager.GetComponent<ScoreManager>().changeLightNum == true)
			{
				for (int lightnum = 0; lightnum < 5; ++lightnum)
				{
					PositiveColor(lights[lightnum], positiveTargetColor[lightnum], lightnum);
				}
				gameManager.GetComponent<ScoreManager>().changeLightNum = false;
			}
		}
		else if (gameManager.GetComponent<GenerateFallingTrash>().positive == false)
		{
			for (int lightnum = 0; lightnum < 5; ++lightnum)
			{
				NegativeColor(lights[lightnum], negativeTargetColor[lightnum], lightnum);
			}
		}

	}
	void PositiveColor(Light lightColor, Color positiveTargetColor, int lighrnum)
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

		



	}
	void NegativeColor(Light lightColor, Color negativeTargetColor, int lightnum)
	{
	/*	lightColor.color = new Color(lightColor.color.r + negativeChangeSpeed2[lightnum][0], lightColor.color.g, lightColor.color.b);
		lightColor.color = new Color(lightColor.color.r, lightColor.color.g + negativeChangeSpeed2[lightnum][1], lightColor.color.b);
		lightColor.color = new Color(lightColor.color.r, lightColor.color.g, lightColor.color.b + negativeChangeSpeed2[lightnum][2]);
	*/
		if (lightColor.color.r <= negativeTargetColor.r)
			lightColor.color = new Color(lightColor.color.r + negativeChangeSpeed, lightColor.color.g, lightColor.color.b);
		else
			lightColor.color = new Color(lightColor.color.r - negativeChangeSpeed, lightColor.color.g, lightColor.color.b);
		if (lightColor.color.g <= negativeTargetColor.g)
			lightColor.color = new Color(lightColor.color.r, lightColor.color.g + negativeChangeSpeed, lightColor.color.b);
		else
			lightColor.color = new Color(lightColor.color.r, lightColor.color.g - negativeChangeSpeed, lightColor.color.b);
		if (lightColor.color.b <= negativeTargetColor.b)
			lightColor.color = new Color(lightColor.color.r, lightColor.color.g, lightColor.color.b + negativeChangeSpeed);
		else
			lightColor.color = new Color(lightColor.color.r, lightColor.color.g, lightColor.color.b - negativeChangeSpeed);
	
	}
}