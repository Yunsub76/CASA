using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.F5))
		{
			restart();
		}

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			restart();
		}
	}

	void restart()
    {
		SceneManager.LoadSceneAsync("StartSceneBackground");
	}

	void loadInGameScene()
    {
		SceneManager.LoadSceneAsync("StartSceneBackground");
	}
}
