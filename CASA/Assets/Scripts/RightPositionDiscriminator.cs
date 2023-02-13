using System.IO.Compression;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPositionDiscriminator : MonoBehaviour
{
    private int wasteTypeIndex;
    private List<GameObject> goodPrefab;

    private AreaToCoordinate areaToCoordinate;
    private List<float[]> wasteCoordinateList;
    
    private int type = 0;
    private int Point = 0;
    private bool justOnce = false;

    private SoundManager soundManagerScript;

    void Awake()
    {
        goodPrefab = GameObject.Find("GameManager").GetComponent<GoodObjectList>().goodObjectList;
        areaToCoordinate = GameObject.Find("GameManager").GetComponent<AreaToCoordinate>();
        wasteCoordinateList = areaToCoordinate.wasteCoordinateList;
        soundManagerScript = GameObject.Find("SoundManager").GetComponent<SoundManager>();
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
                changingTrash();
            }
        }
    }

    private void changingTrash()
    {
        GameObject fallingTrash = GameObject.FindWithTag("fallingTrash");
        if(fallingTrash != null)
        { 
            Vector3 fallingTrashPosition = fallingTrash.transform.position;
            Destroy(fallingTrash);
            soundManagerScript.SFXSound(soundManagerScript.sFXList[4]);

            int i = Random.Range(0, 14);
            Instantiate(goodPrefab[i], new Vector3(fallingTrashPosition.x, fallingTrashPosition.y, fallingTrashPosition.z), goodPrefab[i].transform.rotation);
        }    
    }
};