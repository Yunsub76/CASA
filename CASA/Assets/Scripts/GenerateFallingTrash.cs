﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class GenerateFallingTrash : MonoBehaviour
{
    private Vector3 trashPosition;  
    
    private GameObject fallingTrash;

    [SerializeField] GameObject GameArea;

    [SerializeField] GameObject soundManager;
    private SoundManager soundManagerScript;
    private SliderTimer sliderTimer;

    private Collider GameAreaCollider = null;

    private float difficultyTime = 3f;
    public bool isTeam = false; 
    public bool positive = true; 
    bool endBGMPlay = false; 
     
    private LoadManager loadManager; 

    [SerializeField] private GameObject PositiveEnding; 
    [SerializeField] private GameObject NegativeEnding; 
    [SerializeField] private GameObject NPCs; 

    [SerializeField] GameObject transitionNegativeBGScript; 
    private TransitionBackground transitionNegativeBG; 

    public GameObject prefab; // 생성할 프리팹 오브젝트
    public float spawnInterval = 5.0f; // 생성 간격(초)

    //생성된 오브젝트 리스트
    public List<GameObject> spawnedPlasticList = new List<GameObject>(); 
    public List<GameObject> spawnedPaperList = new List<GameObject>(); 
    public List<GameObject> spawnedCanList = new List<GameObject>(); 

    [SerializeField] private GameObject[] fallingTrashArray = new GameObject[3]; // 플라스틱, 종이, 캔 
    private int wasteTypeIndex = 0;
    enum wasteType { Plastic, Paper, Can };


    private float timer = 0.0f; // 생성 타이머

    void Awake()
    {
        soundManagerScript = soundManager.GetComponent<SoundManager>();
        sliderTimer = this.GetComponent<SliderTimer>();

        loadManager = this.GetComponent<LoadManager>();
        transitionNegativeBG = transitionNegativeBGScript.GetComponent<TransitionBackground>();
    }

    void Start()
    {
        GameAreaCollider = GameArea.GetComponent<Collider>();
        StartCoroutine(RePositionWithDelay());
    }

    void FixedUpdate()
    {
        setDifficulty();
        if(sliderTimer.gameTime2 > sliderTimer.gameTime )
            endingSystem();
    }

    private void Update()
    {
        
    }

    public void SetRandomPosition()
    {
        float x = Random.Range(GameAreaCollider.bounds.min.x, GameAreaCollider.bounds.max.x);
        float z = Random.Range(GameAreaCollider.bounds.min.z, GameAreaCollider.bounds.max.z);
        trashPosition = new Vector3(x, 150.0f, z); timer += Time.deltaTime; // 경과 시간 측정
        wasteTypeIndex = Random.Range(0, 3); 
        // 프리팹 오브젝트 생성
        GameObject newObject = Instantiate(fallingTrashArray[wasteTypeIndex], trashPosition, Quaternion.identity);

        if (newObject.gameObject.tag == "Plastic")
        {
            // 생성된 오브젝트 리스트에 추가
            spawnedPlasticList.Add(newObject);
        }
        else if (newObject.gameObject.tag == "Paper")
        {
            spawnedPaperList.Add(newObject);
        }
        else if (newObject.gameObject.tag == "Can")
        {
            spawnedCanList.Add(newObject);
        }
        soundManagerScript.SFXSound(soundManagerScript.sFXList[13]);
    }

    void setDifficulty()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                soundManagerScript.bGMNumber = 1;
                soundManagerScript.BGMSound();
                positive = true;
                currentMode();
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                soundManagerScript.bGMNumber = 3;
                soundManagerScript.BGMSound();
                positive = false;
                currentMode();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                difficultyTime = 3f;
                isTeam = false;
                currentMode();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                difficultyTime = 2.6f;
                isTeam = true;
                currentMode();
            }
        }
    }

    void currentMode()
    {
        if (positive == true)
        {
            Debug.Log("[현재 게임 엔딩 설정] 긍정엔딩");
        }
        else
        {
            Debug.Log("[현재 게임 엔딩 설정] 부정엔딩");
        }

        if (isTeam == true)
        {
            Debug.Log("[현재 게임 인원 설정] 3인용");
        }
        else
        {
            Debug.Log("[현재 게임 인원 설정] 1인용");
        }
    }

    IEnumerator RePositionWithDelay()
    {
        yield return new WaitForSecondsRealtime(6);
        while (true && positive == true)
        {
            if (!loadManager.pause)
            {
                if (sliderTimer.gameTime2 < 89 )
                {
                    yield return new WaitForSecondsRealtime(difficultyTime);
                    SetRandomPosition();
                    if(isTeam == true)
                    {
                        yield return new WaitForSecondsRealtime(0.2f);
                        SetRandomPosition();
                        yield return new WaitForSecondsRealtime(0.2f);
                        SetRandomPosition();
                    }
                }
                else
                {
                    yield return new WaitForSecondsRealtime(3);

                    break;
                }
            }
            else
            {
                yield return new WaitForSecondsRealtime(1);
            }
        }
    }

    void endingSystem()
    {
        if (positive == true)
        {
            GameObject fallingTrash = GameObject.FindWithTag("fallingTrash");
            if (fallingTrash != null)
            {
                Vector3 fallingTrashPosition = fallingTrash.transform.position;
                Destroy(fallingTrash);
            }
            ForPositiveEnding();
        }
        else if (positive == false)
        {
            ForNegativeEnding();
        }
    }
    void ForPositiveEnding()
    {
        PositiveEnding.SetActive(true);
        NegativeEnding.SetActive(false);
        soundManagerScript.bGMNumber = 2;
        if (endBGMPlay == false)
        {
            soundManagerScript.BGMSound();
            endBGMPlay = true;
        }
    }

    void ForNegativeEnding()
    {
        PositiveEnding.SetActive(false);
        NegativeEnding.SetActive(true);
        soundManagerScript.bGMNumber = 4;
        if (endBGMPlay == false)
        {
            soundManagerScript.BGMSound();
            endBGMPlay = true;
        }
        transitionNegativeBG.ChangeColor();

        NPCs.SetActive(false);
    }
}
