﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionState : StateMachineBehaviour {

	PlayerController player;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
			player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetFloat("Horizontal", player.Horizontal);
		animator.SetFloat("Vertical", player.Vertical);
		animator.SetFloat("Speed", player.TargetVelocity.z);
		animator.SetFloat("AngularVelocity", player.AngularVelocity);

		if(Mathf.Abs(animator.GetFloat("Horizontal")) > 0.0f || Mathf.Abs(animator.GetFloat("Vertical")) > 0.0f){
			animator.SetBool("isMoving", true);
		}
		else{
			animator.SetBool("isMoving", false);
		}
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
