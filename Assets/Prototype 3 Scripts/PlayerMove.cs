using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator animator;
    public AudioSource audioSource;
    public AudioClip jumpClip;
    public AudioClip crashClip;
    public ParticleSystem dirt;
    public ParticleSystem explosion;

    private float jumpForce=500.0f;
    private float doubbleJumpForce=250.0f;
    private float gravityChanger=1.5f;
    public bool isOnGrounded;
    public bool doubbleJump = false;
    public bool gameOver = false;
    public bool dashing = false;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityChanger;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        JumpAndMove();
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGrounded = true;
        dirt.Play();

        if (collision.gameObject.CompareTag("Obstacles"))
        {
            gameOver = true;
            explosion.Play();
            dirt.Stop();
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 2);
            audioSource.PlayOneShot(crashClip);
        }
        if(gameOver==true)
        {
            dirt.Stop();
        }

    }
    private void JumpAndMove()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isOnGrounded == true && gameOver == false)
        {
            dirt.Stop();
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGrounded = false;
            doubbleJump = false;
            animator.SetTrigger("Jump_trig");
            audioSource.PlayOneShot(jumpClip);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && !doubbleJump && !isOnGrounded)
        {
            doubbleJump = true;
            playerRb.AddForce(Vector3.up * doubbleJumpForce, ForceMode.Impulse);
            animator.Play("Running_Jump", 3, 0f);
            audioSource.PlayOneShot(jumpClip, 1f);
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            dashing = true;
            animator.SetFloat("Speed_Multiplier", 2.0f);
        }
        else if(dashing)
        {
            dashing = false;
            animator.SetFloat("Speed_Multiplier", 1.0f);
        }
    }

}
