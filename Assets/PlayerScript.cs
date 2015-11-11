﻿using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public Rigidbody playerRigid;
	public Transform playerTrans;
	public GameObject hitTrigger;
	public float  speed, speedMod, rotateAngle, jumpForce;
	public bool isFullSpeed;
	// Use this for initialization
	void Start () {
		playerRigid = GetComponent<Rigidbody>();
		playerTrans = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		PlayerMovement();
	}

	void Update (){
		if (Input.GetMouseButtonDown(0)){
			Debug.Log ("Has Clicked");
			PlayerAttack();
		}

	}

	public void PlayerMovement(){
		speed = Input.GetAxis("Vertical") * speedMod;
		//Apply the direction to the character, with modifiers of speed and incrementation
		playerRigid.MovePosition (transform.position + transform.forward * speed * Time.deltaTime);
		playerTrans.Rotate(Vector3.up, rotateAngle * Input.GetAxis("Horizontal") * Time.deltaTime);

		if (speed >= 6){
			isFullSpeed = true;
		} else {
			isFullSpeed = false;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		    playerRigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
	}

	public void PlayerAttack(){
		Debug.Log ("has Player attacked");
		hitTrigger.GetComponent<HitTrigger>().TriggerAttack();
	}
}
