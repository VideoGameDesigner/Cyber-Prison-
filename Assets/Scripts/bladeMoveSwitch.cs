using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bladeMoveSwitch : MonoBehaviour
{
    // variables to activate the blade controller animations
    [SerializeField] private Animator BladeControlIldeAnim, BladeControlMOVINGAnim;
    [SerializeField] private string Blade_slow = "BladeControllerSLOW";
    [SerializeField] private string Blade_Resume = "BladeControllerON";

    private void Start()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        // so thanks to the static public floats
        // as soon as the player shoots at the controller
        // the movement of the blades will be reduced
        if(collision.gameObject.CompareTag("Laser")&& SpinningBladeM.BladeMovementSpeed == 10 && SpinningBladeMovementMinus.MinusBladeMovementSpeed == -10)
        {
            BladeControlIldeAnim.Play(Blade_slow, 0, 0.0f);
            SpinningBladeM.BladeMovementSpeed = 1;
            SpinningBladeMovementMinus.MinusBladeMovementSpeed = -1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // then as soon as the laser exits the trigger then the 
        // Coroutine will start up
        if (collision.gameObject.CompareTag("Laser"))
        {
            StartCoroutine(BladeRestart());
        }
    }

    // this coroutine will put the speed of the blades back to normal after 15 seconds
    // 15 that seems like a long time but it's not when the player needs to
    // carefully go under the blade.
    IEnumerator BladeRestart()

    {
        
        {
            yield return new WaitForSeconds(15);
            BladeControlMOVINGAnim.Play(Blade_Resume, 0, 0.0f);
            SpinningBladeM.BladeMovementSpeed = 10;
            SpinningBladeMovementMinus.MinusBladeMovementSpeed = -10;
        }
    }
}
