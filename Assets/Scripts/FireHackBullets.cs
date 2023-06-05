using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireHackBullets : MonoBehaviour
{
    [SerializeField] Transform Hackfirepoint;// The start position for the hack bullet
    [SerializeField] GameObject HackAmmoprefab; // the gameobject whre we will access the prefab
    private float firerate = 0.5f; // a variable for how often you can shoot
    private float nextfire = 0f; // a variable that resets the shoot time
    AudioSource myaudiosource;


    private void Awake()
    {
        myaudiosource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V) && Time.time > nextfire) // when the player presses the v key the timer will start for netx fire
            // However since it's set to be more than zero it will actvate the if statement below
        {

            nextfire = Time.time + firerate; // so if the bullet has been fired for 0.5 seconds then the player cna't shoot until the timer is reset to 0
            shoot(); // this activate the prefab which has been cloned thanks to Instantiate

        }       

    }

    private void shoot()

    {
        // so if the game is unpaused then I can fire my weapon as normal
        if (PauseManager.paused == false)

        {
            myaudiosource.Play();
            // a private method that tells the script to spawn the prefab but leave the psotion and ropation to default 
            Instantiate(HackAmmoprefab, Hackfirepoint.position, Hackfirepoint.rotation); 

        }
        // if the game is paused then you can't fire my weapon so in other words I'm returning nothing
        else if(PauseManager.paused == true)
        {
            return;
        }

              

    }
    // this is to reference the shoot weapon projectile button fro thr new input system
    public void Fire(InputAction.CallbackContext context)
    {
        if(Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            shoot();
        }
    }

}
