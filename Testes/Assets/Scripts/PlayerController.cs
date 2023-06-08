using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
   // private Animation playeranimation;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public float jumpForce = 10;
    public float gravityModifier;
    public bool doubleJumpUsed = false;
    public float doubleJumpForce;
    public bool doubleSpeed = false;
    public bool isOnGround = true;
    public bool gameOver = false;

    //private float playerAnimSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        //playeranimation = GetComponent<Animation>();
        playerAnim.SetFloat("Speed_Mult", 1.0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);

            doubleJumpUsed = false;

            //FallingAnimation();
        } 
        else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && !gameOver && !doubleJumpUsed)
        {
            doubleJumpUsed = true;

            playerRb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);

            //FallingAnimation();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            doubleSpeed = true;
            playerAnim.SetFloat("Speed_Mult", 2.0f);
        }
        else if (doubleSpeed)
        {
            doubleSpeed = false;
            playerAnim.SetFloat("Speed_Mult", 1.0f);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerAnim.ResetTrigger("Jump_trig");
            dirtParticle.Play();
            //playerAnim.SetBool("Grounded", true);
        }
        else if (collision.gameObject.CompareTag("Obstacle")) 
        {
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            gameOver = true;
        }
    }

    /*
    private void FallingAnimation()
    {
        if (playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !playerAnim.IsInTransition(0) && !isOnGround)
        {
            playerAnim.SetBool("Grounded", false);
        }
        else
        {
            playerAnim.SetBool("Grounded", true);
        }
    }
    */
}


