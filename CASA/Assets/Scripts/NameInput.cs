using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour {
	public GameObject startUI;
	public Text Name;
	public GameObject timerUI;
	
	public InputField playerNameInput;
	private string playerName = null;

	private void Awake(){
		playerName = playerNameInput.GetComponent<InputField>().text;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		if(Input.GetKeyDown(KeyCode.Return)){
			gameObject.SetActive(false);
			startUI.gameObject.SetActive(true);
			playerName = playerNameInput.text;
			Name.text = playerName + ",";
			timerUI.gameObject.SetActive(true);

		}
	}
}
