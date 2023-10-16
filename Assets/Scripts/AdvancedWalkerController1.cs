using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CMF
{
	//Advanced walker controller script;
	//This controller is used as a basis for other controller types ('SidescrollerController');
	//Custom movement input can be implemented by creating a new script that inherits 'AdvancedWalkerController' and overriding the 'CalculateMovementDirection' function;
	public class AdvancedWalkerController1 : Controller
	{

		//References to attached components;
		protected Transform tr;

		//Jump key variables;
		bool jumpInputIsLocked = false;
		bool jumpKeyWasPressed = false;
		bool jumpKeyWasLetGo = false;
		bool jumpKeyIsPressed = false;


		public Rigidbody rb;
		//Movement speed;
		public float movementSpeed = 7f;
		public float movementSpeedAtRotate = 1f;
		public float movementSpeedAfterRotate = 7f;

		//How fast the controller can change direction while in the air;
		//Higher values result in more air control;
		public float airControlRate = 2f;

		//Jump speed;
		public float jumpSpeed = 10f;

		//Jump duration variables;
		public float jumpDuration = 0.2f;
		float currentJumpStartTime = 0f;

		//'AirFriction' determines how fast the controller loses its momentum while in the air;
		//'GroundFriction' is used instead, if the controller is grounded;
		public float airFriction = 0.5f;
		public float groundFriction = 100f;

		//rotate player speed;
		public float speedRotate;

		//Current momentum;
		protected Vector3 momentum = Vector3.zero;

		//Saved velocity from last frame;
		Vector3 savedVelocity = Vector3.zero;

		//Saved horizontal movement velocity from last frame;
		Vector3 savedMovementVelocity = Vector3.zero;

		//Amount of downward gravity;
		public float gravity = 30f;
		[Tooltip("How fast the character will slide down steep slopes.")]
		public float slideGravity = 5f;

		//Acceptable slope angle limit;
		public float slopeLimit = 80f;

		[Tooltip("Whether to calculate and apply momentum relative to the controller's transform.")]
		public bool useLocalMomentum = false;

		[Tooltip("Optional camera transform used for calculating movement direction. If assigned, character movement will take camera view into account.")]
		public Transform cameraTransform;

		//Get references to all necessary components;
		void Awake()
		{
			tr = transform;

			Setup();
		}

		//This function is called right after Awake(); It can be overridden by inheriting scripts;
		protected virtual void Setup()
		{

		}

		void Update()
		{

		}

		//Handle jump booleans for later use in FixedUpdate;


		void FixedUpdate()
		{
			rb.rotation = Quaternion.Euler(0, rb.transform.rotation.eulerAngles.y + (Input.GetAxis("Horizontal1") * speedRotate * Time.fixedDeltaTime), 0);

		}

        public override Vector3 GetVelocity()
        {
			return Vector3.zero;
        }

        public override Vector3 GetMovementVelocity()
        {
			return Vector3.zero;
		}

        public override bool IsGrounded()
        {
			return false;
		}
    }
}
