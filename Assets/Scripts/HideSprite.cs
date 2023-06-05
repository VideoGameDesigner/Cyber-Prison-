using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSprite : MonoBehaviour
{
    public SpriteRenderer Trigger, LaserHolder;

    public static bool SpriteHidden;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag ("Player"))

        {
            SpriteHidden = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SpriteHidden == false)
        {
            Trigger.GetComponent<SpriteRenderer>().enabled = false;
            LaserHolder.GetComponent<SpriteRenderer>().enabled = false;
        }

        if(SpriteHidden == true)

        {
            Trigger.GetComponent<SpriteRenderer>().enabled = true;
            LaserHolder.GetComponent<SpriteRenderer>().enabled = true;
        }
      
    }
}
