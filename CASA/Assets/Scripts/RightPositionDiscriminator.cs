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

    private SoundManager soundManagerScript;
    GenerateFallingTrash generateFallingTrash;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        goodPrefab = gameManager.GetComponent<GoodObjectList>().goodObjectList;
        areaToCoordinate = gameManager.GetComponent<AreaToCoordinate>();
        score = gameManager.GetComponent<ScoreManager>().score;
        generateFallingTrash = gameManager.GetComponent<GenerateFallingTrash>();

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
        else
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
        if(generateFallingTrash.positive == false)
        {
            wasteTypeIndex = 0;
        }

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
                if (generateFallingTrash.positive == false) //부정 모드일 때 쓰레기를 넣을 때마다 떨어지게 함
                {
                    if (generateFallingTrash.isTeam == true) //협동 모드일 때 쓰레기 넣을 때 하나씩 들어가게 함
                    {
                        generateFallingTrash.SetRandomPosition();
                    }
                    else  //개인 모드일 때 같은 결말을 위해 하나 버릴 때 3개씩 떨어지게 함
                    {
                        generateFallingTrash.SetRandomPosition();
                        generateFallingTrash.SetRandomPosition();
                        generateFallingTrash.SetRandomPosition();
                    }
                }
                soundManagerScript.SFXSound(soundManagerScript.sFXList[4]);
            }
        }
    }

    private void changingTrash()
    {
        GameObject fallingTrash = GameObject.FindWithTag("fallingTrash");
        soundManagerScript.SFXSound(soundManagerScript.sFXList[4]);
        if (fallingTrash != null && generateFallingTrash.positive == true)
        {
            Vector3 fallingTrashPosition = fallingTrash.transform.position;
            Destroy(fallingTrash);

            int i = Random.Range(0, 14);
            Instantiate(goodPrefab[i], new Vector3(fallingTrashPosition.x, fallingTrashPosition.y, fallingTrashPosition.z), goodPrefab[i].transform.rotation);
            if (generateFallingTrash.isTeam == false) //개인 모드일 때 1쓰레기 당 eco 3개
            {
                int Ra = Random.Range(30, 45);
                int Rb = Random.Range(25, 50);
                int Rc = Random.Range(-15, 0);
                
                Instantiate(goodPrefab[i], new Vector3(fallingTrashPosition.x + Ra + Rc, fallingTrashPosition.y, fallingTrashPosition.z + Rb), goodPrefab[i].transform.rotation);
                Instantiate(goodPrefab[i], new Vector3(fallingTrashPosition.x + Rb + Rc, fallingTrashPosition.y, fallingTrashPosition.z + Ra), goodPrefab[i].transform.rotation);
            }
        }    
    }
};