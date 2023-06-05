using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalBoxSFX : MonoBehaviour
{

    AudioSource myaudiosource;

    // Start is called before the first frame update
    void Start()
    {
        myaudiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Metal Box"))
        {
            myaudiosource.Play();

        }
    }


}
