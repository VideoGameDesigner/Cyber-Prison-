using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose_CheckPointSFX : MonoBehaviour
{
    AudioSource myaudiosource;

    // Start is called before the first frame update
    void Start()
    {
        myaudiosource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))

        {
            myaudiosource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))

        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
