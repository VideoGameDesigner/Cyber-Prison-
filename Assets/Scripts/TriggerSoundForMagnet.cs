using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSoundForMagnet : MonoBehaviour
{
    AudioSource myaudiosource;
    
    private void Awake()
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser") || collision.gameObject.CompareTag("Player"))

        {
            GetComponent<PolygonCollider2D>().enabled = false;
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
