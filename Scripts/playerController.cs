using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtyParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public float jummpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool isGameOver = false;
    public float speed = 5f;
    public float horizontalInput;
    private float xDownRange = 0.0f;
    private float xUpRange = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
       
        Physics.gravity *= gravityModifier;


    }

    // Update is called once per frame
    void Update()
    {
        MoveOnX();
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            playerAnim.SetTrigger("Jump_trig");
            playerRb.AddForce(Vector3.up * jummpForce, ForceMode.Impulse);
            dirtyParticle.Stop();
            isOnGround = false;
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }
    
    private void MoveOnX()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * speed);
        if (transform.position.x < xDownRange)
        {
            transform.position = new Vector3(xDownRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xUpRange)
        {
            transform.position = new Vector3(xUpRange, transform.position.y, transform.position.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtyParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            dirtyParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            isGameOver = true;
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
            explosionParticle.Play();
        }
    }
}
