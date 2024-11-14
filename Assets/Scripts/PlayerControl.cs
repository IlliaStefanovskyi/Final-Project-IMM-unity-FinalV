using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float sidewaysSpeed = 10;
    public float turnSpeed;

    public float maxWheelTurningAngle = 30f;
    private float maxCarTurningAngle = 15f;
    public GameObject frontWheelR;
    public GameObject frontWheelL;
    private Vector3 defaultWheelAngle;
    private Vector3 defaultCarAngle;
    private Vector3 defaultCarPosition;

    public float lrInput;
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //receives initial angles for wheels and car and car position
        defaultWheelAngle = frontWheelL.transform.localEulerAngles;
        defaultCarAngle = transform.localEulerAngles;
        defaultCarPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        lrInput = Input.GetAxis("Horizontal");

        // Keeps the car in place on the x-axis
        transform.position = new Vector3(defaultCarPosition.x, transform.position.y, transform.position.z);

        // Moves the car left and right within an allowed range
        if (transform.position.z > -101 && transform.position.z < -79)
        {
            transform.Translate(Vector3.left * Time.deltaTime * sidewaysSpeed * lrInput);
        }
        else
        {
            transform.localEulerAngles = defaultCarAngle;
        }

        // Rotates car when input is received, but resets to face forward if no input
        if (transform.localEulerAngles.y > defaultCarAngle.y - maxCarTurningAngle
            && transform.localEulerAngles.y < defaultCarAngle.y + maxCarTurningAngle)
        {
            transform.Rotate(Vector3.up, turnSpeed * lrInput * Time.deltaTime);
        }
        if (lrInput == 0)
        {
            transform.localEulerAngles = defaultCarAngle;
        }

        // Front wheels turning based on input
        if (lrInput < 0) // Turns left
        {
            frontWheelL.transform.localEulerAngles =
                new Vector3(defaultWheelAngle.x, defaultWheelAngle.y - maxWheelTurningAngle, defaultWheelAngle.z);
            frontWheelR.transform.localEulerAngles =
                new Vector3(defaultWheelAngle.x, defaultWheelAngle.y - maxWheelTurningAngle, defaultWheelAngle.z);
        }
        else if (lrInput > 0) // Turns right
        {
            frontWheelL.transform.localEulerAngles =
                new Vector3(defaultWheelAngle.x, defaultWheelAngle.y + maxWheelTurningAngle, defaultWheelAngle.z);
            frontWheelR.transform.localEulerAngles =
                new Vector3(defaultWheelAngle.x, defaultWheelAngle.y + maxWheelTurningAngle, defaultWheelAngle.z);
        }
        else
        { // Brings wheels back to default angle when no input
            frontWheelL.transform.localEulerAngles = defaultWheelAngle;
            frontWheelR.transform.localEulerAngles = defaultWheelAngle;
        }
    }

    // OnCollisionEnter must be outside of the Update method
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!!");
            gameOver = true;
        }
    }
}
