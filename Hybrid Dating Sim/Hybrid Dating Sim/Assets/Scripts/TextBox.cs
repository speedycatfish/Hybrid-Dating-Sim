using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextBox : MonoBehaviour
{
    string[] text = new string[5]; //array of text that people say
    Text textComponent; //text component in text box
    bool scrollingText = false; //is the text currently scrolling
    bool displayText = false; //should text be displayed right now
    int index = 0; //text array index
    public float timeBetweenCharacters = 0.05f; //the time in seconds between letters being displayed.
    float lastTime; //last time a new letter was displayed
    int stringLength = 0; //length displayed of current text being displayed
    void Start()
    {
        textComponent = gameObject.GetComponent<Text>();
        text[0] = "sample text sample text sample text  ";
        text[1] = "2 sample text sample text sample text ";
        text[2] = "3rd text sample text sample text ";
        text[3] = "4th string sample text sample text ";
        text[4] = "5 lorem ipsum sample text sample text ";
        ScrollText();
    }

    void Update()
    {
        if (displayText == true)
        {
            if (scrollingText == true && Time.time - lastTime >= timeBetweenCharacters)
            {
                if (stringLength > text[index].Length)
                {
                    scrollingText = false;
                    index++;
                }
                else
                {
                    textComponent.text = text[index].Substring(0, stringLength);
                    stringLength++;
                    lastTime = Time.time;
                }
            }
            if (Input.GetButtonDown("NextText"))
            {
                if (scrollingText == true)
                {
                    textComponent.text = text[index];
                    scrollingText = false;
                    index++;
                }
                else
                {
                    ScrollText();
                }
            }
        }
    }
    void ScrollText()
    {
        displayText = true;
        lastTime = Time.time;
        scrollingText = true;
        stringLength = 0;
    }
}
