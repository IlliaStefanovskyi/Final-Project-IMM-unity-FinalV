using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatLength;
    public float speed = 5.0f; // Speed at which the road moves towards the car

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // Save the initial position of the background
        repeatLength = GetComponent<BoxCollider>().size.x; // Full height of the background
    }

    // Update is called once per frame
    void Update()
    {
        // Move the background downwards to simulate forward motion of the car
        transform.Translate(Vector3.forward * -1 * speed * Time.deltaTime);

        // Check if the background has moved past the repeat length and reset if necessary
        if (transform.position.x < startPos.x - repeatLength)
        {
            transform.position = startPos; // Reset to start position for a seamless loop
        }
    }
}
