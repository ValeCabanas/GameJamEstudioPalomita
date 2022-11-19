using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

public class ScriptReader : MonoBehaviour
{
    [SerializeField]
    private TextAsset _InkJsonFile;
    private Story _StoryScript;

    public TMP_Text dialogueBox;
    public TMP_Text nameTag;

    public Image characterIcon;

    void Start()
    {
        LoadStory();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            DisplayNextLine();
        }
    }

    void LoadStory() {
        _StoryScript = new Story(_InkJsonFile.text);
        _StoryScript.BindExternalFunction("Name", (string charName) => ChangeName(charName));
        _StoryScript.BindExternalFunction("Icon", (string charIcon) => ChangeSprite(charIcon));
    }

    public void DisplayNextLine() {
        if(_StoryScript.canContinue) {
            string text = _StoryScript.Continue();
            text = text?.Trim();
            dialogueBox.text = text;
        }
        else{
            dialogueBox.text = "That's all folks";
        }
    }

    public void ChangeName(string name) {
        string SpeakerName = name;
        nameTag.text = SpeakerName;
    }

    public void ChangeSprite(string icon) {
        var charIcon = Resources.Load<Sprite>("CharacterSprites/" + icon);
        characterIcon.sprite = charIcon;
    }
}
