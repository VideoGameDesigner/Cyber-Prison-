using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateReflector : MonoBehaviour
{
    // this is to reference the green reflector
    // and the public int is to set a specfic number to each animation
    // the 4 strings are fro each side of the flashing green reflectors

    public GameObject reflector;

    public int reflectCounter;

    [SerializeField] Animator ReflectorR_A_0, ReflectorR_A_Minus90, ReflectorR_A_180, ReflectorR_A_90;
    [SerializeField] private string ReflectorTopleft = "ReflectorRotateZERO";
    [SerializeField] private string ReflectorTopright = "ReflectorRotate-90";
    [SerializeField] private string ReflectorBottomright = "ReflectorRotate180";
    [SerializeField] private string ReflectorBottomleft = "ReflectorRotate90";


    // now for the cool part every time the player hits the
    // reflect rotater the reflector coutn goes up by 1
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Laser"))
        {
            reflector.transform.Rotate(0, 0, -90);

            reflectCounter++;

        }
        // so if the counter is set to 1 then play this animation
        // the same goes for 2,3 and 4 which all have a specific
        // animation assigned to it
        if (reflectCounter == 1)

        {
            ReflectorR_A_Minus90.Play(ReflectorTopright, 0, 0.0f);
        }

        if(reflectCounter == 2)

        {
            ReflectorR_A_180.Play(ReflectorBottomright, 0, 0.0f);
        }

        if(reflectCounter == 3)
        {
            ReflectorR_A_90.Play(ReflectorBottomleft, 0, 0.0f);

        }
        // lastly as soon as the reflectcounter reaches 4
        // it resets back to zero starting the whole
        // loop or over again along with each animation
        if(reflectCounter == 4)

        {
            ReflectorR_A_0.Play(ReflectorTopleft, 0, 0.0f);

            reflectCounter = 0;
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
