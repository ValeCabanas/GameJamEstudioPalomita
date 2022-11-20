using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterController : MonoBehaviour
{
    public float mVelocity = 3;

    private Rigidbody2D mrigidbody;
    public bool run;

    // Start is called before the first frame update
    void Start()
    {
        mrigidbody = GetComponent<Rigidbody2D>();
        mrigidbody.freezeRotation = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(run) mrigidbody.velocity = new Vector2(mVelocity, mrigidbody.velocity.y);
        else mrigidbody.velocity = new Vector2(0, 0);
    }
}
