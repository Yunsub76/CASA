using System.IO.Compression;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFallingTrash : MonoBehaviour
{
    private Vector3 trashPosition;  
    [SerializeField] GameObject fallingTrashPrefab = null;
    private GameObject fallingTrash;
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
        trashPosition = new Vector3(x, 15.0f, z);
        fallingTrash = Instantiate(fallingTrashPrefab, trashPosition, fallingTrashPrefab.transform.rotation);
    }

    void SetRandomPositionTeam()
    {
        if(isTeam == true)
        {
            float x = Random.Range(GameAreaCollider.bounds.min.x, GameAreaCollider.bounds.max.x);
            float z = Random.Range(GameAreaCollider.bounds.min.z, GameAreaCollider.bounds.max.z);
            trashPosition = new Vector3(x, 15.0f, z);
            fallingTrash = Instantiate(fallingTrashPrefab, trashPosition, fallingTrashPrefab.transform.rotation);
            
            x = Random.Range(GameAreaCollider.bounds.min.x, GameAreaCollider.bounds.max.x);
            z = Random.Range(GameAreaCollider.bounds.min.z, GameAreaCollider.bounds.max.z);
            trashPosition = new Vector3(x, 15.0f, z);
            fallingTrash = Instantiate(fallingTrashPrefab, trashPosition, fallingTrashPrefab.transform.rotation);
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
