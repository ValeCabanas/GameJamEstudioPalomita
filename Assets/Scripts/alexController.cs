using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alexController : MonoBehaviour
{

    public GameObject alexDeathUI;
    public GameObject alexTutorialMove;
    public GameObject alexTutorialMonsters;

    public GameObject monique;
    private bool dying = false;
    private bool die = false;

    private int tutorial = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "AlexKiller")
        {

            
            Time.timeScale = 0f;
            alexDeathUI.SetActive(true);
            tutorial = 3;
            
        }

        if(other.gameObject.tag == "Monster Trigger")
        {
            Time.timeScale = 0f;
            alexTutorialMonsters.SetActive(true);
            tutorial = 2;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        alexTutorialMove.SetActive(true);
        tutorial = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (dying) transform.position = new Vector2(transform.position.x, transform.position.y - 6f * Time.deltaTime);
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;

            if (die)
            {
                
            }

            switch (tutorial)
            {
                case 1:
                    alexTutorialMove.SetActive(false);
                    break;
                case 2:
                    alexTutorialMonsters.SetActive(false);
                    break;
                case 3:
                    alexDeathUI.SetActive(false);
                    dying = true;
                    transform.position = new Vector2(transform.position.x + 2, transform.position.y);
                    break;
            }

        }
        else
        {
            transform.position = new Vector3(monique.transform.position.x + 2, monique.transform.position.y + 2, monique.transform.position.z);
        }
        
    }
}
