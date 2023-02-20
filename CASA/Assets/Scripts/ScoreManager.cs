using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int score = 0;
    public bool changeLightNum = false;
    [SerializeField] Text ScoreTextUI;

    GenerateFallingTrash generateFallingTrash;
    int teamBalance = 1;

    [SerializeField] private GameObject[] MissionUIArray = new GameObject[3];
    private bool[] MissionBoolArray = new bool[3] { false, false, false };

    [SerializeField] private GameObject[] HandObjectArray = new GameObject[3];

    [SerializeField] private GameObject[] PositiveEndingObjectArray = new GameObject[3];
    [SerializeField] private GameObject[] NagativeEndingObjectArray = new GameObject[3];

    [SerializeField] private GameObject LoadCircularUI;
    [SerializeField] private GameObject LoadReverseCircularUI;

    [SerializeField] private GameObject[] GaugeArray = new GameObject[3];

    SliderTimer sliderTimer;
    ActivateUI activateUI;

    public int NumVertical;
    public int NumHorizontal;
    public int NumCircle;
    public int NumRCircle;

    void Awake()
    {
        generateFallingTrash = this.GetComponent<GenerateFallingTrash>();
        sliderTimer = this.GetComponent<SliderTimer>();
        activateUI = this.GetComponent<ActivateUI>();
        GaugeArray[0].GetComponent<Slider>().maxValue = 40 * teamBalance;
        GaugeArray[1].GetComponent<Slider>().maxValue = 40 * teamBalance;
        GaugeArray[2].GetComponent<Slider>().maxValue = 30 * teamBalance;
    }

    void Update()
   {
        ScoreTextUI.text = string.Format("{0:0}", score);

        if (generateFallingTrash.isTeam == true)
        {
            teamBalance = 3;
        }
        else
        {
            teamBalance = 1;
        }

        if ((score >= 4700 && score < 6000) || sliderTimer.gameTime2 > 5) //최종 시간에 도달하거나 4700점에 도달할 시 마지막 미션 등장
        {
            NumCircle = HandObjectArray[0].GetComponent<HandTracker>().numOfCircles + HandObjectArray[1].GetComponent<HandTracker>().numOfCircles + HandObjectArray[2].GetComponent<HandTracker>().numOfCircles;
            GaugeArray[2].GetComponent<Slider>().value = NumCircle;
            if (generateFallingTrash.IsMissionTime == false)
            {
                ActiveThirdEvent();
            }
            else if (NumCircle >= 15 * teamBalance)
            {
                LoadCircularUI.SetActive(false);
                LoadReverseCircularUI.SetActive(true);

                NumRCircle = HandObjectArray[0].GetComponent<HandTracker>().numOfRCircles + HandObjectArray[1].GetComponent<HandTracker>().numOfRCircles + HandObjectArray[2].GetComponent<HandTracker>().numOfRCircles;
                GaugeArray[2].GetComponent<Slider>().value = 15 * teamBalance + NumRCircle;
                if (NumRCircle >= 15 * teamBalance)
                    FinishThirdEvent();
            }
        }
        else if(score >= 2500 || sliderTimer.gameTime2 > 60) //60초 후나 2500점 도달하면 두번째 미션 등장
        {
            NumVertical = HandObjectArray[0].GetComponent<HandTracker>().zeroCrossings + HandObjectArray[1].GetComponent<HandTracker>().zeroCrossings + HandObjectArray[2].GetComponent<HandTracker>().zeroCrossings;
            GaugeArray[1].GetComponent<Slider>().value = NumVertical-6;
            if (generateFallingTrash.IsMissionTime == false)
            {
                ActiveSecondEvent();
            }
            else if (NumVertical >= 40 * teamBalance)
            {
                FinishSecondEvent();
            }
        }
        else if(score >= 600) //30초 후나 600점 도달하면 두번째 미션 등장
        {
            NumHorizontal = HandObjectArray[0].GetComponent<HandTracker>().zeroCrossings_H + HandObjectArray[1].GetComponent<HandTracker>().zeroCrossings_H + HandObjectArray[2].GetComponent<HandTracker>().zeroCrossings_H;
            GaugeArray[0].GetComponent<Slider>().value = NumHorizontal;
            if (generateFallingTrash.IsMissionTime == false)
            {
                ActiveFirstEvent();
            }
            else if (NumHorizontal >= 40 * teamBalance)
            {
                FinishFirstEvent();
            }
        }
   }

    void ActiveFirstEvent()
    {
        if (MissionBoolArray[0] == true)
            return;
        MissionUIArray[0].SetActive(true);
            HandObjectArray[0].GetComponent<HandTracker>().InitReset();
            HandObjectArray[1].GetComponent<HandTracker>().InitReset();
            HandObjectArray[2].GetComponent<HandTracker>().InitReset();
        MissionBoolArray[0] = true;
        generateFallingTrash.IsMissionTime = true;
    }

    void FinishFirstEvent()
    {
        if (generateFallingTrash.IsMissionTime == false)
            return;
        MissionUIArray[0].SetActive(false);
        score += 1000;
        generateFallingTrash.IsMissionTime = false;
        activateUI.IsGaming = false;
        if (generateFallingTrash.positive == true)
            PositiveEndingObjectArray[0].SetActive(true);
        else
            NagativeEndingObjectArray[0].SetActive(true);
    }

    void ActiveSecondEvent()
    {
        if (MissionBoolArray[1] == true)
            return;
        MissionUIArray[1].SetActive(true);
            HandObjectArray[0].GetComponent<HandTracker>().InitReset();
            HandObjectArray[1].GetComponent<HandTracker>().InitReset();
            HandObjectArray[2].GetComponent<HandTracker>().InitReset();
        MissionBoolArray[1] = true;
        generateFallingTrash.IsMissionTime = true;
    }

    void FinishSecondEvent()
    {
        if (generateFallingTrash.IsMissionTime == false)
            return;
        MissionUIArray[1].SetActive(false);
        score += 1000;
        generateFallingTrash.IsMissionTime = false;
        if (generateFallingTrash.positive == true)
            PositiveEndingObjectArray[1].SetActive(true);
        else
            NagativeEndingObjectArray[1].SetActive(true);
    }

    void ActiveThirdEvent()
    {
        if (MissionBoolArray[2] == true)
            return;
        MissionUIArray[2].SetActive(true);
            HandObjectArray[0].GetComponent<HandTracker>().InitReset();
            HandObjectArray[1].GetComponent<HandTracker>().InitReset();
            HandObjectArray[2].GetComponent<HandTracker>().InitReset();
        MissionBoolArray[2] = true;
        generateFallingTrash.IsMissionTime = true;
    }

    void FinishThirdEvent()
    {
        if (generateFallingTrash.IsMissionTime == false)
            return;
        MissionUIArray[2].SetActive(false);
        score += 1000;
        generateFallingTrash.IsMissionTime = false;
        if (generateFallingTrash.positive == true)
            PositiveEndingObjectArray[2].SetActive(true);
        else
            NagativeEndingObjectArray[2].SetActive(true);
    }
}
