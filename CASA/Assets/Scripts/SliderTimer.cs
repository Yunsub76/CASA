using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderTimer : MonoBehaviour 
{
	public Slider timerSlider;
	public Text timertext;
	public float gameTime;

	public bool stopTimer;
	Image fillArea;
	Color newcolor;
	

	void Awake() {
		gameTime = 91;
		stopTimer = false;
		timerSlider.maxValue = gameTime;
		timerSlider.value = gameTime;
		fillArea = timerSlider.fillRect.GetComponent<Image>();
	}

	// Update is called once per frame
	void Update() {
		if(gameTime > 0)
		{ 
			gameTime = gameTime - Time.deltaTime;
			int minutes = Mathf.FloorToInt(gameTime / 60);
			int seconds = Mathf.FloorToInt(gameTime - minutes * 60f);

			string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

			if (gameTime <= 10)
			{
				fillArea.color = new Color(1, 0, 0, 0.15f);

			}
			if (gameTime <= 0)
			{
				stopTimer = true;
			}
			if (stopTimer == false)
			{
				timertext.text = textTime;
				timerSlider.value = gameTime;
			}
		}
	}
}
