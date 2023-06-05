using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger_Switch_DoorOpen : MonoBehaviour
{
    AudioSource myaudiosource;
    public AudioClip doorswitchsound,dooropensound;

    private void Awake()
    {
        myaudiosource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser")|| collision.gameObject.CompareTag("Player"))

        {
            myaudiosource.PlayOneShot(doorswitchsound);
            myaudiosource.PlayOneShot(dooropensound);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Laser") || collision.gameObject.CompareTag("Player"))

        {
            GetComponent<BoxCollider2D>().enabled = false;
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
