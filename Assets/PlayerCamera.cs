using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	GameObject player;
	Camera cam;
	float MouseX;
	float MouseY;

	bool cursorLock = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		cam = Camera.main;
		//Cursor.visible = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		MouseX = Input.GetAxis("Mouse X");
		MouseY = Input.GetAxis("Mouse Y");

		transform.position = player.transform.position;

		LockCursor();

	}

	void FixedUpdate(){
		Vector3 cameraPosition = new Vector3(-MouseY, MouseX, 0.0f);
		transform.eulerAngles += cameraPosition;	
	}

	void LockCursor(){
		if(Input.GetKeyDown(KeyCode.C)){
			if(!cursorLock){
				Cursor.lockState = CursorLockMode.Locked;
				Debug.Log("Cursor Lock");
				cursorLock = true;
			}
			else{
				Cursor.lockState = CursorLockMode.None;
				cursorLock = false;
				Debug.Log("Cursor Unlocked");
			}
			
		}
	}
}
