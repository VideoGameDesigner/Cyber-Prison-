using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayExit : MonoBehaviour
{
    // the door will close and stay closed because i disabled the collider for this one as well
    [SerializeField] private Animator SideDoorIdle;
    [SerializeField] private string SideDoorI = "One Way Door Idle";

    private void OnTriggerExit2D(Collider2D collision)
    {
        if( collision.CompareTag("Player"))

        {
            SideDoorIdle.Play(SideDoorI, 0, 0.0f);
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
