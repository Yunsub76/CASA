using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameActivate : MonoBehaviour {
	[SerializeField] RectTransform gameobjrct;

	// Use this for initialization
	void Awake()
    {
		GetComponent<Image>().rectTransform.sizeDelta = new Vector2(0,GetComponent<Image>().rectTransform.sizeDelta.y);

	}

	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Image>().rectTransform.sizeDelta.x < 250)
        {
			GetComponent<Image>().rectTransform.sizeDelta = new Vector2(GetComponent<Image>().rectTransform.sizeDelta.x + 20, GetComponent<Image>().rectTransform.sizeDelta.y);
		}
	}
}
