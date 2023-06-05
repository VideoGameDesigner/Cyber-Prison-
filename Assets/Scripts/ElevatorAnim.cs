using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorAnim : MonoBehaviour
{
    // this whole script opens and closes the door of the elevator itself
    // To make sure that the animation frames don't loop
    // I changed them from default to clamp forever in wrap mode 


    [SerializeField] private Animator EDoorOpenAnim, EDoorCloseAnim;
    [SerializeField] private string EDoorO = "Elevator OPEN";
    [SerializeField] private string EDoorC = "Elevator Close";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EDoorOpenAnim.Play(EDoorO, 0, 0.0f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EDoorCloseAnim.Play(EDoorC, 0, 0.0f);
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
