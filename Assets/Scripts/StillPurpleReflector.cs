using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillPurpleReflector : MonoBehaviour
{
    [SerializeField] private Animator PurpleReflectorAnim;
    [SerializeField] private string PurpleReflectorTrigger = "Purple Reflector Bounce";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            PurpleReflectorAnim.Play(PurpleReflectorTrigger, 0, 0.0f);

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
