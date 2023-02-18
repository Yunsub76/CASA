using System.IO.Compression;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPositionDiscriminator : MonoBehaviour
{
    private GameObject gameManager;

    private int wasteTypeIndex;
    private GameObject ScorePreFab;

    private AreaToCoordinate areaToCoordinate;
    private List<float[]> wasteCoordinateList;
    
    private int type = 0;
    private int score;
    private bool justOnce = false;

    private SoundManager soundManagerScript;
    GenerateFallingTrash generateFallingTrash;

    Vector3 prevPosition = Vector3.zero;
    Vector3 fallingTrashPosition = new Vector3(0,0,0);

    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        ScorePreFab = gameManager.GetComponent<GoodObjectList>().ScorePreFab;
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
                soundManagerScript.SFXSound(soundManagerScript.sFXList[4]);

                if (prevPosition == null)
                {
                    prevPosition = this.transform.position;
                    return;
                }

                float dist = Vector3.Distance(prevPosition, this.transform.position);

                if (dist != 0)
                {
                    gameManager.GetComponent<ScoreManager>().changeLightNum = true; 
                    justOnce = true;
                    
                    if (generateFallingTrash.positive == false) //부정 모드일 때 
                    {
                        if (generateFallingTrash.isTeam == true) //협동 모드일 때 
                        {
                            generateFallingTrash.SetRandomPosition();
                            gameManager.GetComponent<ScoreManager>().score += 100;
                        }
                        else  //개인 모드
                        {
                            generateFallingTrash.SetRandomPosition();
                            gameManager.GetComponent<ScoreManager>().score += 300;
                        }
                    }
                    else  //긍정 모드일 때 
                    {
                        changingTrash();
                        if (generateFallingTrash.isTeam == true) //협동 모드
                        {
                            gameManager.GetComponent<ScoreManager>().score += 100;
                        }
                        else  //개인 모드 
                        {
                            gameManager.GetComponent<ScoreManager>().score += 300;
                        }
                    }
                    soundManagerScript.SFXSound(soundManagerScript.sFXList[4]);
                }
            }
        }
    }

    private void changingTrash()
    {
        if (this.gameObject.tag == "Plastic")
        {
            if (generateFallingTrash.spawnedPlasticList[0] == null)
                return;
            // 생성된 오브젝트 리스트에 추가
            fallingTrashPosition = generateFallingTrash.spawnedPlasticList[0].transform.position;
            Destroy(generateFallingTrash.spawnedPlasticList[0]);
            generateFallingTrash.spawnedPlasticList.RemoveAt(0);
        }
        else if (this.gameObject.tag == "Paper")
        {
            if (generateFallingTrash.spawnedPaperList[0] == null)
                return;
            fallingTrashPosition = generateFallingTrash.spawnedPaperList[0].transform.position;
            Destroy(generateFallingTrash.spawnedPaperList[0]);
            generateFallingTrash.spawnedPaperList.RemoveAt(0);
        }
        else if (this.gameObject.tag == "Can")
        {
            if (generateFallingTrash.spawnedCanList[0] == null)
                return;
            fallingTrashPosition = generateFallingTrash.spawnedCanList[0].transform.position;
            Destroy(generateFallingTrash.spawnedCanList[0]);
            generateFallingTrash.spawnedCanList.RemoveAt(0);
        }
        StartCoroutine(ProjectScore());
    }

    IEnumerator ProjectScore()
    {
        //GameObject ScoreObject = Instantiate(ScorePreFab, new Vector3(fallingTrashPosition.x, fallingTrashPosition.y, fallingTrashPosition.z), ScorePreFab.transform.rotation);
        yield return new WaitForSecondsRealtime(6);
       // Destroy(ScoreObject);
    }
};