﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTouch : MonoBehaviour {

	public Text Text1;
    public Text Text2;
    public Text Text3;


	void Start() {
	}

    void Update()
    {

        //Commented out for testing, these lines of code are buggy on play mode testing
        


        //Update the Text on the screen depending on current position of the touch each frame
         Text1.text = "Tilt: " + Input.acceleration;
         Text2.text = "H" + GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().horizontalInput;
         Text3.text = "V" +  GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().verticalInput;
        // m_Text2.text = "Magnitude: " + GameObject.FindWithTag("Player").
        // 				GetComponent<PlayerMovement>().magnitude.ToString();
        //m_Text1.text = "Tilt: " + Input.acceleration;
        //m_Text2.text = "Magnitude: " + GameObject.FindWithTag("Player").
        	//			GetComponent<PlayerMovement>().magnitude.ToString();
    }
}
