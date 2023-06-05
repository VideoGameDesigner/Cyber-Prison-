using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMoveH : MonoBehaviour
{
    // this is to rrun the laser holder anaimtion to either green or red
    [SerializeField] private Animator LaserMovementAnim;
    [SerializeField] private string LaserFollow = "Laser beam holder H movement ON";
    [SerializeField] private Animator LaserMovementAnimOFF;
    [SerializeField] private string LaserFollowOFF = "Laser beam holder H movement";


    // this is to help reset the laser when hit
    private Vector3 respawn;

    // this is to just set the laser movement speed
    public float laserSpeed;

    // this si the same as laser game object i just called it something else to not get confused
    // later on
    public GameObject Laserhurtplayer;



    // Start is called before the first frame update
    // so as soo as the game starts make respanw the same as the last game objects default position
    void Start()
    {
        respawn = transform.position;
    }

    // Update is called once per frame
    // thanks to the public static I can use this variable here as well
    void Update()
    {
        // so if the trapOn is set to true then the laser will move
        // and the laser holder will be set to green
        if(LaserTrigger.TrapOn == true)

        {
            transform.position += Vector3.right * Time.deltaTime * laserSpeed;
            LaserMovementAnim.Play(LaserFollow, 0, 0.0f);
        }

        // However if it's set to false then the laser will reset back to the default position
        // and also turn off the laser game object
        if(LaserTrigger.TrapOn == false)
        {
            transform.position = respawn;
            Laserhurtplayer.SetActive(false);
        }

        // this one below is if the laser x axis is more then 14.42 then simply 
        // reset it's position along with the animation itself
        if(transform.position.x >= 142.42f)
        {
            LaserTrigger.TrapOn = false;
            LaserMovementAnimOFF.Play(LaserFollowOFF, 0, 0.0f);

        }


    }
  


}
