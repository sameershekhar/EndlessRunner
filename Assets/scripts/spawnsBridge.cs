using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnsBridge : MonoBehaviour {

	private float size;
	public GameObject platForm1;
	public GameObject platForm2;
	public GameObject platForm3;
	public GameObject platForm4;




	private int index;
	private int indexTarget;
	private Vector3 lastPosition;


	void Start () {


		size = platForm1.transform.position.z;
		//Debug.Log (size);
		lastPosition = platForm1.transform.position;
		InvokeRepeating ("SpawnsPlatform", 1.25f, 1.0f);
		//InvokeRepeating ("SpawnsObstacles", 2f, 0.25f);
	
	}
		
	private void SpawnsPlatform(){
		
		if (!Player.isGameOver)
			SpawnsZ ();
		else {
			StopSpwans ();
		}
		
	}


	private void SpawnsX()
	{
		//Debug.Log ("x spawned");
		GameObject _platForm = Instantiate (platForm1)as GameObject;
	    _platForm.transform.position = lastPosition + new Vector3 (2f, 0f, 2f);
	
		lastPosition = lastPosition + new Vector3 (size+2f, 0f, 0f);
		Destroy (_platForm, 4.0f);

	}
	private void SpawnsZ()
	{
		//Debug.Log ("z spawned");
		int random = Random.Range (0, 8);

		if (random < 2) {
			GameObject _platForm = Instantiate (platForm1)as GameObject;
			_platForm.transform.position = lastPosition + new Vector3 (0f, 0f, size + 0.4f);
			lastPosition = _platForm.transform.position;
			IEnumerator co = DestroyMe (_platForm, 7f);
			StartCoroutine (co);
			if (Player.isGameOver)
				StopCoroutine (co);
			//Destroy (_platForm, 7.0f);
		} else if (random >= 2 && random < 4) {
			GameObject _platForm = Instantiate (platForm2)as GameObject;
			_platForm.transform.position = lastPosition + new Vector3 (0f, 0f, size + 0.4f);
			lastPosition = _platForm.transform.position;
			IEnumerator co = DestroyMe (_platForm, 7f);
			StartCoroutine (co);
			if (Player.isGameOver)
				StopCoroutine (co);
		} else if (random >= 4 && random < 6) {
			GameObject _platForm = Instantiate (platForm3)as GameObject;
			_platForm.transform.position = lastPosition + new Vector3 (0f, 0f, size + 0.4f);
			lastPosition = _platForm.transform.position;
			IEnumerator co = DestroyMe (_platForm, 7f);
			StartCoroutine (co);
			if (Player.isGameOver)
				StopCoroutine (co);
		} else {
			GameObject _platForm = Instantiate (platForm4)as GameObject;
			_platForm.transform.position = lastPosition + new Vector3 (0.5f, 0f, size + 0.4f);
			lastPosition = _platForm.transform.position;
			IEnumerator co = DestroyMe (_platForm, 7f);
			StartCoroutine (co);
			if (Player.isGameOver)
				StopCoroutine (co);
		}
	}

	IEnumerator DestroyMe(GameObject obj, float delayTime)
	{
		yield return new WaitForSeconds(delayTime);
		Destroy (obj);
		// Now do your thing here
	}
	public void StopSpwans(){
		CancelInvoke ("SpawnsPlatform");
	}


}
