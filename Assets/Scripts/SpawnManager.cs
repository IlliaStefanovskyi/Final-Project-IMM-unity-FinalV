using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject coinPrefab;
    private Vector3 spawnPos = new Vector3(0, 4, -89);
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    private PlayerControl playerControlScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControlScript = GameObject.Find("F1").GetComponent<PlayerControl>();
        InvokeRepeating("SpwanObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void SpwanObstacle()
    {
        float randomSpawnZ = Random.Range(-98, -81);
        float randomObjectSpawn = Random.Range(0,100);
        if (playerControlScript.gameOver == false)
        {
            if (randomObjectSpawn <= 50)
            {
                Instantiate(coinPrefab, new Vector3(spawnPos.x, spawnPos.y, randomSpawnZ), coinPrefab.transform.rotation);
            }
            else {
                Instantiate(obstaclePrefab, new Vector3(spawnPos.x, spawnPos.y, randomSpawnZ), obstaclePrefab.transform.rotation);
            }
        }

    }

}
