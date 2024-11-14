using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spwanPos = new Vector3(117,3,-89); 

    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpwanObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpwanObstacle()
    {
        Instantiate(obstaclePrefab,spwanPos,obstaclePrefab.transform.rotation);
    }

}
