using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Laser"))
        {
            Destroy(gameObject);
        }
    }

    // I will use this script to just destroy game objects that are touched by the hackbullet projectile that I named laser
}
