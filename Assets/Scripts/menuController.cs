using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuController : MonoBehaviour
{

    public GameObject startButton;

    public void startNewGame()
    {
        SceneManager.LoadScene("Noche1");
    }
}
