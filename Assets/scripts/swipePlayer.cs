using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipePlayer : MonoBehaviour {

	public GameObject player;
	private float speed = 2.0f;
	public float maxTime;
	public float minSwipeDistance;

	private float startTime;
	private float endTime;

	private Vector3 startPos;
	private Vector3 endPos;

	private float swipeDistance;
	private float swipeTime;

	public static bool isZ = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch (0);

			if (touch.phase == TouchPhase.Began) {
				startTime = Time.time;
				startPos = touch.position;
				
			} else if (touch.phase == TouchPhase.Ended) {
				endTime = Time.time;
				endPos = touch.position;
				swipeTime = endTime - startTime;
				swipeDistance = (startPos - endPos).magnitude;

				if (swipeTime < maxTime && swipeDistance > minSwipeDistance) {
					swipe ();
				}
			}
		
		}
	}

	public void swipe(){

		Vector2 distance = endPos - startPos;

		if (Mathf.Abs (distance.x) > Mathf.Abs (distance.y)) {

			if (distance.x > 0) {
				isZ = false;
				Debug.Log ("hor right swipe");
				player.transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);

			} else if (distance.x < 0) {
				isZ = true;
				Debug.Log ("hor left swipe");
				player.transform.Translate(Vector3.left * Time.deltaTime * speed, Space.Self);

			}
		}

		if (Mathf.Abs (distance.x) < Mathf.Abs (distance.y)) {

			if (distance.y > 0) {
				Debug.Log ("ver up swipe");
			} else if (distance.y < 0) {
				Debug.Log ("ver down swipe");
			}
		}



	}

}
