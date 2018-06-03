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
	public Vector3 TargetDirection{
		get {return targetDirection;}
	}
	public float RotationDirection{
		get {return rotationDirection;}
	}
	public Vector3 Axis{
		get {return axis;}
	}

	public float maxTurnSpeed = 200.0f;
	public float maxSpeed = 10.0f;

	float horizontal;
	float vertical;
	float horizontalRaw;
	float verticalRaw;

	float speed;
	float angularVelocity;
	float rotationDirection;

	Camera cam;
	Vector3 targetDirection;
	Vector3 axis;

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
		axis = new Vector3(horizontalRaw, 0.0f, verticalRaw);
		targetDirection = (cam.transform.forward * axis.z + cam.transform.right * axis.x);
		Vector3 forwardToTargetCross = Vector3.Cross(transform.forward, targetDirection);
		float rotation = forwardToTargetCross.y;
		
		if(Vector3.Dot(transform.forward, targetDirection) < 0){
			rotation = Mathf.Sign(rotation);
		}

		transform.eulerAngles += Vector3.up * rotation * maxTurnSpeed * Time.deltaTime;
		rotationDirection = Mathf.Sign(rotation);
	}
}
