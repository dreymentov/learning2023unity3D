using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PlayerControlls : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject cameraHolder;
    public GameObject PlayerRotateHolder;
    public float speed;
    public float sensitivity;
    public float lookRotation;
    public float maxForce;
    public float jumpForce;
    public float powerKick;
    public bool grounded;
    public bool isMobile;
    public bool isMainMenuOrLobby;

    public Vector2 move;
    public Vector2 look;

    public Vector2 mobileMove;

    public PlayerDataUIValue PlayerDataUIValue;

    public FixedJoystick Joystick;

    public AudioSource audioSource;

    //public Vector3 velocityChange;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Jump();
    }

    // Start is called before the first frame update
    void Start()
    {
        Joystick = FindObjectOfType<FixedJoystick>();
        PlayerDataUIValue = FindObjectOfType<PlayerDataUIValue>();
        isMobile = PlayerDataUIValue.init.PlayerData.mobile;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(isMainMenuOrLobby == false)
        {
            if (isMobile == false)
            {
                Move();
            }
            else
            {
                MoveMobile();
            }
        } 
    }

    /*private void LateUpdate()
    {
        if (isMobile == false)
        {
            Look();
        }
        else
        {
            return;
        }
    }*/

    public void Move()
    {
        //Find target velocity
        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y);
        targetVelocity = targetVelocity * speed;

        if (move.y > -0.5f)
        {
            //cameraHolder.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            //PlayerRotateHolder.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            PlayerRotateHolder.transform.DORotate(new Vector3(0, transform.eulerAngles.y, 0), 0.5f);
        }
        else if (move.y < -0.8f)
        {
            //cameraHolder.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 180, 0);
            //PlayerRotateHolder.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 180, 0);
            PlayerRotateHolder.transform.DORotate(new Vector3(0, transform.eulerAngles.y - 180, 0), 0.5f);
        }

        if(move.x > 0)
        {
            PlayerRotateHolder.transform.DORotate(new Vector3(0, transform.eulerAngles.y + 90, 0), 0.5f);
        }
        else if(move.x < 0)
        {
            PlayerRotateHolder.transform.DORotate(new Vector3(0, transform.eulerAngles.y - 90, 0), 0.5f);
        }

        //cameraHolder.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        //Align direction
        targetVelocity = transform.TransformDirection(targetVelocity);

        //Calculate forces
        Vector3 velocityChange = (targetVelocity - currentVelocity);
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);

        //Limit force
        Vector3.ClampMagnitude(velocityChange, maxForce);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    public void MoveMobile()
    {
        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = new Vector3(Joystick.Horizontal, 0, Joystick.Vertical);
        //targetVelocity = targetVelocity * speed;

        if (isMobile == true)
        {

            if (Joystick.Vertical < -0.8f)
            {
                //cameraHolder.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 180, 0);
                //PlayerRotateHolder.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 180, 0);
                PlayerRotateHolder.transform.DORotate(new Vector3(0, transform.eulerAngles.y - 180, 0), 0.5f);
            }
            else if (Joystick.Vertical > -0.5f)
            {
                //cameraHolder.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                //PlayerRotateHolder.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                PlayerRotateHolder.transform.DORotate(new Vector3(0, transform.eulerAngles.y, 0), 0.5f);
            }

            if (Joystick.Horizontal > 0)
            {
                PlayerRotateHolder.transform.DORotate(new Vector3(0, transform.eulerAngles.y + 90, 0), 0.5f);
            }
            else if (Joystick.Horizontal < 0)
            {
                PlayerRotateHolder.transform.DORotate(new Vector3(0, transform.eulerAngles.y - 90, 0), 0.5f);
            }

            //cameraHolder.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

        targetVelocity = transform.TransformDirection(targetVelocity);

        Vector3 velocityChange = (targetVelocity - currentVelocity);
        velocityChange = new Vector3(velocityChange.x, 0, velocityChange.z);

        Vector3.ClampMagnitude(velocityChange, maxForce);

        rb.AddForce(velocityChange * speed, ForceMode.VelocityChange);
    }

    public void Look()
    {
        //Turn
        transform.Rotate(Vector3.up * look.x * sensitivity);

        //Look
        lookRotation = lookRotation + (-look.y * sensitivity);
        lookRotation = Mathf.Clamp(lookRotation, -90, 90);
        cameraHolder.transform.eulerAngles = new Vector3(lookRotation, cameraHolder.transform.eulerAngles.y, cameraHolder.transform.eulerAngles.z);
    }
    public void Jump()
    {
        audioSource.Play();

        Vector3 jumpForces = Vector3.zero;

        if (grounded)
        {
            jumpForces = Vector3.up * jumpForce;
        }

        rb.AddForce(jumpForces, ForceMode.VelocityChange);
    }

    public void SetGrounded(bool state)
    {
        grounded = state;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jump"))
        {
            SetGrounded(true);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Jump"))
        {
            SetGrounded(true);
        }
    }
}
