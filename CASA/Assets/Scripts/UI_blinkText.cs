using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_blinkText : MonoBehaviour {
	public Text flashingText;

	// Use this for initialization
	void Start () {
		string animText = flashingText.text;
		flashingText.text = "";
		StartCoroutine(BlinkText(animText));
	}
	
	public IEnumerator BlinkText(string text){
		while(true){
			flashingText.text = "";
			yield return new WaitForSeconds (.5f);
			flashingText.text = text;
			yield return new WaitForSeconds (.5f);
		}
	}
}
