using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LaserTrigger : MonoBehaviour
{
    // Animations for turning the laser trap off and on again

    [SerializeField] private Animator LaserTriggerONAnim;
    
    [SerializeField] private string LaserHMoveON = "LaserBeamTrigger ON";
    

    // public object so that I can reference the laser itself so that way
    // I can turn it back or off from this script
    public GameObject Laser;

    // this is here so that other scripts besides this one can affect the laser
    public static bool TrapOn;
  

    // so as soo as the player touches the trap switch which cann't be avoid the laser will turn on
    // and the trap swithc will trun from red to green
    // I also set trapOn to true so that way other scripts can affect the laser
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            LaserTriggerONAnim.Play(LaserHMoveON,0,0.0f);
            Laser.SetActive(true);
            TrapOn = true;           
        }     
    }

    // Start is called before the first frame update
    void Start()
    {
        // I always want the laser truned off which is why it's ste to false as soon as the game starts
        TrapOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
