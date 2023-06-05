using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    public float BackgroundSpeed;
    public GameObject Camera;
    private Vector3 StartPosition;


    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(StartPosition.x + (BackgroundSpeed * Camera.transform.position.x),BackgroundSpeed * Camera.transform.position.y, StartPosition.z);
    }

}
