using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateUI : MonoBehaviour {

	public bool activateUI = false;
    Vector3 velo = Vector3.zero;
    Vector3 velo2 = Vector3.zero;
    GameObject image;
    GameObject slider;
    GameObject scoreText;
    GameObject totalScore;
    GameObject finalScore;
    GameObject totalScoretarget;
    GameObject finalScoretarget;
    GameObject sliderTime;

    void Awake()
    {
        image = GameObject.Find("Image");
        slider = GameObject.Find("Slider");
        scoreText = GameObject.Find("ScoreText");
        totalScore = GameObject.Find("TotalScore");
        finalScore = GameObject.Find("FinalScore");
        totalScoretarget = GameObject.Find("TotalScoreTarget");
        finalScoretarget = GameObject.Find("FinalScoreTarget");
        sliderTime = GameObject.Find("GameManager");
        
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
        sliderTime.GetComponent<SliderTimer>().gameTime2 = 0;
    }

    void TotalScoreMove()
    {
        totalScore.transform.position = Vector3.SmoothDamp(totalScore.transform.position, totalScoretarget.transform.position, ref velo, 0.35f);
    }
    void FinalScoreMove()
    {
        finalScore.transform.position = Vector3.SmoothDamp(finalScore.transform.position, finalScoretarget.transform.position, ref velo2, 0.35f);
    }
    public void GetFinalScore()
    {
        Invoke("TotalScoreMove", 1);
        Invoke("FinalScoreMove", 2);  
    }
}
