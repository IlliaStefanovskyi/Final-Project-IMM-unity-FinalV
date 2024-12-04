using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class CoinsMovement : MonoBehaviour
{
    public float spinSpeed;
    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        //spins coin in y axis
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);

        //Keeps coin in place on z and y axis
        if (transform.position.y < startPos.y - 1 || transform.position.y > startPos.y + 1) {
            transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
        }
    }
}

