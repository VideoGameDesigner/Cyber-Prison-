using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] Animator animcheckpoint;
    [SerializeField] private string checkpoint = "CheckPointON";


    PlayerMovement playerposition;// grabbing the script for the playermovement so we can access it
    public Transform Respawner; // finding the transform of the checkpoint

    private void Awake()

        // Awake is like start except that is before the start method so this will activate before void start
        // so that way I can find the player,there tag and attach it to a component
    {
        playerposition = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)

    // this helps update the check point system so that way the player wil always respanw on the last check point
    // they corssed
    {
        if (collision.gameObject.CompareTag("Player"))

        {
            playerposition.updatecheckpoint(Respawner.position);
            animcheckpoint.Play(checkpoint, 0, 0.0f);
        }
    }
}
