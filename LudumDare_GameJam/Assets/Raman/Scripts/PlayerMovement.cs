using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]private float moveForce=10;
    [SerializeField] private float moveJump =7;
    private float movementX;
    private Rigidbody2D myBody;

    public PlayerInput playerInput { get; private set; }

    private Animator anim;
    private SpriteRenderer sr;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance = 0.25f;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private bool isGrounded =true;

    void Awake()
    {
        myBody=GetComponent<Rigidbody2D>();
        sr=GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    void Update()
    {
        GroundCheck();
        Playermovement() ;
        CheckDirection();
        HandleAnimation();
        
    }

    private void GroundCheck()
    {
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void HandleAnimation()
    {
        anim.SetFloat("inputX", Mathf.Abs(playerInput.xMove));
        anim.SetFloat("inputY", myBody.velocity.y);
        anim.SetBool("isGrounded",isGrounded);
    }

    void LateUpdate()
    {
        Playerjump();   
    }

    void Playermovement(){
        movementX = playerInput.xMove;
        transform.position += new Vector3(movementX,0f,0f)*Time.deltaTime*moveForce;
    }
    void CheckDirection (){
        if(movementX>0){
            //anim.SetFloat(input)
            sr.flipX=false;
        }
        else if (movementX<0){
            //anim.SetBool("Walk",true);
            sr.flipX=true;
        }
        else {
            //anim.SetBool("Walk",false);
        }
    }
   
    void Playerjump(){
        if(playerInput.jumpInput && isGrounded){
            isGrounded=false;
            playerInput.OnJump();
            //anim.SetBool("Jump",true);
            myBody.AddForce(new Vector2(0f,moveJump), ForceMode2D.Impulse);
        }
    }
}
