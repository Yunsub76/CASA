using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderTimer : MonoBehaviour 
{
	public Slider timerSlider;
	public float gameTime;
	float gameTime2;
	public bool stopTimer;
	Image fillArea;
	Color newcolor;
	

	void Awake() {
		stopTimer = false;
		timerSlider.maxValue = gameTime;
		timerSlider.value = gameTime2;
		fillArea = timerSlider.fillRect.GetComponent<Image>();
	}

	// Update is called once per frame
	void Update() {
		if(gameTime2 < 91)
		{ 
			gameTime2 = gameTime2 + Time.deltaTime;
			Debug.Log(gameTime2);
			int minutes = Mathf.FloorToInt(gameTime / 60);
			int seconds = Mathf.FloorToInt(gameTime - minutes * 60f);

			if (gameTime2 >= gameTime)
			{
				stopTimer = true;
			}
			if (stopTimer == false)
			{
				timerSlider.value = gameTime2;
			}
		}
	}
}
