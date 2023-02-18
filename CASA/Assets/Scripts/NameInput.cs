using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour {
	public GameObject playUI;
	public Text Name;
	//public Text Name2;
	public GameObject timerUI;
	
	public InputField playerNameInput;
	private string playerName = null;	

	public GameObject rankTitle;
	public GameObject rankGroup;
	public GameObject title;



	private void Awake(){
		playerName = playerNameInput.GetComponent<InputField>().text;

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		if(Input.GetKeyDown(KeyCode.Return)){
			this.gameObject.SetActive(false);
			Destroy(rankTitle);
			Destroy(rankGroup);
			Destroy(this.gameObject);
			Destroy(title);

			playUI.gameObject.SetActive(true);
			playerName = playerNameInput.text;
			//Name.text = playerName + "!";
			Name.text = playerName +",";
			//timerUI.gameObject.SetActive(true);

		}
	}
}
