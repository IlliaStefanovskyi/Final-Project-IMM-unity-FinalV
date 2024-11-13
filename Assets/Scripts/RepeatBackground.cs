using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private static Vector3 startPos;
    private float repeatLength;
    public float speed = 5.0f;
    private bool isTwo = false;

    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector3(47, 0, -177); 
        repeatLength = GetComponent<BoxCollider>().size.x; 
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.forward * -1 * speed * Time.deltaTime);

        
        if (transform.position.x > startPos.x + (repeatLength * 0.5f) && isTwo == false)
        {
            Instantiate(this,new Vector3(startPos.x * 1.5f, startPos.y, startPos.z), this.transform.rotation);
            isTwo = true;
        }
        else if (transform.position.x > startPos.x + (repeatLength))
        {
            isTwo = false;
            GameObject.Destroy(this.gameObject);
        }
    }
}
