using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public int score = 0;
    public bool changeLightNum = false;
    [SerializeField] Text ScoreTextUI;

   void Update()
    {
        ScoreTextUI.text = string.Format("{0:0}", score);
    }
}
