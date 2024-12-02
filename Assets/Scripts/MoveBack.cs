using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    private float speed = 20.0f;
    private float backBound = -2.0f;
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

        {
            transform.Translate(Vector3.left * -1 * Time.deltaTime * speed);
        }

        if (transform.position.y < backBound && gameObject.CompareTag("Obstacle") && gameObject.CompareTag("Money"))

        {
            Destroy(gameObject);
        }
    } 
}