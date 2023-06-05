using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserON_OR_OFF : MonoBehaviour
{
    // this public gameobject is creating 2 arrways one fro all the blue beams
    // and the other for all the green beams that way i can add as maany as I like
    public GameObject[] Total_Green_Lasers,Total_Blue_Laser;

    // Start is called before the first frame update
    void Start()
    {
        // so as soon as the game starts I want those arrays to look for the
        // green and blue laser tags that wya only those gameobjects will
        // be affected
        Total_Green_Lasers = GameObject.FindGameObjectsWithTag("Green Laser");
        Total_Blue_Laser = GameObject.FindGameObjectsWithTag("Blue Laser");

        // this is to make sure that as soon as the game starts the green lasers
        // will be truned off
        GreenLaserOFF();

    }

    // the 4 public voids are to help disbale and enable the blue and green lasers
    // so i create 4 new gameobjects then ste in IN the 2 lasergame objects I made
    // above that way can control all of them at once

    public void GreenLaserON()
    {

        foreach(GameObject greenon in Total_Green_Lasers)
        {
            greenon.SetActive(true);
        }
    }

    public void GreenLaserOFF()
    {

        foreach (GameObject greenoff in Total_Green_Lasers)
        {
            greenoff.SetActive(false);
        }
    }


    public void BlueLaserON()
    {

        foreach (GameObject blueon in Total_Blue_Laser)
        {
            blueon.SetActive(true);
        }
    }

    public void BlueLaserOFF()
    {

        foreach (GameObject blueoff in Total_Blue_Laser)
        {
            blueoff.SetActive(false);
        }
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
