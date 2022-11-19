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

    void walking()
    {
        float inputMovement = Input.GetAxis("Horizontal");
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
            if (grounded && !isJumping)
            {
                isJumping = true;
                anim.SetBool("isJumping", true);
                rbody.AddForce(Vector2.up * fSalto, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            grounded = true;
            isJumping = false;
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
        walking();
        saltar();
    }
}
