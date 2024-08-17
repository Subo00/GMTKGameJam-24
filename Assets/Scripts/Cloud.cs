using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static SourceBase;

public class Cloud : MonoBehaviour
{
    [SerializeField] 
    private GameObject WaterGO;

    [SerializeField]
    protected List<ResourceDrop> resourceDrops;
    private float timeSinceLastSpawn;
    public float spawnInterval;
    private Transform dropPoint;


    private void Start()
    {
        Transform[] temp = gameObject.GetComponentsInChildren<Transform>();
        dropPoint = temp[1];
    }

    private void FixedUpdate()
    {
        // Increment the timer by the time passed since the last FixedUpdate
        timeSinceLastSpawn += Time.fixedDeltaTime;

        // Check if the time since the last spawn has reached or exceeded the spawn interval
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObject();
            timeSinceLastSpawn = 0f; // Reset the timer after spawning
        }
    }

    private void SpawnObject()
    {
        float randNum = Random.Range(0.01f, 1f);

        foreach (var resource in resourceDrops)
        {
            Debug.Log("plls");

            if (resource.dropChance < randNum) continue;

            for (uint i = 0; i < resource.value; i++)
            {
                GameObject drop = Instantiate(WaterGO, dropPoint.position, Quaternion.identity);
                Vector3 rotation = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
                drop.GetComponent<ItemPickUp>().LaunchInDirection(rotation);
                Thread.Sleep(10);
            }
        }

    }
}

