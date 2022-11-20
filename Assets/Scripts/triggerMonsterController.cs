using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerMonsterController : MonoBehaviour
{
    public GameObject monstruo;


    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag == "Player")
        {
            monstruo.SetActive(true);
        }
        
    }
}
