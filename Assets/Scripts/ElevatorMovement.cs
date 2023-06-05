using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    // The game eobject is to reference the trigger collider
    // the public flot is to chnage the elevator speed in the editor
    // the private vector3 is to helpreste the elevator in case th eplayer jumps off it

    public GameObject ElevatorPlatform;
    public float ElevatorSpeed;
    private Vector3 respawn;

    // Start is called before the first frame update
    // Just remembering the last position of the elevator
    void Start()
    {
        respawn = ElevatorPlatform.transform.position;
    }

    // Ontriggerstay is abit different as long as the game object is in the 
    // collider then activtae this code below but as soon as i exit it then the code will 
    // stop so as long as the player is on the elevator base then the
    // elevator will go up
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ElevatorPlatform.transform.position += ElevatorSpeed * Time.deltaTime * Vector3.up;

        }
    }

    // As soon as the player exits the trigger then the elevators postion will reset
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ElevatorPlatform.transform.position = respawn;
            
        }
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
