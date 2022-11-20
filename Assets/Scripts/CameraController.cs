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

        if (player.transform.position.x < 3.38) np.x = 3.4f;
        if (player.transform.position.x > 162.3+5) np.x = 162f;

        if (player.transform.position.y < -3) np.y = -2f;
        if (player.transform.position.y > 36) np.y = 36f;

        transform.position = np;

        //Debug.Log(transform.position);
    }
}
