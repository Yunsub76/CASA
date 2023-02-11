﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderTimer : MonoBehaviour {


	public Slider timerSlider;
	public Text timertext;
	public float gameTime;

	public bool stopTimer;

	void Start () {
		stopTimer = false;
		timerSlider.maxValue = gameTime;
		timerSlider.value = gameTime;
	}
	
	// Update is called once per frame
	void Update () {
		float time = gameTime - Time.time;
		int minutes = Mathf.FloorToInt(time / 60);
		int seconds = Mathf.FloorToInt(time - minutes * 60f);

		string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

		if(time <= 0)
        {
			stopTimer = true;
        }
		if(stopTimer == false)
        {
			timertext.text = textTime;
			timerSlider.value = time;
        }
	}
}