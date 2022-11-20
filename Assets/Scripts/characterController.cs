using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }

    void inGrab() {
        if(firstGrab) {
            if(lifeNum >= 1){
                lifeNum--;
            }
            else {
                Debug.Log("Game over");
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
                isGrabbed = false;
                firstGrab = false;
                lifeHolder.GetComponent<lifeSpawner>().destroy = true;
                monster.GetComponent<monsterController>().run = true;
                transform.position = new Vector2(transform.position.x + 5, transform.position.y);
                
            }
            else if(timeMashCounter <= 0) {
                Debug.Log("Game over");
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rbody.freezeRotation = true;
        firstGrab = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGrabbed){
            saltar();
        }
        else {
            inGrab();
        }
    }

    void FixedUpdate() {
        if(!isGrabbed){
            walking();
        }
    }
}
