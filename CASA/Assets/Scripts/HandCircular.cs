using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCircular : MonoBehaviour {

	enum ZC_TYPE { NONE, POSITIVE, NEGATIVE, POS2NEG, NEG2POS };
	enum CIRCULAR_STATE { UNKNOWN, S1, S2, S3, S4 };
	//     hor.(x).   vert(y).
	// S1: POS2NEG,  NEGATIVE
	// S2: NEGATIVE, NEG2POS
	// S3: NEG2POS,  POSITIVE
	// S4: POSITIVE, POS2NEG

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

	ZC_TYPE zc_type = ZC_TYPE.NONE;

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

	ZC_TYPE zc_type_H = ZC_TYPE.NONE;

	// For circular tracking values
	int cirular_counter = 0;
	CIRCULAR_STATE prev_circular_state = CIRCULAR_STATE.UNKNOWN;
	int numOfCircles = 0;

	// Use this for initialization
	void Start()
	{

	}

	float GetSign(float y, float mean_y)
	{
		if (y > mean_y)
			return +1;
		else if (y < mean_y)
			return -1;
		return 0.0f;

	}

	CIRCULAR_STATE GetState(ZC_TYPE type_x, ZC_TYPE type_y)
    {
		//     hor.(x).   vert(y).
		// S1: POS2NEG,  NEGATIVE
		// S2: NEGATIVE, NEG2POS
		// S3: NEG2POS,  POSITIVE
		// S4: POSITIVE, POS2NEG

		if (type_x == ZC_TYPE.POS2NEG && type_y == ZC_TYPE.NEGATIVE)
			return CIRCULAR_STATE.S1;
		else if (type_x == ZC_TYPE.NEGATIVE && type_y == ZC_TYPE.NEG2POS)
			return CIRCULAR_STATE.S2;
		else if (type_x == ZC_TYPE.NEG2POS && type_y == ZC_TYPE.POSITIVE)
			return CIRCULAR_STATE.S3;
		else if (type_x == ZC_TYPE.POSITIVE && type_y == ZC_TYPE.POS2NEG)
			return CIRCULAR_STATE.S4;
		return CIRCULAR_STATE.UNKNOWN;
	}

	public void Init()
	{
		window.Clear();
		filterWindow.Clear();
		//elapsed_time = 0.0f;
		zeroCrossings = 0;
	}

	// Update is called once per frame
	void Update()
	{
		VerticalTracking();
		HorizontalTracking();
		var state = GetState(zc_type_H, zc_type);
		switch(state)
        {
			case CIRCULAR_STATE.S1:
				if (prev_circular_state == CIRCULAR_STATE.S4)
					cirular_counter += 1;
				else
					cirular_counter = 1;
				break;

			case CIRCULAR_STATE.S2:
				if (prev_circular_state == CIRCULAR_STATE.S1)
					cirular_counter += 1;
				else
					cirular_counter = 1;
				break;

			case CIRCULAR_STATE.S3:
				if (prev_circular_state == CIRCULAR_STATE.S2)
					cirular_counter += 1;
				else
					cirular_counter = 1;
				break;

			case CIRCULAR_STATE.S4:
				if (prev_circular_state == CIRCULAR_STATE.S3)
					cirular_counter += 1;
				else
					cirular_counter = 1;
				break;
		}

		if(cirular_counter >= 5)
        {
			numOfCircles += 1;
			cirular_counter = 1;
		}

		prev_circular_state = state;
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
				if(sign1 < sign2)
                {
					zc_type = ZC_TYPE.NEG2POS;
				}
				else
                {
					zc_type = ZC_TYPE.POS2NEG;
                }
				zeroCrossings += 1;
			}
			else
            {
				if (sign2 > 0)
					zc_type = ZC_TYPE.POSITIVE;
				else
					zc_type = ZC_TYPE.NEGATIVE;
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
				if (sign1_x < sign2_x)
				{
					zc_type_H = ZC_TYPE.NEG2POS;
				}
				else
				{
					zc_type_H = ZC_TYPE.POS2NEG;
				}
				zeroCrossings_H += 1;
			}
			else
			{
				if (sign2_x > 0)
					zc_type_H = ZC_TYPE.POSITIVE;
				else
					zc_type_H = ZC_TYPE.NEGATIVE;
			}

			window_H.RemoveAt(0);
		}
		Debug.Log(filterWindow_H.Count + "/" + min_x + "/" + max_x + "/" + height + "/" + zeroCrossings_H);

		prev_x = curr_x;
	}
}
