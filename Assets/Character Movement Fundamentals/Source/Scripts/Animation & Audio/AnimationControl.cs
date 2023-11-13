using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMF
{
	//This script controls the character's animation by passing velocity values and other information ('isGrounded') to an animator component;
	public class AnimationControl : MonoBehaviour {

		public PlayerControlls playerControll;
		public Animator animator;
		public Transform animatorTransform;
		public Transform tr;

		//Whether the character is using the strafing blend tree;
		public bool useStrafeAnimations = false;

		//Velocity threshold for landing animation;
		//Animation will only be triggered if downward velocity exceeds this threshold;
		public float landVelocityThreshold = 5f;

		private float smoothingFactor = 40f;
		Vector3 oldMovementVelocity = Vector3.zero;

		//Setup;
		void Awake () {
			playerControll = GetComponent<PlayerControlls>();
			animator = GetComponentInChildren<Animator>();
			animatorTransform = animator.transform;

			tr = transform;
		}

		//Update;
		void Update () {
			//animator.SetFloat("VerticalSpeed", playerControll.velocityChange.z);
			//animator.SetFloat("HorizontalSpeed", playerControll.velocityChange.x);
			animator.SetFloat("ForwardSpeed", playerControll.speed * playerControll.move.y);
			animator.SetFloat("StrafeSpeed", playerControll.speed * playerControll.move.x);
			animator.SetBool("IsGrounded", playerControll.grounded);
			//animator.SetBool("IsStrafing", );
		}
	}
}
