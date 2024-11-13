using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 10;
    public float turboCoefficient = 1.8f;
    public float breakCoefficient = 0.5f;
    public float turnSpeed;

    public float maxSteeringAngle = 30f;
    public GameObject frontWheelR;
    public GameObject frontWheelL;
    private Vector3 defaultWheelAngle;

    public float fwbkInput;
    public float lrInput;
    // Start is called before the first frame update
    void Start()
    {
        //receives the initial angle of the wheel
        defaultWheelAngle = frontWheelL.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        /*fwbkInput = Input.GetAxis("Vertical");

        //continuouslly going forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * -1);
        //speed increases(turbo)
        if (fwbkInput > 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * fwbkInput * turboCoefficient * -1);
        }
        //slows down
        else if (fwbkInput < 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * fwbkInput * breakCoefficient * -1);
        }
        */
        lrInput = Input.GetAxis("Horizontal");

        if (transform.position.x > 137)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = 137;
            transform.position = newPosition;
        }

        transform.Translate(Vector3.left * Time.deltaTime * speed * lrInput);

        //turns when input is received
        transform.Rotate(Vector3.up, turnSpeed * lrInput * Time.deltaTime);
        //front wheels turning when horizontal input received
        if (lrInput < 0) //turns left
        {
            frontWheelL.transform.localEulerAngles = 
                new Vector3(defaultWheelAngle.x, defaultWheelAngle.y - maxSteeringAngle, defaultWheelAngle.z);
            frontWheelR.transform.localEulerAngles = 
                new Vector3(defaultWheelAngle.x, defaultWheelAngle.y - maxSteeringAngle, defaultWheelAngle.z);
        }
        else if (lrInput > 0) //turns right
        {
            frontWheelL.transform.localEulerAngles = 
                new Vector3(defaultWheelAngle.x, defaultWheelAngle.y + maxSteeringAngle, defaultWheelAngle.z);
            frontWheelR.transform.localEulerAngles = 
                new Vector3(defaultWheelAngle.x, defaultWheelAngle.y + maxSteeringAngle, defaultWheelAngle.z);
        }
        else
        {
            // Reset wheels to forward position gradually when no input
            frontWheelL.transform.localEulerAngles = defaultWheelAngle;
            frontWheelR.transform.localEulerAngles = defaultWheelAngle;
        }
    }
}
