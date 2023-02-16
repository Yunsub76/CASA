
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFallingTrash : MonoBehaviour
{
    private Vector3 trashPosition;  
    
    private GameObject fallingTrash;
    [SerializeField] private GameObject[] fallingTrashArray = new GameObject[5];

    [SerializeField] GameObject GameArea;

    [SerializeField] GameObject soundManager;
    private SoundManager soundManagerScript;
    private SliderTimer sliderTimer;

    private Collider GameAreaCollider = null;

    private float difficultyTime = 3f;
    public bool isTeam = false;
    public bool positive = true;

    private LoadManager loadManager;

    [SerializeField] private GameObject PositiveEnding;
    [SerializeField] private GameObject NegativeEnding;
    [SerializeField] private GameObject NPCs;

    void Awake()
    {
        soundManagerScript = soundManager.GetComponent<SoundManager>();
        sliderTimer = this.GetComponent<SliderTimer>();

        loadManager = this.GetComponent<LoadManager>();
    }

    void Start()
    {
        GameAreaCollider = GameArea.GetComponent<Collider>();
        StartCoroutine(RePositionWithDelay());
    }

    void FixedUpdate()
    {
        setDifficulty();
        if(sliderTimer.gameTime2 > sliderTimer.gameTime - 1)
            endingSystem();
    }

    public void SetRandomPosition()
    {
        float x = Random.Range(GameAreaCollider.bounds.min.x, GameAreaCollider.bounds.max.x);
        float z = Random.Range(GameAreaCollider.bounds.min.z, GameAreaCollider.bounds.max.z);
        int i = Random.Range(0, 5);  
        trashPosition = new Vector3(x, 150.0f, z);
        fallingTrash = Instantiate(fallingTrashArray[i], trashPosition, fallingTrashArray[i].transform.rotation);
        soundManagerScript.SFXSound(soundManagerScript.sFXList[13]);
    }

    void SetRandomPositionTeam()
    {
        if(isTeam == true)
        {
            float x = Random.Range(GameAreaCollider.bounds.min.x, GameAreaCollider.bounds.max.x);
            float z = Random.Range(GameAreaCollider.bounds.min.z, GameAreaCollider.bounds.max.z);
            int i = Random.Range(0, 5); 
            trashPosition = new Vector3(x, 150.0f, z);
            fallingTrash = Instantiate(fallingTrashArray[i], trashPosition, fallingTrashArray[i].transform.rotation);
            
            x = Random.Range(GameAreaCollider.bounds.min.x, GameAreaCollider.bounds.max.x);
            z = Random.Range(GameAreaCollider.bounds.min.z, GameAreaCollider.bounds.max.z);
            i = Random.Range(0, 5); 
            trashPosition = new Vector3(x, 150.0f, z);
            fallingTrash = Instantiate(fallingTrashArray[i], trashPosition, fallingTrashArray[i].transform.rotation);
        }
    }

    void setDifficulty()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            difficultyTime = 4f; 
            soundManagerScript.bGMNumber = 1;
            soundManagerScript.BGMSound();
            positive = true;
            currentMode();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            difficultyTime = 2f;
            soundManagerScript.bGMNumber = 3; 
            soundManagerScript.BGMSound();
            positive = false;
            currentMode();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            isTeam = false;
            currentMode();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            isTeam = true;
            currentMode();
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
                    SetRandomPositionTeam();
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
        soundManagerScript.bGMNumber = 2;
    }

    void ForNegativeEnding()
    {
        NegativeEnding.SetActive(true);
        soundManagerScript.bGMNumber = 4;
        
        soundManagerScript.SFXSound(soundManagerScript.sFXList[9]);
        NPCs.SetActive(false);
    }
}
