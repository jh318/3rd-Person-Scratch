using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float Horizontal{
		get {return horizontal;}
	}
	public float Vertical{
		get {return vertical;}
	}
	public float HorizontalRaw{
		get{return horizontalRaw;}
	}
	public float VerticalRaw{
		get{return verticalRaw;}
	}

	public float Speed{
		get{return speed;}
	}
	public float AngularVelocity{
		get{return angularVelocity;}
	}
	public Vector3 TargetVelocity{
		get {return targetVelocity;}
	}

	public float maxTurnSpeed = 200.0f;
	public float maxSpeed = 10.0f;

	float horizontal;
	float vertical;
	float horizontalRaw;
	float verticalRaw;

	float speed;
	float angularVelocity;

	Camera cam;
	Vector3 targetVelocity;

	void Start(){
		cam = Camera.main;
	}

	void Update(){
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
		horizontalRaw = Input.GetAxisRaw("Horizontal");
		verticalRaw = Input.GetAxisRaw("Vertical");

		Rotation();
	}

	void Rotation(){
		Vector3 axis = new Vector3(horizontalRaw, 0.0f, verticalRaw);
		Vector3 targetDirection = (cam.transform.forward * axis.z + cam.transform.right * axis.x);
		Vector3 forwardToTargetCross = Vector3.Cross(transform.forward, targetDirection);
		float rotation = forwardToTargetCross.y;
		
		if(Vector3.Dot(transform.forward, targetDirection) < 0){
			rotation = Mathf.Sign(rotation);
		}

		transform.eulerAngles += Vector3.up * rotation * maxSpeed * Time.deltaTime;
	}
}
