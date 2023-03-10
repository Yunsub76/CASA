using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateUI : MonoBehaviour {

	//public bool activateUI = false;
    Vector3 velo = Vector3.zero;
    Vector3 velo2 = Vector3.zero;
    [SerializeField] GameObject image;
    [SerializeField] GameObject slider;
    [SerializeField] GameObject scoreText;

    [SerializeField] GameObject totalScore;
    [SerializeField] GameObject finalScore;
    [SerializeField] GameObject frame;
    [SerializeField] GameObject pressEnter;

    [SerializeField] int resetTime;


    bool endScoreText = false;

    void Update()
    {
        if (endScoreText == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                EndScoreDisabled();
            }
        }
    }

    public void UIDisabled()
    {

        image.SetActive(false);
        slider.SetActive(false);
        scoreText.SetActive(false);
        if (GetComponent<SliderTimer>().stopTimer == true)
        {
            Invoke("FrameActivate",5);
        }
    }    

    public void UIActivate()
    {
        image.SetActive(true);
        slider.SetActive(true);
        scoreText.SetActive(true);
        GetComponent<SliderTimer>().gameTime2 = resetTime;
    }


    public void GetFinalScore()
    {
        Debug.Log("GetFinalScore()");
;       Invoke("TotalScoreMove", 1);
        Invoke("FinalScoreMove", 2);  
    }

    void FrameActivate()
    {
        frame.SetActive(true);
        Invoke("TotalActivate", 0.5f);
;
    }
    void TotalActivate()
    {
        totalScore.SetActive(true);
        Invoke("ScoreActivate", 1.8f);
    }
    void ScoreActivate()
    {
        finalScore.GetComponent<Text>().text = string.Format("{0:0}", GetComponent<ScoreManager>().score);
        finalScore.SetActive(true);
        endScoreText = true;
        Invoke("PressEnterActive", 1);
    }
    void PressEnterActive()
    {
        pressEnter.SetActive(true);
    }

    void EndScoreDisabled()
    {
        frame.SetActive(false);
        totalScore.SetActive(false);
        finalScore.SetActive(false);
        pressEnter.SetActive(false);
    }
}
