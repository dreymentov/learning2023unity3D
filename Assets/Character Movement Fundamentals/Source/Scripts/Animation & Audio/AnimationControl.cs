using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

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

		public bool isMoving;

		//Setup;
		void Awake () {
			playerControll = GetComponent<PlayerControlls>();
			animator = GetComponentInChildren<Animator>();
			animatorTransform = animator.transform;

			//tr = transform;
		}

		//Update;
		void Update () {
			//animator.SetFloat("VerticalSpeed", playerControll.velocityChange.z);
			//animator.SetFloat("HorizontalSpeed", playerControll.velocityChange.x);
			/*if(playerControll.isMobile == false)
            {
				animator.SetFloat("ForwardSpeed", playerControll.speed * playerControll.move.y);
				animator.SetFloat("StrafeSpeed", playerControll.speed * playerControll.move.x);
			}
            else
            {
				animator.SetFloat("ForwardSpeed", playerControll.speed * playerControll.Joystick.Vertical);
				animator.SetFloat("StrafeSpeed", playerControll.speed * playerControll.Joystick.Horizontal);
			}*/

			if(playerControll.isMobile == false)
            {
				if ((playerControll.move.x != 0) || (playerControll.move.y != 0))
				{
					isMoving = true;
				}
                else
                {
					isMoving = false;
                }
				animator.SetBool("IsMoving", isMoving);
			}
            else
            {
				if ((playerControll.Joystick.Horizontal != 0) || (playerControll.speed * playerControll.Joystick.Vertical != 0))
				{
					isMoving = true;
				}
				else
				{
					isMoving = false;
				}
				animator.SetBool("IsMoving", isMoving);
			}

			if(playerControll.isMainMenuOrLobby == true)
			{
                animator.SetBool("IsMainOrLobby", true);
            }


			animator.SetBool("IsGrounded", playerControll.grounded);
			//animator.SetBool("IsStrafing", );
		}
	}
}
