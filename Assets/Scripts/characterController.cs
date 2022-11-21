using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class characterController : MonoBehaviour
{

    public float velocity = 2;
    public float fSalto = 0;

    private Rigidbody2D rbody;
    private bool toRight = true;
    private bool isJumping = false;
    private bool grounded = true;
    private bool isGrabbed = false;
    private Animator anim;
    private float jumpTimeCounter;
    public float jumpTime;
    private float mashCounter;
    public float mash;
    public float timeMash;
    private float timeMashCounter;
    private bool firstGrab;
    public float lifeNum;
    public GameObject monster;

    public GameObject pauseUI;

    public GameObject cameraGUI;
    private Animator cameraGUIanimator;

    public GameObject introductionUI;
    public GameObject alex;

    public GameObject finalUI;

    public Animator transitionsAnimator;

    private bool onIntro;
    private bool onEnding;

    public GameObject flash;

    [SerializeField]
    private GridLayoutGroup lifeHolder;

    void walking()
    {
        float inputMovement = Input.GetAxisRaw("Horizontal");
        if (inputMovement != 0) anim.SetBool("isRunning", true);
        else anim.SetBool("isRunning", false);
        rbody.velocity = new Vector2(inputMovement*velocity, rbody.velocity.y);
        manageOrientation(inputMovement);
    }

    void manageOrientation(float inputMovement)
    {
        if ((toRight && inputMovement < 0)||(!toRight && inputMovement > 0)) 
        {
            toRight = !toRight;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

   
    void saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded)
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                grounded = false;
                anim.SetBool("isJumping", true);
                rbody.velocity = Vector2.up * fSalto;
            }
        }
        if(Input.GetKey(KeyCode.Space) && isJumping == true) {
            if(jumpTimeCounter > 0) {
                rbody.velocity = Vector2.up * fSalto;
                jumpTimeCounter -= Time.deltaTime;
            }
            else {
                isJumping = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            grounded = true;
            //isJumping = false;
            anim.SetBool("isJumping", false);
        }
        if(collision.gameObject.tag == "Enemy") {
            isGrabbed = true;
            firstGrab = true;
            monster.GetComponent<monsterController>().run = false;
        }

        if(collision.gameObject.tag == "Dientes")
        {
            Debug.Log("Game over");
        }

        if(collision.gameObject.tag == "END")
        {
            //GetComponent<AudioSource>().Stop();
            finalUI.SetActive(true);
            onEnding = true;

        }
    }

    void inGrab() {
        if(firstGrab) {
            cameraGUIanimator.SetBool("isMashed", true);
            if (lifeNum >= 1){
                lifeNum--;
            }
            else {
                // Muerte falta de vidas
                Debug.Log("Game over");
                cameraGUIanimator.SetBool("isMashed", false);
            }
            
            mashCounter = 0;
            timeMashCounter = timeMash;
            firstGrab = false;
        }
        else {
            timeMashCounter -= Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Space)) {
                mashCounter++;
            }
            if(mashCounter >= mash && timeMashCounter > 0) {
                // Te libraste
                cameraGUIanimator.SetBool("isMashed", false);
                flash.SetActive(true);
                flash.GetComponent<flashController>().doCameraFlash = true;
                isGrabbed = false;
                firstGrab = false;
                lifeHolder.GetComponent<lifeSpawner>().destroy = true;
                monster.GetComponent<monsterController>().run = true;
                transform.position = new Vector2(transform.position.x + 5, transform.position.y);

                
            }
            else if(timeMashCounter <= 0) {
                cameraGUIanimator.SetBool("isMashed", false);
                // Muerte a causa de que no le sabe mashear
                Debug.Log("Game over");
            }
        }
    }


    public void pauseGame() 
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;

        pauseUI.SetActive(true);
    }

    public void resumeGame()
    {
        pauseUI.SetActive(false);

        Time.timeScale = 1;
        AudioListener.pause = false;
        
    }

    void checkIfPaused()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) pauseGame();
    }

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rbody.freezeRotation = true;
        firstGrab = false;

        cameraGUIanimator = cameraGUI.GetComponent<Animator>();

        transitionsAnimator.SetTrigger("FadeIn");

        //Time.timeScale = 0f;
        introductionUI.SetActive(true);
        onIntro = true;
        

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!onIntro)
        {
            checkIfPaused();

            if (!isGrabbed)
            {
                saltar();
            }
            else
            {
                inGrab();
            }
        }
        if (onEnding)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ////////////////////////////////////////////
                transitionsAnimator.SetTrigger("FadeOut");
                //SceneManager.LoadScene("Main Menu");
            }
        }
        if(onIntro)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1f;
                introductionUI.SetActive(false);
                GetComponent<AudioSource>().Play();
                onIntro = false;
                alex.SetActive(true);
            }
        }
        
    }

    void FixedUpdate() {
        if(!isGrabbed){
            walking();
        }
    }
}
