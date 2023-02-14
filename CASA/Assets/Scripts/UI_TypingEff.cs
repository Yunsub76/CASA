using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TypingEff : MonoBehaviour {
	public Text welcomeText;
	


	// Use this for initialization
	void Start () {
		string animText = welcomeText.text;
		welcomeText.text = "";


		StartCoroutine(Typing(animText));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Typing(string text){
		foreach (char letter in text.ToCharArray()){
			welcomeText.text += letter;
			yield return new WaitForSeconds(0.1f);
		}
	}
}
