using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoor : MonoBehaviour
{
    [SerializeField] private Animator animswitchC, animdoorC;
    [SerializeField] private string DoorC = "Prison Door Closing";
    [SerializeField] private string DoorSwitchC = "Door Switch Close Door";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animswitchC.Play(DoorSwitchC, 0, 0.0f);
            animdoorC.Play(DoorC, 0, 0.0f);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
