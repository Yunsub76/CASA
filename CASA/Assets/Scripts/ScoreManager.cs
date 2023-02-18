using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int score = 0;
    public bool changeLightNum = false;
    [SerializeField] Text ScoreTextUI;

    GenerateFallingTrash generateFallingTrash;
    int teamBalance;

    [SerializeField] private GameObject[] MissionUIArray = new GameObject[3];
    [SerializeField] private GameObject[] HandObjectArray = new GameObject[3];
    [SerializeField] private GameObject LoadCircularUI;
    [SerializeField] private GameObject LoadReverseCircularUI;

    public int NumVertical;
    public int NumHorizontal;
    public int NumCircle;
    public int NumRCircle;


    void Awake()
    {
        generateFallingTrash = this.GetComponent<GenerateFallingTrash>();
    }

    void Update()
   {
        ScoreTextUI.text = string.Format("{0:0}", score);

        if(generateFallingTrash.isTeam == true)
        {
            teamBalance = 3;
        }
        else
        {
            teamBalance = 1;
        }

        if (score >= 5000*teamBalance && score < 6000*teamBalance)
        {
            NumCircle = HandObjectArray[0].GetComponent<HandTracker>().numOfCircles + HandObjectArray[1].GetComponent<HandTracker>().numOfCircles + HandObjectArray[2].GetComponent<HandTracker>().numOfCircles;
            ActiveThirdEvent();
            if (NumCircle >= 15 * teamBalance)
            {
                LoadCircularUI.SetActive(false);
                LoadReverseCircularUI.SetActive(true);

                NumRCircle = HandObjectArray[0].GetComponent<HandTracker>().numOfRCircles + HandObjectArray[1].GetComponent<HandTracker>().numOfRCircles + HandObjectArray[2].GetComponent<HandTracker>().numOfRCircles;
                if (NumRCircle >= 15 * teamBalance)
                    FinishThirdEvent();
            }
        }
        else if(score >= 2500 * teamBalance)
        {
            NumVertical = HandObjectArray[0].GetComponent<HandTracker>().zeroCrossings + HandObjectArray[1].GetComponent<HandTracker>().zeroCrossings + HandObjectArray[2].GetComponent<HandTracker>().zeroCrossings;
            ActiveSecondEvent();
            if (NumVertical >= 40 * teamBalance)
            {
                FinishSecondEvent();
            }
        }
        else if(score >= 500 * teamBalance)
        {
            NumHorizontal = HandObjectArray[0].GetComponent<HandTracker>().zeroCrossings_H + HandObjectArray[1].GetComponent<HandTracker>().zeroCrossings_H + HandObjectArray[2].GetComponent<HandTracker>().zeroCrossings_H;
            ActiveFirstEvent();
            if(NumHorizontal >= 40 * teamBalance)
            {
                FinishFirstEvent();
            }
        }
   }

    void ActiveFirstEvent()
    {
        if (MissionUIArray[0].activeSelf == true)
            return;
        MissionUIArray[0].SetActive(true);
        HandObjectArray[0].GetComponent<HandTracker>().InitReset();
        HandObjectArray[1].GetComponent<HandTracker>().InitReset();
        HandObjectArray[2].GetComponent<HandTracker>().InitReset();
    }

    void FinishFirstEvent()
    {
        MissionUIArray[0].SetActive(false);
        score += 1000 * teamBalance;
    }

    void ActiveSecondEvent()
    {
        if (MissionUIArray[1].activeSelf == true)
            return;
        MissionUIArray[1].SetActive(true);
        HandObjectArray[0].GetComponent<HandTracker>().InitReset();
        HandObjectArray[1].GetComponent<HandTracker>().InitReset();
        HandObjectArray[2].GetComponent<HandTracker>().InitReset();
    }

    void FinishSecondEvent()
    {
        MissionUIArray[1].SetActive(false);
        score += 1000 * teamBalance;
    }

    void ActiveThirdEvent()
    {
        if (MissionUIArray[2].activeSelf == true)
            return;
        MissionUIArray[2].SetActive(true);
        HandObjectArray[0].GetComponent<HandTracker>().InitReset();
        HandObjectArray[1].GetComponent<HandTracker>().InitReset();
        HandObjectArray[2].GetComponent<HandTracker>().InitReset();
    }

    void FinishThirdEvent()
    {
        MissionUIArray[2].SetActive(false);
        score += 1000 * teamBalance;
    }
}
