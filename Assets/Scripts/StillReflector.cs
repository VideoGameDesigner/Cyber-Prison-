using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillReflector : MonoBehaviour
{
    // In this case the previous code I used to make my projectile bounce
    //works just fine this script just activates the animation by trigger

    [SerializeField] private Animator GreenReflectorAnim;
    [SerializeField] private string GreenReflectorTrigger = "Green Reflector Bounce";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            GreenReflectorAnim.Play(GreenReflectorTrigger,0,0.0f);

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
