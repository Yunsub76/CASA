using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
	public static LightManager instance;
	public List<Light> lights;
	public List<Color> positiveTargetColor;
	public List<Color> NegativeTargetColor;
	public float lightIntensity;

	// Use this for initialization
	void Start()
	{
		foreach (Light light in lights)
		{
			light.intensity = lightIntensity;
		}

	}

	// Update is called once per frame
	void LightMovementCall()
	{

	}
}