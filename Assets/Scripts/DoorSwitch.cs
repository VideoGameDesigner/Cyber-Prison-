using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public GameObject door; // I need this gameobject so that i can access the door game object
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
        //this collision let's the player open the door by simply walking on the switch itself
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            door.SetActive(false);
        }
        

    }


    private void OnCollisionEnter2D(Collision2D collision)
        // this collision method is for the laser because it's not a trigger
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            door.SetActive(false);
        }
    }
}
