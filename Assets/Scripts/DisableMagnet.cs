using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMagnet : MonoBehaviour
{

    // this is to turn off the magnet animation
    [SerializeField] private Animator animmagnet;
    [SerializeField] private string Magentoff = "Magnet OFF";

    
    // this is to access the metal boxes rigidbody2d from this script
    public GameObject MetalBox;



    // Start is called before the first frame update
    void Start()
    {
        // as soon as the game starts set the metalbox rigidbody to static so that it won't move at all
        MetalBox.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Then just like I did with the door I will activate a different animation but also
    // set the rigidbody2d to dynamic so that way the box is affected by gravity

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Laser"))
        {
            animmagnet.Play(Magentoff, 0, 0.0f);
            MetalBox.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
            

    }


}
