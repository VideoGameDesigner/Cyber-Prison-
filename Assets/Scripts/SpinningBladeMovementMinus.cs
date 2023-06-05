using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBladeMovementMinus : MonoBehaviour
{
    public static float MinusBladeMovementSpeed;
    public float DistanceCovered;
    private Vector2 Startposition;


    // Start is called before the first frame update
    void Start()
    {
        MinusBladeMovementSpeed = -10;
        Startposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 BladeTrap = Startposition;
        BladeTrap.y += DistanceCovered * Mathf.Sin(Time.time * MinusBladeMovementSpeed);
        transform.position = BladeTrap;
    }
}
