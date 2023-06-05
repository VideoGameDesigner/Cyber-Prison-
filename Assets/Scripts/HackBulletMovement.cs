using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackBulletMovement : MonoBehaviour
{

    

    [SerializeField] float hackBulletSpeed = 20f;// How fast the bullet will move

    private Rigidbody2D rb;//setting up shortcut rigidbody2d

    Vector3 BulletBounce; // This is used to help me reflect my projectile later on


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();// allow me to access rigidbody2d by using the variable name isntead
        rb.velocity = transform.right * hackBulletSpeed;// as soon as this game object come into existance it will move forward
        StartCoroutine(SelfDestruct());// as soon as the bullet has been fired this Coroutine will activate
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
         
        BulletBounce = rb.velocity; // I need to track everysingle frame of the prjectile to refelct it properly that's why I set bulletBounce to velocity
    }

    IEnumerator SelfDestruct() // a simple coroutine that will destroy the bullet after 5 seconds
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
   
    // This code helps my projectile bounce off specfic objects I use Contactpoint2D because i want to get the collsions for my 2D game,
    // then decide how many concact points I want in this case as many as I want so i set it to 0.
    // I then create another vector 3 which will be used for the vectro3 reflect this s is what;s needed to redirect my projectile
    // I set contact to so that i't uses the normal vector and not a differnt one
    // since I'm using a rigidbody to move my projectile I need to assign to the reflectedvelocity back to the rigidbody itself
    // lastly the last bit of code rotates my projectile int he direction it's beeing relfected at


     private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Block"))

        {
            // get the point of contact
            ContactPoint2D contact = collision.contacts[0];

            // reflect our old velocity off the contact point's normal vector
            Vector3 reflectedVelocity = Vector3.Reflect(BulletBounce, contact.normal);

            // assign the reflected velocity back to the rigidbody
            rb.velocity = reflectedVelocity;

            // rotate the object by the same ammount we changed its velocity
            Quaternion rotation = Quaternion.FromToRotation(BulletBounce, reflectedVelocity);
            transform.rotation = rotation * transform.rotation;
        }
        

    }

   


}
