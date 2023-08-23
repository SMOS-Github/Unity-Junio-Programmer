using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject restartMenu;
    private Rigidbody playerRb;
    private Animator animator;
    public AudioSource audioSource;

    public AudioClip jumpClip;
    public AudioClip crashClip;
    public ParticleSystem dirt;
    public ParticleSystem explosion;

    private float jumpForce=800f;
    public float gravityChanger=1.5f;


    public bool isOnGrounded=false;

    public bool gameOver = false;
    public bool dashing = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            restartMenu.gameObject.SetActive(true);
            explosion.Play();
            dirt.Stop();
            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 2);
            audioSource.PlayOneShot(crashClip,1f);
        }
        if(gameOver==true)
        {
            dirt.Stop();
        }
        
    }
    private void JumpAndMove()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&isOnGrounded==true&&!gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            animator.SetTrigger("Jump_trig");
            isOnGrounded=false;
            audioSource.PlayOneShot(jumpClip,1f);
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            dashing = true;
            animator.SetFloat("Speed_Multiplier", 1.5f);
        }
        else if(dashing)
        {
            dashing = false;
            animator.SetFloat("Speed_Multiplier", 1.0f);
        }
    }

   

}
