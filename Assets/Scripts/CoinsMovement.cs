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
        //Keeps coin in place on z and y axis
        transform.position = new Vector3(transform.position.x, startPos.y, startPos.z);

        //spins coin in y axis
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
    }
}

