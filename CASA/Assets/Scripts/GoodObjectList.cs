using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodObjectList : MonoBehaviour 
{
	[SerializeField] private GameObject GoodPrefab;
    public List<GameObject> goodObjectList = new List<GameObject> ();
	
	void Start () 
	{
		goodObjectList.Add(GoodPrefab);
	}

	void Update () 
	{
		
	}
}
