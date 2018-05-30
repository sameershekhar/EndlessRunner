using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {


	private AudioSource audioSoundPing,audioSoundBurn,audioScream,audioSoundBack;
	public Text highScore;
	public Text life;
	public GameObject panel;
	public Text scoreText;
	private int scoreCount;
	private int lifeCount;
	public GameObject lifePanel;

	public GameObject pts;
	public GameObject pts1;
	private CharacterController controller;
	[HideInInspector]
	public static float speed = 10.0f;
	private Vector3 moveVector;

	private float verticalVelocity = 0f;
	private float animatioDuration = 1.50f;
	private bool isLeft=true;
	public static bool isGameOver = false;

	// Use this for initialization
	void Start () {
		isLeft=true;

		isGameOver = false;
		speed = 12.0f;
		verticalVelocity = 0f;
		animatioDuration = 2.0f;
		controller = GetComponent<CharacterController> ();
		AudioSource[] audios = GetComponents<AudioSource>();
		audioSoundPing = audios[0];
		audioSoundBurn = audios[1];
		audioScream = audios[2];
		audioSoundBack = audios[3];
		InvokeRepeating ("UpdateScore", animatioDuration, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time < animatioDuration) {
			controller.Move (Vector3.forward * 5.0f* Time.deltaTime);
			return;
		}

	

		moveVector = Vector3.zero;
		if (controller.isGrounded) {
			verticalVelocity = -0.5f;
		} else {
			verticalVelocity -= 12.0f * Time.deltaTime;

		}
		moveVector.z = speed;
		moveVector.y = verticalVelocity;
		controller.Move (moveVector* Time.deltaTime);
		if (Input.GetMouseButtonDown (0)&&!Player.isGameOver)
			SwipeLeftAndRight ();


		if (speed < 18f) {
			speed += Time.deltaTime * 0.3f;
		}

		//Debug.Log (speed);

	}

	private void SwipeLeftAndRight (){
		Vector3 lastPosition = this.transform.localPosition;
		if (isLeft) {
			transform.localPosition = new Vector3 (lastPosition.x - 1f, lastPosition.y, lastPosition.z);
			isLeft = false;
		} else {
			transform.localPosition = new Vector3 (lastPosition.x + 1f, lastPosition.y, lastPosition.z);
			isLeft = true;
		}
			
	}
    void OnTriggerEnter(Collider col)
	{
		//Debug.Log (col.gameObject.tag);
		if (col.gameObject.tag == "Fire") {
			//
			if (lifeCount == 0) {
				isGameOver = true;
				Invoke ("GameOver", 1.3f);
				Player.speed = 0f;
				audioSoundBurn.Play ();
				Destroy (this.gameObject, 1.3f);
				GameObject _platForm = Instantiate (pts1)as GameObject;
				_platForm.transform.position = col.transform.position;
				Destroy (_platForm, 1.3f);
			} else
				lifeCount--;
			    audioScream.Play ();
			    GameObject _platForm1 = Instantiate (pts1)as GameObject;
			   _platForm1.transform.position = col.transform.position;
			    Destroy (_platForm1, 0.2f);
			//StartCoroutine(ExecuteAfterTime(1));


		} else if (col.gameObject.tag == "Gems") {
			Destroy (col.gameObject);
			scoreCount += 5;
			UpdateLife ();
			audioSoundPing.Play ();
			GameObject _platForm = Instantiate (pts)as GameObject;
			_platForm.transform.position = col.transform.position;
			Destroy (_platForm, 1.0f);
		}
	}


	private void UpdateScore()
	{
		if (!isGameOver) {
			scoreCount += 1;
			UpdateLife ();
			scoreText.text = scoreCount.ToString ();
		

			
		}

	}

	private void UpdateLife()
	{
		if (( scoreCount % 200) == 0)
		{
			lifeCount += 1;
			//Debug.Log ("enter");
		}
		life.text = "* "+lifeCount.ToString ();
		
	}

	private void GameOver()
	{
		AdManager.ShowAd ();

		panel.SetActive (true);
		lifePanel.SetActive (false);

		if (scoreCount > PlayerPrefs.GetInt ("Score")) {
			scoreCount -= 5;
			highScore.text = "HighScore : " + scoreCount.ToString ();
			PlayerPrefs.SetInt ("Score", scoreCount);
		} else {
			highScore.text = "HighScore : " + PlayerPrefs.GetInt ("Score");

		}

		
    }


}
