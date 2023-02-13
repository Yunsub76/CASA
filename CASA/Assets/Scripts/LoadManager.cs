using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Debug.Log("리스타트!!");
			SceneManager.LoadSceneAsync("StartSceneBackground");
		}
	}
}
