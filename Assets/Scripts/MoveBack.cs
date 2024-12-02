using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public float speed = 50;
    private float backBoundy = -2.0f;
    private float backboundx = 150;
    private PlayerControl playerContrllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerContrllerScript = GameObject.Find("F1").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerContrllerScript.gameOver)
        {
            speed = 0;
        }

        else{
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }

        if (transform.position.y < backBoundy || transform.position.x > backboundx)
        {
            Destroy(gameObject);
        }
    } 
}