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
   // public GameObject startText;
   // public GameObject gameOverText;

    public float jummpForce;
    public float gravityModifier;

    public bool isOnGround = true;
    public bool isGameOver = false;
    public bool doubleJump = false;
    private bool startedRunning = false;
    public bool planeAirCrash = false;

    public float horizontalInput;
    Vector3 normal_EulerAngle = new Vector3(0, 90, 0);
    Vector3 normal_Position = new Vector3(0, 0, 0);
    private float start_speed = 2;
    private float maxHight = 9f;
    public float time_of_running = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        jummpForce = 22;
        gravityModifier = -18.0f;
        Physics.gravity = new Vector3(0, gravityModifier, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        MaxHight();
        if (startedRunning == false)
        {
            dirtyParticle.Stop();
          //  playerAnim.SetFloat("Speed_f", 0.3f);
            transform.Translate(Vector3.forward * Time.deltaTime * start_speed);
            if (transform.position.x >= 0)
            {
                startedRunning = true;
                dirtyParticle.Play();
                
                transform.eulerAngles = normal_EulerAngle;
                transform.position = normal_Position;
            }
        }
        else
        {
            //MoveOnX();
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !doubleJump && !isGameOver)
            {
                playerAnim.SetTrigger("Jump_trig");
                playerRb.AddForce(Vector3.up * jummpForce, ForceMode.Impulse);
                dirtyParticle.Stop();
                isOnGround = false;
                playerAudio.PlayOneShot(jumpSound, 1.0f);

            }
            else if (Input.GetKeyDown(KeyCode.Space) && isOnGround == false && !doubleJump && !isGameOver)
            {
                playerAnim.SetTrigger("Jump_trig");
                playerRb.AddForce(Vector3.up * jummpForce / 2, ForceMode.Impulse);
                isOnGround = false;
                doubleJump = true;
                dirtyParticle.Stop();
                playerAudio.PlayOneShot(jumpSound, 1.0f);

            }
            if (!isGameOver)
            {
                transform.eulerAngles = normal_EulerAngle;
                transform.position = new Vector3(0, transform.position.y, 0);
            }
        }
    }
    
    public void Timer()
    {
        time_of_running = time_of_running + 1 * Time.deltaTime;
    }
    
    private void MaxHight()
    {
        if(transform.position.y > maxHight)
        {
            transform.position = new Vector3(transform.position.x, maxHight, transform.position.z);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            doubleJump = false;
            dirtyParticle.Play();
           // transform.position = new Vector3(0, 0, 0);
        }
        else if (collision.gameObject.CompareTag("Obstacle")|| collision.gameObject.CompareTag("plane"))
        {
            //Debug.Log("Game Over");
            dirtyParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            isGameOver = true;
           
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int",1);
            explosionParticle.Play();
           if (collision.gameObject.CompareTag("plane"))
            {
                planeAirCrash = true;
            }
          
        }
        
    }


}
