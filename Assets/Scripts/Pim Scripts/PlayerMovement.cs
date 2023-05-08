using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    [Header("crouching")]
    public float crouchSpeed;
    public float crouchHeight;
    private float regularHeight;

    public KeyCode crouchkey;

    [Header("movement")]
    public bool movementEnabled = true;
    [SerializeField]
    float movementSpeed;


    [Header("Jump")]
    public float jumpForce;
    [SerializeField]bool readyToJump = true;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]bool isGrounded = true;

    //Groundcheck

    [Header("sprint")]
    public float maxStamina;
    public float stamina;
    public float sprintSpeed;
    public float depletionRate; //per second
    public KeyCode sprintKey;






    private Vector3 direction;

    private Rigidbody rb;
    private float multiplier = 20;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        regularHeight = transform.localScale.y; // set normal walking height
        stamina = maxStamina;
    }

    private void Update()
    {
        if (!movementEnabled)
        {
            Debug.Log(rb.velocity.sqrMagnitude);
            rb.velocity = Vector3.zero;
        }
        if (movementEnabled)
        {
            GetInput();

            if (Input.GetButton("Jump") && isGrounded && readyToJump)
            {
                Jump();
            }
        }
    }
    private void FixedUpdate()
    {
        if (movementEnabled)
        {
            if (!Input.GetKey(sprintKey))
            {
                increaseStamina();
            }
            Move();
            GroundCheck();
        }

    }

    #region Movement Methods
    void Move()
    {
        if (Input.GetKey(crouchkey))
        {
            transform.Translate(direction * crouchSpeed / multiplier);
            rb.AddForce(direction * crouchSpeed * Time.deltaTime * multiplier);
            Debug.Log("Crouch Pressed");
        }
        else if (Input.GetKey(sprintKey)&& stamina > 0)
        {
            DepleteStamina();
            transform.Translate(direction * sprintSpeed / multiplier);
            rb.AddForce(direction * sprintSpeed * Time.deltaTime * multiplier);
        }
        else
        {
            transform.Translate(direction * movementSpeed / multiplier);
            rb.AddForce(direction * movementSpeed * Time.deltaTime * multiplier);
            Debug.Log("crouch not pressed");
        }
    }
    void GetInput()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if(Input.GetKeyDown(crouchkey)) 
        {
            //shrinking the player using transform.localscale so that the colliders and everything attached scales with it
            transform.localScale = new Vector3(transform.localScale.x, crouchHeight, transform.localScale.z);
            //downwards force so that the player does not float when you crouch
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }
        if (Input.GetKeyUp(crouchkey))
        {
            //transforming height back to normal
            transform.localScale = new Vector3(transform.localScale.x, regularHeight, transform.localScale.z);
        }
    }


    void DepleteStamina()
    {
        if(stamina != 0)
        {
            stamina -= depletionRate * Time.deltaTime;
        }
    }
    void increaseStamina()
    {
        if (stamina < maxStamina)
        {
            stamina += (depletionRate/3) * Time.deltaTime;
        }
    }

    #region jump
    void Jump()
    {
        readyToJump = false;
        rb.AddForce(direction.x, jumpForce * multiplier, direction.z);
        Invoke("ReadyToJump", 0.1f);
        Invoke("ReadyToJump", 0.05f);
    }
    void ReadyToJump()
    {
        readyToJump = true;
    }

    void GroundCheck()
    {
        Debug.DrawRay(transform.position, -transform.up, Color.green);
        if (Physics.Raycast(transform.position, -transform.up, 1.1f, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    #endregion jump

    #endregion Movement Methods

}