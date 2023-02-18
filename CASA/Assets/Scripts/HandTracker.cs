using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracker : MonoBehaviour {

	//For vertical tracking values
	List<Vector3> filterWindow = new List<Vector3>();
	 //float filter_elapsed_time = 0.0f;
	public int filter_window_count = 5;

	List<Vector3> window = new List<Vector3>();
	float prev_y = 0.0f;
	 //float elapsed_time = 0.0f;
	int zeroCrossings = 0;
	public int window_count = 10;

	public float minimun_height = 0.2f;

	//For Horizontal tracking values
	List<Vector3> filterWindow_H = new List<Vector3>();
	 //float filter_elapsed_time = 0.0f;
	public int filter_window_H_count = 5;

	List<Vector3> window_H = new List<Vector3>();
	float prev_x = 0.0f;
	 //float elapsed_time = 0.0f;
	int zeroCrossings_H = 0;
	public int window_H_count = 10;

	public float minimun_width = 0.2f;

	// Use this for initialization
	void Start () {
		
	}

	float GetSign(float y, float mean_y)
	{
		if(y > mean_y)
			return +1;
		else if(y < mean_y)
			return -1;
		return 0.0f;
		
	}

	public void Init() {
		window.Clear();
		filterWindow.Clear();
		 //elapsed_time = 0.0f;
		zeroCrossings = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void VerticalTracking()
    {
		Vector3 currPosition = transform.position;
		window.Add(currPosition);
		//elapsed_time += Time.deltaTime;

		filterWindow.Add(currPosition);
		//filter_elapsed_time += Time.deltaTime;

		float curr_y = 0.0f;
		float min_y = 10000.0f;
		float max_y = -10000.0f;
		if (filterWindow.Count > filter_window_count)
		{
			int n = filterWindow.Count;
			foreach (var item in filterWindow)
			{
				curr_y += item.y;
				if (min_y > item.y) min_y = item.y;
				if (max_y < item.y) max_y = item.y;
			}
			curr_y /= n;
			filterWindow.RemoveAt(0);
		}
		float height = max_y - min_y;


		if (window.Count > window_count && height > minimun_height)
		{
			float mean_y = 0.0f;
			int n = window.Count;
			foreach (var item in window)
			{
				mean_y += item.y;
			}
			mean_y /= n;

			float sign1 = GetSign(prev_y, mean_y);
			float sign2 = GetSign(curr_y, mean_y);

			if (sign1 != sign2)
			{
				zeroCrossings += 1;
			}

			window.RemoveAt(0);
		}
		//Debug.Log(filterWindow.Count + "/" + min_y + "/" + max_y + "/" + height + "/" + zeroCrossings);

		prev_y = curr_y;
	}

	void HorizontalTracking()
	{
		Vector3 currPosition = transform.position;
		window_H.Add(currPosition);
		//elapsed_time += Time.deltaTime;

		filterWindow_H.Add(currPosition);
		//filter_elapsed_time += Time.deltaTime;

		float curr_x = 0.0f;
		float min_x = 10000.0f;
		float max_x = -10000.0f;
		if (filterWindow_H.Count > filter_window_H_count)
		{
			int n = filterWindow_H.Count;
			foreach (var item in filterWindow_H)
			{
				curr_x += item.x;
				if (min_x > item.x) min_x = item.x;
				if (max_x < item.x) max_x = item.x;
			}
			curr_x /= n;
			filterWindow_H.RemoveAt(0);
		}
		float height = max_x - min_x;


		if (window_H.Count > window_H_count && height > minimun_width)
		{
			float mean_x = 0.0f;
			int n = window_H.Count;
			foreach (var item in window_H)
			{
				mean_x += item.x;
			}
			mean_x /= n;

			float sign1_x = GetSign(prev_x, mean_x);
			float sign2_x = GetSign(curr_x, mean_x);

			if (sign1_x != sign2_x)
			{
				zeroCrossings_H += 1;
			}

			window_H.RemoveAt(0);
		}
		Debug.Log(filterWindow_H.Count + "/" + min_x + "/" + max_x + "/" + height + "/" + zeroCrossings_H);

		prev_x = curr_x;
	}
}
