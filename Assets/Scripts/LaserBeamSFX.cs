using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamSFX : MonoBehaviour
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
            myaudiosource.Pause();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser"))
        {
            StartCoroutine(resumeLaserSound());
        }
    }

    IEnumerator resumeLaserSound()

    {
        yield return new WaitForSeconds(4);
        myaudiosource.Play();
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
