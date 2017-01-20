using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guis : MonoBehaviour
{
    int counter = 0;
    string text = "ABCD";
    bool toggle = false;

    void OnGUI()
    {
        /* 
         * Window Size: x = 688, y = 575
        */

        // Simple button with clicked return
        if (GUI.Button(new Rect(588, 525, 100, 50), "Clicked: " + counter))
            counter = counter + 1;

        // Simple label for ex. headlines
        GUI.Label(new Rect(0, 60, 150, 50), "Label");

        // Simple box without any text
        GUI.Box(new Rect(0, 120, 150, 50), "");

        // Simple box with text
        GUI.Box(new Rect(0, 180, 150, 50), "BoxText");

        // Text field (always needs a string to save the text)
        text = GUI.TextField(new Rect(0, 240, 150, 50), text);

        // Simple toggle box with text to de-/activate something
        toggle = GUI.Toggle(new Rect(0, 300, 150, 50), toggle, "Toggle Me");
    }
}
