using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 7f;
    public float jumpForce = 12f;

    float horizontal;
    bool isGrounded;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sprite;
    new AudioSource audio;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }

    void Update(){
        horizontal = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && isGrounded){
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            audio.Play();
        }
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    void LateUpdate(){
        sprite.flipX = rb.velocity.x < -0.1f;
        anim.SetFloat("SpeedX", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isJumping", !isGrounded);
    }

    void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.tag == "Ground") {
            isGrounded = false;
        }
    }


}
