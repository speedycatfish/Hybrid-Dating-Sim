using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextBox : MonoBehaviour {
    string[] text = new string[5];
    Text textComponent;
    bool newText = false;
    int index = 0;
    float timeBetweenCharacters = 0.05f;
    float lastTime;
    int stringIndex = 0;
    void Start () {
        textComponent = gameObject.GetComponent<Text>();
        text[0] = "sample text sample text sample text sample text sample text sample text ";
        text[1] = "2 sample text";
        ScrollText();
	}
	
	void Update () {
		if(newText == true && Time.time-lastTime >= timeBetweenCharacters)
        {
            if(stringIndex > text[index].Length)
            {
                newText = false;
                index++;
            }
            else
            {
                textComponent.text = text[index].Substring(0, stringIndex);
                stringIndex++;
                lastTime = Time.time;
            }
        }
	}
    void ScrollText()
    {
        lastTime = Time.time;
        newText = true;
    }
}
