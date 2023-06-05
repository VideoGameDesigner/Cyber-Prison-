using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorSFX : MonoBehaviour
{
    AudioSource myaudiosource;

    // Start is called before the first frame update
    void Start()
    {
        myaudiosource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Laser"))

        {
            myaudiosource.Play();

        }


    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
