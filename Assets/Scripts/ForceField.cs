using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    public SpriteRenderer circle; // let's me access the sprite renderder for the forcefield game object
    public CircleCollider2D forcefield; // let's me access the circlecollider2d for the forcefield game object

    private void OnCollisionEnter2D(Collision2D collision)
        // as soon as the laser hits the blue angled square then that truns off the force field surrounding the cam
    {
        if(collision.gameObject.CompareTag("Laser"))
        {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            forcefield.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
        // as soon as the projectile exits blue square then this coroutine will activate
    {
        StartCoroutine(forcefieldON());
    }

    IEnumerator forcefieldON()
        // this will reacivate the forcefield after 3 seconds 
    {      
        yield return new WaitForSeconds(3);
        circle.GetComponent<SpriteRenderer>().enabled = true;
        forcefield.GetComponent<CircleCollider2D>().enabled = true;     
    }
}
