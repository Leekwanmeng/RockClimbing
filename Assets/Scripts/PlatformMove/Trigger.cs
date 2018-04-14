﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {


    public int triggerNumber;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(triggerNumber == 1)
            {
                GameObject.Find("FirstPlatform").GetComponent<PlatformController>().triggered = true;
            }
            else if(triggerNumber == 2)
            {
                GameObject.Find("PlatformWithTrigger").GetComponent<PlatformController>().triggered = true;
            }
            else if(triggerNumber == 3)
            {
                GameObject.Find("FinalMovingPlatform").GetComponent<PlatformController>().triggered = true;
            }
            else if(triggerNumber == 4)
            {
                GameObject.Find("RoomOpenerMovingPlatform").GetComponent<PlatformController>().triggered = true;
            }
            else if(triggerNumber == 5)
            {
                //game win

            }



            
            

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            GameObject.Find("Moving Platform").GetComponent<PlatformController>().triggered = false;

        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
    }



}
