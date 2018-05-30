using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraMovement : MonoBehaviour {

	public GameObject player;       

	private Vector3 moveVector;
	private Vector3 offset;  
	private float transition = 0.0f;
	private float animatioDuration = 2.0f;
	private Vector3 animationOffset = new Vector3 (0, 2, 5);

	void Start () 
	{
		
		offset = transform.position + player.transform.position;
		//offset.x = player.transform.position.x - 0.4f;
	}

	// LateUpdate is called after Update each frame
	void Update () 
	{
		if (Player.isGameOver)
			return;
		
		moveVector = player.transform.position + offset;
		moveVector.x = 0f;
		moveVector.y = Mathf.Clamp (moveVector.y, 1, 5);


		if (transition > 1.0f) {
			transform.position = moveVector;
			transform.rotation = Quaternion.Euler (20f, 2.8f, 1f);
		} else {
			//animate here
//			
			transform.position = Vector3.Lerp (moveVector+animationOffset,moveVector,transition);
			transition += Time.deltaTime * 1 / animatioDuration;
			transform.LookAt (player.transform.position, Vector3.up);
		}
			

	}
}
