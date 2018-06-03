using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionState : StateMachineBehaviour {

	PlayerController player;
	Rigidbody body;
	Vector3 lastAxis;
	float lastHorizontal;
	float lastVertical;

	public float speedToRunStop = 2.5f;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
			body = animator.gameObject.GetComponent<Rigidbody>();
			animator.SetBool("isMoving", true);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetFloat("Horizontal", player.Horizontal);
		animator.SetFloat("Vertical", player.Vertical);
		animator.SetFloat("RotationDirection", player.RotationDirection);
		//animator.SetFloat("AngularVelocity", animator.gameObject.GetComponent<Rigidbody>().angularVelocity));
		animator.SetFloat("SpeedX", body.velocity.z);
		animator.SetFloat("SpeedZ", body.velocity.x);

		// if(player.Axis == Vector3.zero 
		// && Mathf.Abs(animator.GetFloat("SpeedX")) < speedToRunStop
		// && Mathf.Abs(animator.GetFloat("SpeedZ")) < speedToRunStop)
		// {
		// 	animator.SetBool("isMoving", false);
		// }

	

		if(Mathf.Abs(animator.GetFloat("Horizontal")) < 0.1f
		&& Mathf.Abs(animator.GetFloat("Vertical")) < 0.1f)
		{
			animator.SetBool("isMoving", false);
		}

		if(Vector3.Dot(player.transform.forward, player.TargetDirection) <= -0.93f)
		{
			Debug.Log(Vector3.Dot(player.transform.forward, player.TargetDirection));
			animator.SetBool("RunPivot", true);
		}

		// if(Mathf.Abs(player.Rotation) == 1.0f)
		// {
		// 	animator.SetBool("RunPivot", true);
		// }

		// if(Vector3.Dot(player.transform.forward, player.TargetDirection) <= -0.9f){
		// 	Debug.Log(Vector3.Dot(player.transform.forward, player.TargetDirection));
		// }
		//Debug.Log(Vector3.Dot(player.transform.forward, player.TargetDirection));

		// if(player.Axis == Vector3.zero){
		// 	animator.SetBool("RunPivot", false);
		// }


		lastHorizontal = player.Horizontal;
		lastVertical = player.Vertical;
		lastAxis = player.Axis;
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
