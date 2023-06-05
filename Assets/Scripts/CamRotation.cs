using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CamRotation : MonoBehaviour
{
    
    public float rotatespeed;// the rotation speed for the security camera
    public int maxangle, minangle; // the angles used between rotations so that way i can control the max and minimum angle
    float timer = 0;// This let's me control the time.delta time directly
    bool timeractive = true; // a bool variable to help disable the rotation for the cam later on
    public BoxCollider2D BeamLight; // this let's me access the game objects polygon collider
    public SpriteRenderer Beam; // this let's me acces the game objects spriterenderer
    

    [SerializeField] Animator animbeamOFF, animbeamON;
    [SerializeField] private string beam_is_off = "LaserBeamOFF";
    [SerializeField] private string beam_is_on = "LaserBeamON";


  
    // Update is called once per frame
    void Update()
    {
        // as long as the timeractice is true then the time will go up after frame

        if (timeractive)
        {
            timer += Time.deltaTime;           
        }

        // with the frame going up every second this code will keep running bouncing back and forth between the Z axis

        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(timer * rotatespeed, maxangle) - minangle);
     
    }

  
    private void OnTriggerEnter2D(Collider2D collider)
    //this trigger let's the laser disable the security cam and turn off another game objects spriterenderer and collider
    {
        if (collider.CompareTag("Laser") && timeractive == true)
        {
            timeractive = false;
            BeamLight.GetComponent<BoxCollider2D>().enabled = false;
            Beam.GetComponent<SpriteRenderer>().enabled = false;
            animbeamOFF.Play(beam_is_off, 0, 0.0f);
            
        }       
    }

    private void OnTriggerExit2D(Collider2D collider)
        // as soon as the laser exits the trigger then the resume coroutine will activate
    {
        if (collider.CompareTag("Laser") && timeractive == false)
        {
            StartCoroutine(resume());
        }
        
    }


    IEnumerator resume()
        // this coroutine will restart the security cam as soon as the timeractive is set to false
        // then aftter 4 second everything is set to true again.

    {
        if(timeractive == false)
        {
            yield return new WaitForSeconds(4);
            timeractive = true;
            BeamLight.GetComponent<BoxCollider2D>().enabled = true;
            Beam.GetComponent<SpriteRenderer>().enabled = true;
            animbeamON.Play(beam_is_on, 0, 0.0f);
            
        }

    }

    
   

}
