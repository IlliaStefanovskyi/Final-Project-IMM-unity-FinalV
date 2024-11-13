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

    // Start is called before the first frame update
    void Start()
    {
        //receives initil angles for wheels and car and car position
        defaultWheelAngle = frontWheelL.transform.localEulerAngles;
        defaultCarAngle = transform.localEulerAngles;
        defaultCarPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        lrInput = Input.GetAxis("Horizontal");

        //keeps the car in place
        transform.position = new Vector3(defaultCarPosition.x, transform.position.y, transform.position.z);

        //mooves the car left and right in the allowed range of values
        //turns it to face forward when hits the bound
        if (transform.position.z > -101 && transform.position.z < -79) {
            transform.Translate(Vector3.left * Time.deltaTime * sidewaysSpeed * lrInput);
        }
        else
        {
            transform.localEulerAngles = defaultCarAngle;
        }

        //rotates when input is received
        //makes it face forward if there is no input
        if (transform.localEulerAngles.y > defaultCarAngle.y - maxCarTurningAngle 
            && transform.localEulerAngles.y < defaultCarAngle.y + maxCarTurningAngle) {
            transform.Rotate(Vector3.up, turnSpeed * lrInput * Time.deltaTime);
        }
        if (lrInput == 0)
        {
            transform.localEulerAngles = defaultCarAngle;
        }

        //front wheels turning when input is received
        if (lrInput < 0) //turns left
        {
            frontWheelL.transform.localEulerAngles = 
                new Vector3(defaultWheelAngle.x, defaultWheelAngle.y - maxWheelTurningAngle, defaultWheelAngle.z);
            frontWheelR.transform.localEulerAngles = 
                new Vector3(defaultWheelAngle.x, defaultWheelAngle.y - maxWheelTurningAngle, defaultWheelAngle.z);
        }
        else if (lrInput > 0) //turns right
        {
            frontWheelL.transform.localEulerAngles = 
                new Vector3(defaultWheelAngle.x, defaultWheelAngle.y + maxWheelTurningAngle, defaultWheelAngle.z);
            frontWheelR.transform.localEulerAngles = 
                new Vector3(defaultWheelAngle.x, defaultWheelAngle.y + maxWheelTurningAngle, defaultWheelAngle.z);
        }
        else
        {//brings wheels back to default angle when no input
            frontWheelL.transform.localEulerAngles = defaultWheelAngle;
            frontWheelR.transform.localEulerAngles = defaultWheelAngle;
        }
    }
}
