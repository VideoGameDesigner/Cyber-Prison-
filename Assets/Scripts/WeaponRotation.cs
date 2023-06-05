using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponRotation : MonoBehaviour
{
    //private float WeaponAngle;// Used as avaraibel for the roation controls input
    //public float keyboardrotspeed;
    public float RotationSpeed; // How fast the weapon will rotate
   // public float roMin, roMax; // used to help clamp the rotation froma specfic angle

    Vector3 rotateUD; // this is soley for the new input system

    PlayerInputActions newrotation;// this is to reference the script I generated
    //when I created the input actions

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    private void Awake()
    {
        newrotation = new PlayerInputActions();
        //Note: += cntxt => above is acting as a pipe... taking the context
        //      value  and inserting it into moveLR variable (lambda value)
        newrotation.Player.WeaponRotation.performed += cntxt => rotateUD = cntxt.ReadValue<Vector2>();
        newrotation.Player.WeaponRotation.canceled += cntxt => rotateUD = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this is to make sure that the controls will start and stop
    // so that way the weapon will stop and start again on command

    private void OnEnable()
    {
        newrotation.Player.WeaponRotation.Enable();
    }

    private void OnDisable()
    {
        newrotation.Player.WeaponRotation.Disable();
    }


    private void FixedUpdate()
    {
        //WeaponAngle += Input.GetAxis("Vertical") * keyboardrotspeed; // constaly adding 1 with weapon angle to help move the roation based on the Y axis
        // with vertical which is assigned to up and down arrow key, W and S keys

        //WeaponAngle = Mathf.Clamp(WeaponAngle, roMin, roMax); // Using mathfunction clamp to amke sure the rotation isn't 360 degrees
        //transform.localEulerAngles = new Vector3(0, 0, WeaponAngle); // using a local transform rotation so that it only rotates the game object
        //then apply the WeaponAngle input to the z axis

        Vector3 myRotateUD = new Vector3(0f, 0f, rotateUD.y * RotationSpeed * Time.fixedDeltaTime);
        // x and y values zero'd as only want to rotate
        // so this looks complicated but has to be so that I can reference the rotation for the 
        // weapon itself from this script so that i don't need to use another
        // player input component
        if (myRotateUD.z > 0f)
        {
            // so if the rotation is more then zero let the weapon move up until 90
            float rotAmount = Time.fixedDeltaTime * RotationSpeed;
            float clampedRotation = Mathf.Clamp(transform.localEulerAngles.z + rotAmount, 0.0f, 90.0f);
            transform.localEulerAngles = new Vector3(0f, 0f, clampedRotation);
        }
        else if (myRotateUD.z < 0f)
        {
            // if the rotation is less then zero let the weapon go down as well but still not past 90 or zero
            float rotAmount = Time.fixedDeltaTime * -RotationSpeed;
            float clampedRotation = Mathf.Clamp(transform.localEulerAngles.z + rotAmount, 0.0f, 90.0f);
            transform.localEulerAngles = new Vector3(0f, 0f, clampedRotation);
        }


    }

   

    // note that this is only used for the old input system i may need to use a different type opf code later on for the new input system rotation
}
