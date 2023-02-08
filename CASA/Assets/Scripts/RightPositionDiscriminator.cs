using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPositionDiscriminator : MonoBehaviour
{
    private int wasteIndex;

    private GameObject areaManager;
    private AreaToCoordinate areaToCoordinate;
    private List<float[]> plasticCoordinateList;  
    private List<float[]> paperCoordinateList;
    private List<float[]> generalCoordinateList;
    private int i = 0;
    private int team1Point = 0;
    private int team2Point = 0;
    private bool justOnce = false;

    void Awake()
    {
        areaManager = GameObject.Find("AreaManager");
        areaToCoordinate = areaManager.GetComponent<AreaToCoordinate>();
        plasticCoordinateList = areaToCoordinate.PlasticCoordinateList;
    }

    void Start()
    {
        if(this.gameObject.tag == "Plastic")
        {
            wasteIndex = 0;
        }
        else if(this.gameObject.tag == "Paper")
        {
            wasteIndex = 1;
        }
        else if(this.gameObject.tag == "General")
        {
            wasteIndex = 2;
        }
    }

    void Update()
    {
        for (int i = 0; i < plasticCoordinateList.Count; i++)
        {
            IsInCorrectPlace(i);
        }
    }

    private void IsInCorrectPlace(int i)
    {
        if(this.gameObject.transform.position.x > plasticCoordinateList[i][0] &&
            this.gameObject.transform.position.x < plasticCoordinateList[i][1] &&
            this.gameObject.transform.position.z > plasticCoordinateList[i][2] &&
            this.gameObject.transform.position.z < plasticCoordinateList[i][3])
        {
            if(this.gameObject.transform.position.y < plasticCoordinateList[i][4])
            {   
                if(justOnce == true)
                {    
                    if(i == 0)
                        team1Point += 100;
                    else if(i == 1)
                        team2Point += 100;
                }
                Debug.Log(team1Point+" VS "+team2Point);
            }
        }
    }
}
