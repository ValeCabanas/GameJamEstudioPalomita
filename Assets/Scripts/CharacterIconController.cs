using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterIconController : MonoBehaviour
{
    private Image myImage;
    void Start() {
        myImage = GetComponent<Image>();
    }
    void Update() {
        if(myImage.sprite == null) myImage.enabled = false;
        else myImage.enabled = true;
    }
}
