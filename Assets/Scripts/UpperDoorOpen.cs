using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperDoorOpen : MonoBehaviour
{
    // the upper door opening then closing by using a single frame
    // of animation

    [SerializeField] private Animator SideDoorOpen;
    
    [SerializeField] private string SideDoorO = "One Way Door OPEN";

    // pretty simple when the player enters the trigger the animation will play
    // I also disabled the collider because I don't want the aniamtion activating again

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag ("Player"))
        {
            SideDoorOpen.Play(SideDoorO, 0, 0.0f);
            GetComponent<BoxCollider2D>().enabled = false;

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
