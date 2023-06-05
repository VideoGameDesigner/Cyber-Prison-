using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBladeM : MonoBehaviour
{

    // The public static is used so that the bladeswitch script
    // can chnage the blademovements speed
    public static float BladeMovementSpeed;
    // This float can help me control the distance between 2 points
    public float DistanceCovered;
    // this si to set up the vectors starting point for the game object
    private Vector2 Startposition;

    // The last varaibles were there to see if the mvoement
    // would change if I sued time.deltatime isnteals Time.time
    
    
    // Start is called before the first frame update
    void Start()
    {   // as oon as the game starts the variable will set to the
        // // transform.position
        BladeMovementSpeed = 10;
        Startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
     // Basically turing the Time.deltatime into a variable           
        
    
     // so by creating another vector2 and setting it to the starting point we
     // are saying move back and for at this position
     // Then the mathf.sin will go bakc and forth on the y axis at the blademovementspeed
     // lastly to make it go back and forth from the top and the bottom we
     // reset the transform.postion to the bladetrap.
        Vector2 BladeTrap = Startposition;
        BladeTrap.y += DistanceCovered * Mathf.Sin(Time.time * BladeMovementSpeed);
        transform.position = BladeTrap;
    }

   
}
