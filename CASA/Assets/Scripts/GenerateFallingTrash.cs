using System.IO.Compression;
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
    private bool isTeam = false;
    public bool isSingle = true;
    public bool positive = true;

    void Awake()
    {
        soundManagerScript = soundManager.GetComponent<SoundManager>();
        sliderTimer = this.GetComponent<SliderTimer>();
    }

    void Start()
    {
        GameAreaCollider = GameArea.GetComponent<Collider>();
        StartCoroutine(RePositionWithDelay());
    }

    void FixedUpdate()
    {
        setDifficulty();
    }

    void SetRandomPosition()
    {
        float x = Random.Range(GameAreaCollider.bounds.min.x, GameAreaCollider.bounds.max.x);
        float z = Random.Range(GameAreaCollider.bounds.min.z, GameAreaCollider.bounds.max.z);
        int i = Random.Range(0, 5);  
        trashPosition = new Vector3(x, 140.0f, z);
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
            trashPosition = new Vector3(x, 140.0f, z);
            fallingTrash = Instantiate(fallingTrashArray[i], trashPosition, fallingTrashArray[i].transform.rotation);
            soundManagerScript.SFXSound(soundManagerScript.sFXList[13]);

            x = Random.Range(GameAreaCollider.bounds.min.x, GameAreaCollider.bounds.max.x);
            z = Random.Range(GameAreaCollider.bounds.min.z, GameAreaCollider.bounds.max.z);
            i = Random.Range(0, 5); 
            trashPosition = new Vector3(x, 140.0f, z);
            fallingTrash = Instantiate(fallingTrashArray[i], trashPosition, fallingTrashArray[i].transform.rotation);
            soundManagerScript.SFXSound(soundManagerScript.sFXList[13]);
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
            Debug.Log(positive);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            difficultyTime = 2f;
            soundManagerScript.bGMNumber = 3; 
            soundManagerScript.BGMSound();
            positive = false;
            Debug.Log(positive);
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            isTeam = false;
            isSingle = true;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            isTeam = true;
            isSingle = false;
        }
    }

    IEnumerator RePositionWithDelay()
    {
        while(sliderTimer.gameTime > 1)
        {
            yield return new WaitForSecondsRealtime(difficultyTime);           
            SetRandomPosition();
            SetRandomPositionTeam();
        }
    }
}
