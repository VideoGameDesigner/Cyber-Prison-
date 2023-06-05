using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBladeH_M : MonoBehaviour
{
    public float BlademovementHspeed;

    public float Hdistancecovered;

    private Vector2 startpoint;


    // Start is called before the first frame update
    void Start()
    {
        startpoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Hbladetrap = startpoint;
        Hbladetrap.x += Hdistancecovered * Mathf.Sin(Time.time * BlademovementHspeed);
        transform.position = Hbladetrap;
    }
}
