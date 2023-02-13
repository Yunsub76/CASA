using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
	public static LightManager instance;
	public List<Light> lights;
	public List<Color> positiveTargetColor;
	public float positiveChangeSpeed = 0;
	public List<Color> negativeTargetColor;
	public float negativeChangeSpeed = 0;

	GameObject gameManager;
	int score;

	void Awake()
    {
		gameManager = GameObject.Find("GameManager");
		score = gameManager.GetComponent<ScoreManager>().score;
	}

	void Update()
	{
		if (gameManager.GetComponent<GenerateFallingTrash>().positive == true)
		{
			if (gameManager.GetComponent<ScoreManager>().changeLightNum == true)
			{
				for (int lightnum = 0; lightnum < 5; ++lightnum)
				{
					PositiveColor(lights[lightnum], positiveTargetColor[lightnum]);
				}
				gameManager.GetComponent<ScoreManager>().changeLightNum = false;
			}
		}
		else if (gameManager.GetComponent<GenerateFallingTrash>().positive == false)
		{
			for (int lightnum = 0; lightnum < 5; ++lightnum)
			{
				PositiveColor(lights[lightnum], negativeTargetColor[lightnum]);
			}
		}

	}
	void PositiveColor(Light lightColor, Color positiveTargetColor)
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
	void NegativeColor(Light lightColor, Color negativeTargetColor)
	{
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