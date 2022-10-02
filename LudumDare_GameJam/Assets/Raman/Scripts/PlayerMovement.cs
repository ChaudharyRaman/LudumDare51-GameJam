using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveForce=10;
    [SerializeField]public float moveJump =7;
    private float movementX;
    private Rigidbody2D myBody;

    public PlayerInput playerInput { get; private set; }

    private Animator anim;
    private SpriteRenderer sr;
    private bool isGrounded =true;
    void Awake()
    {
        myBody=GetComponent<Rigidbody2D>();
        sr=GetComponent<SpriteRenderer>();
        //anim=GetComponent<Animator>();    
    }
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    void Update()
    {
        Playermovement() ;
        AnimatePlayer();
        HandleAnimation();
    }

    private void HandleAnimation()
    {
        anim.SetFloat("inputX", movementX);
        anim.SetFloat("inputY", myBody.velocity.y);
    }

    void LateUpdate()
    {
        Playerjump();   
    }

    void Playermovement(){
        movementX = playerInput.xMove;
        transform.position += new Vector3(movementX,0f,0f)*Time.deltaTime*moveForce;
    }
    void AnimatePlayer (){
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
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground") ){
            isGrounded=true;
            //anim.SetBool("Jump",false);
        } 
    }
    
}
