using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour {
	public float lightS;
	public float lightH;
	bool loc = true;
	bool locH = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x >= 250 )
		{
			loc = false;
		}
		else if(transform.position.x <= -250)
		{
			loc = true;
		}
		if (loc == true)
		{
			transform.position = new Vector3(transform.position.x + lightS, transform.position.y, transform.position.z);
		}
		else if(loc == false)
        {
			transform.position = new Vector3(transform.position.x - lightS, transform.position.y, transform.position.z);
		}
		if (transform.position.y >= 100)
		{
			locH = false;
		}
		else if (transform.position.y <=30)
		{
			locH = true;
		}
		if (locH == true)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + lightH, transform.position.z);
		}
		else if (locH == false)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y - lightH, transform.position.z);
		}
	}
}
