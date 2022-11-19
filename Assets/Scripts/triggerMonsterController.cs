using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerMonsterController : MonoBehaviour
{
    public GameObject monstruo;


    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("Aaaaaaaaaa");

        if(other.gameObject.tag == "Player")
        {
            monstruo.SetActive(true);
            Debug.Log("Me activo pa");
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
