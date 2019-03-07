using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{


    [HideInInspector]
    public string leftAnalogX;
    [HideInInspector]
    public string leftAnalogY;
    [HideInInspector]
    public string aButton;
    [HideInInspector]
    public string bButton;
    [HideInInspector]
    public string yButton;
    [HideInInspector]
    public string xButton;
    [HideInInspector]
    public string rbButton;
    [HideInInspector]
    public string lbButton;
    [HideInInspector]
    public string startButton;



    void Start()
    {

        //Player 1 controls
        if (gameObject.name == "Player1")
        {
            leftAnalogX = "LeftAnalogX1";
            leftAnalogY = "LeftAnalogY1";
            xButton = "X1";
            yButton = "Y1";
            aButton = "A1";
            bButton = "B1";
            lbButton = "LB1";
            rbButton = "RB1";
            startButton = "Start1";

        }

        //Player 2 controls
        if (gameObject.name == "Player2")
        {
            leftAnalogX = "LeftAnalogX2";
            leftAnalogY = "LeftAnalogY2";
            xButton = "X2";
            yButton = "Y2";
            aButton = "A2";
            bButton = "B2";
            lbButton = "LB2";
            rbButton = "RB2";
            startButton = "Start2";
        }


    }
}
