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
    private Collider GameAreaCollider = null;

    private float difficultyTime = 3f;
    private bool isTeam = false;

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
            
            x = Random.Range(GameAreaCollider.bounds.min.x, GameAreaCollider.bounds.max.x);
            z = Random.Range(GameAreaCollider.bounds.min.z, GameAreaCollider.bounds.max.z);
            i = Random.Range(0, 5); 
            trashPosition = new Vector3(x, 140.0f, z);
            fallingTrash = Instantiate(fallingTrashArray[i], trashPosition, fallingTrashArray[i].transform.rotation);
        }
    }

    void setDifficulty()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            difficultyTime = 4f; 
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            difficultyTime = 2f;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            isTeam = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            isTeam = true;
        }
    }

    IEnumerator RePositionWithDelay()
    {
        while(true)
        {
            yield return new WaitForSecondsRealtime(difficultyTime);           
            SetRandomPosition();
            SetRandomPositionTeam();
        }
    }

    
}
