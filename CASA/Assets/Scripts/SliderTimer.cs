using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderTimer : MonoBehaviour 
{
	public Slider timerSlider;
	public float gameTime;
	public float gameTime2;
	public bool stopTimer;
	Image fillArea;
	Color newcolor;
	GameObject gameManager;
	

	void Awake() {
		stopTimer = false;
		timerSlider.maxValue = gameTime;
		timerSlider.value = gameTime2;
		fillArea = timerSlider.fillRect.GetComponent<Image>();
		gameManager = GameObject.Find("GameManager");
	}

	// Update is called once per frame
	void Update() {
		if(gameTime2 < 91)
		{ 
			gameTime2 = gameTime2 + Time.deltaTime;

			if (gameTime2 >= gameTime)
			{
				stopTimer = true;
				EndGame();
				
			}
			if (stopTimer == false)
			{
				timerSlider.value = gameTime2;
			}
		}
	}
	void EndGame()
    {
		Invoke("DisableUI", 1);
    }
	void DisableUI()
    {
		gameManager.GetComponent<ActivateUI>().UIDisabled();
		Invoke("PlayTransition", 1);
		
	}

	void PlayTransition()
    {
		gameManager.GetComponent<ActivateUI>().PlayTransition();
	}
}
