using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnableObject
{
    public GameObject prefab; // The object to spawn
    public float startDelay = 2.0f; // Delay before the first spawn
    public float repeatRate = 2.0f; // Spawn interval
}

public class SpawnManager : MonoBehaviour
{
    public List<SpawnableObject> spawnableObjects = new List<SpawnableObject>();
    private Vector3 spawnPos = new Vector3(0, 4, -89);
    private PlayerControl playerControlScript;

    void Start()
    {
        playerControlScript = GameObject.Find("F1").GetComponent<PlayerControl>();

        foreach (var spawnable in spawnableObjects)
        {
            StartCoroutine(SpawnRoutine(spawnable));
        }
    }

    IEnumerator SpawnRoutine(SpawnableObject spawnable)
    {
        yield return new WaitForSeconds(spawnable.startDelay);

        while (!playerControlScript.gameOver)
        {
            float randomSpawnZ = Random.Range(-98, -81); // Adjust Z spawn position
            float randomOffset = Random.Range(-0.5f, 0.5f); // Small time offset
            Instantiate(spawnable.prefab, new Vector3(spawnPos.x, spawnPos.y, randomSpawnZ), spawnable.prefab.transform.rotation);
            yield return new WaitForSeconds(spawnable.repeatRate + randomOffset);
        }
    }

}
