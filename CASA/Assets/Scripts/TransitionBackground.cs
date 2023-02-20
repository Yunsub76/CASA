using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBackground : MonoBehaviour {
	bool changeColor = false;
	Renderer BGColor;
	// Use this for initialization
	void Awake () {
		BGColor = GetComponent<Renderer>();
	}
	
	
	public void ChangeColor()
    {
        while (BGColor.material.color.a < 1)
        {
			BGColor.material.color = new Color(BGColor.material.color.r, BGColor.material.color.g, BGColor.material.color.b, BGColor.material.color.a + 0.01f);
		}
    }
}
