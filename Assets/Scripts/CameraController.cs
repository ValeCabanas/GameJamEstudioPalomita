using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {

        Vector3 np = new Vector3(player.transform.position.x + 5, player.transform.position.y + 1,-10);

        if (player.transform.position.x < 11.110) np.x = 11.110f;
        if (player.transform.position.x + 0.5f > 150f) np.x = 154f;

        if (player.transform.position.y < 0) np.y = 1.10f;
        if (player.transform.position.y > 36) np.y = 36f;

        transform.position = np;

        //Debug.Log(transform.position);
    }
}
