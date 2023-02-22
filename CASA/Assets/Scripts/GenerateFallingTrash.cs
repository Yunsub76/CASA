
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenerateFallingTrash : MonoBehaviour
{
    private Vector3 trashPosition;  
    
    private GameObject fallingTrash;

    [SerializeField] GameObject GameArea;

    [SerializeField] GameObject soundManager;

    ActivateUI activateUI;

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
    public float spawnInterval = 5.0f; // 생성 간격(초)

    //생성된 오브젝트 리스트
    public List<GameObject> spawnedPlasticList = new List<GameObject>(); 
    public List<GameObject> spawnedPaperList = new List<GameObject>(); 
    public List<GameObject> spawnedCanList = new List<GameObject>(); 

    [SerializeField] private GameObject[] fallingTrashArray = new GameObject[3]; // 플라스틱, 종이, 캔 
    private int wasteTypeIndex = 0;

    private int[] TrashLimitationArray = new int[3] {0, 0, 0};

    int a = 0;
    int b = 3;

    public bool IsMissionTime = false;

    ScoreManager scoreManager;

    [SerializeField] private GameObject[] fakeTrashArray = new GameObject[3];

    void Awake()
    {
        soundManagerScript = soundManager.GetComponent<SoundManager>();
        sliderTimer = this.GetComponent<SliderTimer>();
        activateUI = this.GetComponent<ActivateUI>();
        loadManager = this.GetComponent<LoadManager>();
        transitionNegativeBG = transitionNegativeBGScript.GetComponent<TransitionBackground>();
        scoreManager = this.GetComponent<ScoreManager>();
    }

    void Start()
    {
        GameAreaCollider = GameArea.GetComponent<Collider>();
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            StartCoroutine(RePositionWithDelay());
        }
    }

    void FixedUpdate()
    {
        setDifficulty();
    }

    private void Update()
    {
        
    }

    public void SetRandomPosition()
    {
        float x = Random.Range(GameAreaCollider.bounds.min.x, GameAreaCollider.bounds.max.x);
        float z = Random.Range(GameAreaCollider.bounds.min.z, GameAreaCollider.bounds.max.z);
        trashPosition = new Vector3(x, 150.0f, z);

        if (TrashLimitationArray[0] == 11)
        {
            a = 1;
            if (TrashLimitationArray[1] == 8)
            {
                a = 2;
            }
        }
        else if (TrashLimitationArray[2] == 8)
        {
            b = 2;
            if (TrashLimitationArray[1] == 8)
            {
                b = 1;
            }
        }
        
        wasteTypeIndex = Random.Range(a, b);

        if (TrashLimitationArray[1] == 8)
        {
           if (wasteTypeIndex == 1)
            {
                wasteTypeIndex = 2;
            }
        }

        if (TrashLimitationArray[0]+TrashLimitationArray[1]+TrashLimitationArray[2] < 28)
        {
            // 프리팹 오브젝트 생성
            GameObject newObject = Instantiate(fallingTrashArray[wasteTypeIndex], trashPosition, Quaternion.identity);

            if (newObject.gameObject.tag == "Plastic")
            {
                // 생성된 오브젝트 리스트에 추가
                spawnedPlasticList.Add(newObject);
                TrashLimitationArray[0] += 1;
            }
            else if (newObject.gameObject.tag == "Paper")
            {
                spawnedPaperList.Add(newObject);
                TrashLimitationArray[1] += 1;
            }
            else if (newObject.gameObject.tag == "Can")
            {
                spawnedCanList.Add(newObject);
                TrashLimitationArray[2] += 1;
            }
            soundManagerScript.SFXSound(soundManagerScript.sFXList[13]);
        }
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

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                difficultyTime = 3f;
                isTeam = false;
                currentMode();
                scoreManager.teamBalance = 1;
                scoreManager.GaugeArray[0].GetComponent<Slider>().maxValue = 30;
                scoreManager.GaugeArray[1].GetComponent<Slider>().maxValue = 20;
                scoreManager.GaugeArray[2].GetComponent<Slider>().maxValue = 10;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                difficultyTime = 2.6f;
                isTeam = true;
                currentMode();  
                scoreManager.teamBalance = 3;
                scoreManager.GaugeArray[0].GetComponent<Slider>().maxValue = 30 * scoreManager.teamBalance;
                scoreManager.GaugeArray[1].GetComponent<Slider>().maxValue = 20 * scoreManager.teamBalance;
                scoreManager.GaugeArray[2].GetComponent<Slider>().maxValue = 10 * scoreManager.teamBalance;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                fakeTrashArray[0].GetComponent<RightPositionDiscriminator>().GetPoint();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                fakeTrashArray[1].GetComponent<RightPositionDiscriminator>().GetPoint();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                fakeTrashArray[2].GetComponent<RightPositionDiscriminator>().GetPoint();
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
        yield return new WaitForSecondsRealtime(7f); 
        if (positive == false)
        {
            SetRandomPosition();
            if (isTeam == true)
            {
                yield return new WaitForSecondsRealtime(0.2f);
                SetRandomPosition();
                yield return new WaitForSecondsRealtime(0.2f);
                SetRandomPosition();
            }
        }
        
        while (true && positive == true)
        {
            if (!loadManager.pause && IsMissionTime == false && activateUI.IsGaming == true)
            {
                if (sliderTimer.gameTime2 < sliderTimer.gameTime)
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

    public void endingSystem()
    {
        if (positive == true)
        {
            while(spawnedPlasticList.Count != 0)
            {
				Destroy(spawnedPlasticList[0]);
                spawnedPlasticList.RemoveAt(0);
            }
            while (spawnedPaperList.Count != 0)
            {
				Destroy(spawnedPaperList[0]);
                spawnedPaperList.RemoveAt(0);
            }
            while (spawnedCanList.Count != 0)
            {
				Destroy(spawnedCanList[0]);
                spawnedCanList.RemoveAt(0);
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
