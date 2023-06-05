using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldRec : MonoBehaviour
{
    public SpriteRenderer Rectangle;
    public BoxCollider2D ForceFieldforREC;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Laser"))
        {
            Rectangle.GetComponent<SpriteRenderer>().enabled = false;
            ForceFieldforREC.GetComponent<BoxCollider2D>().enabled = false;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(forcefieldRECON());
    }



    IEnumerator forcefieldRECON()

    {
        yield return new WaitForSeconds(4);
        ForceFieldforREC.GetComponent<BoxCollider2D>().enabled = true;
        Rectangle.gameObject.GetComponent<SpriteRenderer>().enabled = true;
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
