using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float fSpeed = 10;
    public float bSpeed = 3;
    public float turnSpeed;

    public GameObject frontWheelR;
    public GameObject frontWheelL;

    public float fwbkInput;
    public float lrInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fwbkInput = Input.GetAxis("Vertical");
        lrInput = Input.GetAxis("Horizontal");
        //forward with forward speed
        if (fwbkInput > 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * fSpeed * fwbkInput * -1);
        }
        //moves backward with backward speed
        else if (fwbkInput < 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * bSpeed * fwbkInput * -1);
        }
        //turns only when in moove
        if (fwbkInput != 0)
        {
            transform.Rotate(Vector3.up, turnSpeed * lrInput * Time.deltaTime);
            if (lrInput > 0)
            {
                frontWheelL.transform.Rotate(Vector3.up * 4);
                frontWheelR.transform.Rotate(Vector3.up * 4);
            }
            else if(lrInput < 0 && frontWheelL.transform.rotation.y < 90)
            {
                frontWheelL.transform.Rotate(Vector3.up * -4);
                frontWheelR.transform.Rotate(Vector3.up * -4);
            }
        }
    }
}
