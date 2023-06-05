using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTrigger : MonoBehaviour
{
    // this is to access the Laser ON OR OFF script so that way
    // ontrigger enter and exit can activate them
    // so if the laser hit the blue beam then
    // the blue beam will turn off
    // but as soon as the laser exits the trigger then the
    // green beam will turn on

    public LaserON_OR_OFF LaserScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            LaserScript.BlueLaserOFF();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            LaserScript.GreenLaserON();
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
