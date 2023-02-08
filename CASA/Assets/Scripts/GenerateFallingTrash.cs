using System.IO.Compression;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFallingTrash : MonoBehaviour
{
    private Vector3 trashPosition;  
    public GameObject fallingTrashPrefab = null;
    private GameObject fallingTrash;
    //public GameObject RestBall;
    //private ResetGame ResetGame;

    void SetRandomPosition()
    {
        float x = Random.Range(85.0f, 95.0f);
        float z = Random.Range(-5.0f, 5.0f);
        trashPosition = new Vector3(x, 10.0f, z);
        fallingTrash = Instantiate(fallingTrashPrefab, trashPosition, fallingTrashPrefab.transform.rotation);
    }

    IEnumerator RePositionWithDelay()
    {
        while(true)
        {
            //RestBall.SetActive(true);
            yield return new WaitForSecondsRealtime(3);
            //ResetGame.resetDelay = false;
            //RestBall.SetActive(false);
           
            SetRandomPosition();
            yield return new WaitForSeconds(0.25f);
        }
    }

    void Start()
    {   
        //RestBall.SetActive(false);
        //ResetGame = GameObject.Find("Character").GetComponent<ResetGame>();
        StartCoroutine(RePositionWithDelay());
    }
}
