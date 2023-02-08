using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPositionDiscriminator : MonoBehaviour
{
    private int wasteTypeIndex;

    private AreaToCoordinate areaToCoordinate;
    private List<float[]> wasteCoordinateList;
    
    private int type = 0;
    private int Point = 0;
    private bool justOnce = false;

    void Awake()
    {
        areaToCoordinate = GameObject.Find("GameManager").GetComponent<AreaToCoordinate>();
        wasteCoordinateList = areaToCoordinate.wasteCoordinateList;
    }

    void Start()
    {
        if(this.gameObject.tag == "Plastic")
        {
            wasteTypeIndex = 0;
        }
        else if(this.gameObject.tag == "Paper")
        {
            wasteTypeIndex = 1;
        }
        else if(this.gameObject.tag == "Can")
        {
            wasteTypeIndex = 2;
        }
        else if(this.gameObject.tag == "General")
        {
            wasteTypeIndex = 3;
        }
    }

    void Update()
    {
        IsInCorrectPlace();   
    }

    private void IsInCorrectPlace()
    {
        if(justOnce == false)
        { 
            if(this.gameObject.transform.position.x > wasteCoordinateList[wasteTypeIndex][0] &&
                this.gameObject.transform.position.x < wasteCoordinateList[wasteTypeIndex][1] &&
                this.gameObject.transform.position.z > wasteCoordinateList[wasteTypeIndex][2] &&
                this.gameObject.transform.position.z < wasteCoordinateList[wasteTypeIndex][3] &&
                this.gameObject.transform.position.y < wasteCoordinateList[wasteTypeIndex][4])
            {   
                Point += 100;
                justOnce = true;
                Debug.Log("잘들어갔어요!");
            }
        }
    }
}
