using System.IO.Compression;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPositionDiscriminator : MonoBehaviour
{
    private GameObject gameManager;

    private int wasteTypeIndex;
    private List<GameObject> goodPrefab;

    private AreaToCoordinate areaToCoordinate;
    private List<float[]> wasteCoordinateList;
    
    private int type = 0;
    private int score;
    private bool justOnce = false;
    private bool IsSingle;

    private SoundManager soundManagerScript;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        goodPrefab = gameManager.GetComponent<GoodObjectList>().goodObjectList;
        areaToCoordinate = gameManager.GetComponent<AreaToCoordinate>();
        score = gameManager.GetComponent<ScoreManager>().score;
        IsSingle = gameManager.GetComponent<GenerateFallingTrash>().isSingle;

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
                gameManager.GetComponent<ScoreManager>().score += 100;
                gameManager.GetComponent<ScoreManager>().changeLightNum = true;
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
            if(IsSingle == true)
            {
                int Ra = Random.Range(20, 35);
                int Rb = Random.Range(15, 40);
                int Rc = Random.Range(-10, 0);
     
                Instantiate(goodPrefab[i], new Vector3(fallingTrashPosition.x + Ra + Rc, fallingTrashPosition.y, fallingTrashPosition.z + Rb), goodPrefab[i].transform.rotation);
                Instantiate(goodPrefab[i], new Vector3(fallingTrashPosition.x + Rb + Rc, fallingTrashPosition.y, fallingTrashPosition.z + Ra), goodPrefab[i].transform.rotation);
            }
        }    
    }
};