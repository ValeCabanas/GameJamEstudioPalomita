using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{

    public float velocity = 2;
    public float fSalto = 0;

    private Rigidbody2D rbody;
    private bool toRight = true;
    private bool isJumping = false;
    private bool grounded = true;
    private Animator anim;
    private float jumpTimeCounter;
    public float jumpTime;

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
        if(Input.GetKeyDown(KeyCode.Space) && isJumping == true) {
            if(jumpTimeCounter > 0) {
                rbody.velocity = Vector2.up * fSalto;
                jumpTimeCounter -= Time.deltaTime;
                Debug.Log("Entre xd");
                Debug.Log("Jump Time Counter: " + jumpTimeCounter);
            }
            else {
                isJumping = false;
                Debug.Log("Sali xd");
            }
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            isJumping = false;
            Debug.Log("Sali por dejar de tocar tecla");
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
    }


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
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
                Debug.Log("Primer if");
            }
        }
        if(Input.GetKey(KeyCode.Space) && isJumping == true) {
            if(jumpTimeCounter > 0) {
                rbody.velocity = Vector2.up * fSalto;
                jumpTimeCounter -= Time.deltaTime;
                Debug.Log("Entre xd");
                Debug.Log("Jump Time Counter: " + jumpTimeCounter);
            }
            else {
                isJumping = false;
                Debug.Log("Sali xd");
            }
        }
        if(Input.GetKeyUp(KeyCode.Space)) {
            isJumping = false;
            Debug.Log("Sali por dejar de tocar tecla");
        }
        Debug.Log(jumpTimeCounter);
    }

    void FixedUpdate() {
        walking();
    }
}
