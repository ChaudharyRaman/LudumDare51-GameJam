using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed = 10f;
    public int facingDir = 1;
    [SerializeField] private Transform forwardCheck;


    //private SpriteRenderer sr;
    private Animator anim;
    private Rigidbody2D rbody;


    RaycastHit2D hit ;
    public float collisionCheckDistance = 0.2f;

    void Start(){
        //sr=GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();
        rbody=GetComponent<Rigidbody2D>();
        anim.SetBool("isMoving", true);
    }

    void Update()
    {
        //HandleForwardCollision();
        HandleMovement();
        HandleAnimation();
        //if(gameObject!=null){
        //    if(transform.position.y<-5){
        //        Destroy(gameObject);
                
        //    }
        //    RaycastHit2D hit=Physics2D.Raycast(transform.position,new Vector2(XMoveDirection,0));
        //    rbody.velocity=new Vector2(XMoveDirection,0)*EnemySpeed;

        //    if(hit.collider!=null && hit.distance<1){
        //        if(hit.collider.tag=="Player"){
        //            // Destroy(hit.collider.gameObject);
        //            // FindObjectOfType<SoundManager>().Play("Die");
        //            Debug.Log("Player Collided");
        //        }
        //        Flip ();
        //    }
        //}
        
    }

    private void HandleAnimation()
    {
        
    }

    private void HandleMovement()
    {
        rbody.MovePosition(rbody.position + Vector2.right * facingDir * enemySpeed * Time.deltaTime);
    }

    private void HandleForwardCollision()
    {
        Debug.Log(forwardCheck.name);
        Debug.DrawRay(transform.position, transform.right, Color.red);
        //hit = Physics2D.Raycast(forwardCheck.position,forwardCheck.forward , 1f);
        
        Debug.Log(hit.collider.name);
        if (hit.collider != null)
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("PlayerCollided");
        }
        else
        {
            Flip();
        }

    }
    void Flip(){
        //if(facingDir>0){
        //    facingDir=-1;
        //    sr.flipX=true;
        //}
        //else{
        //    facingDir=1;
        //    sr.flipX=false;
        //} 
        facingDir *= -1;
        transform.Rotate(0, 180f, 0);
    }

}
