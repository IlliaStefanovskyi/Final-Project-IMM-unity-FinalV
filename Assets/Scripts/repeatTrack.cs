using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatTrack : MonoBehaviour
{
    private static Vector3 startPos;
    private float repeatLength;
    public float speed = 5.0f;
    private bool isTwo = false;
    private PlayerControl playerContrllerScript;


    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(-29.7f, 3.3f, -90);
        repeatLength = GetComponent<BoxCollider>().size.x;
        playerContrllerScript = GameObject.Find("F1").GetComponent<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerContrllerScript.gameOver)
        {
            speed = 0;
        }

        transform.Translate(Vector3.forward * -1 * speed * Time.deltaTime);


        if (transform.position.x > startPos.x + (repeatLength * 2) && isTwo == false)
        {
            Instantiate(this, new Vector3(startPos.x * 12f, startPos.y, startPos.z), this.transform.rotation);
            isTwo = true;
        }
        else if (transform.position.x > startPos.x + (repeatLength * 24f))
        {
            isTwo = false;
            GameObject.Destroy(this.gameObject);
        }
    }
}

