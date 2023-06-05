using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // I created 2 private variables for the animator component one for the door and other one for the switch 
    [SerializeField] private Animator animswitchO, animdoorO;
    
    // I then created 2 variable strings and referenced them with the actual animation names
    [SerializeField] private string DoorO = "Prison Door Opening";
    [SerializeField] private string DoorSwitchO = "Door Switch Open Door";
 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // I then set the animations to only activate as soon as the player or laser projectile entered
    // the trigger area

    // note that the numbers to side mean which layer the aniamtion should be played and if the aniamtion should be delayed before it's played
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")|| other.CompareTag("Laser"))
        {
            animswitchO.Play(DoorSwitchO, 0, 0.0f);
            animdoorO.Play(DoorO, 0, 0.1f);
            GetComponent<BoxCollider2D>().enabled = false;// this is to make sure the player can't keep opening the door
        }
    }




}
