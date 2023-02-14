using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateUI : MonoBehaviour {

	public bool activateUI = false;
    GameObject image;
    GameObject slider;
    GameObject scoreText;

	void Awake()
    {
        image = GameObject.Find("Image");
        slider = GameObject.Find("Slider");
        scoreText = GameObject.Find("ScoreText");

    }

    void Update()
    {
        if (activateUI == true)
            UIActivate();
        else
            UIDisabled();
    }

	public void UIDisabled()
    {
        image.SetActive(false);
        slider.SetActive(false);
        scoreText.SetActive(false);
    }

    public void UIActivate()
    {
        image.SetActive(true);
        slider.SetActive(true);
        scoreText.SetActive(true);
    }

}
