using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrollingBackground : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject[] mapPrefabs;
    public float mapSpawnZ = 0f;
    public float mapLength = 100f;
    public int numberOfMaps = 5;
    public float safeZone = 30f;
    private float lastPlayerPositionZ = 0;
    private GameObject[] activeMaps;
    private int indexOfLastMap;

    void Start()
    {
        activeMaps = new GameObject[numberOfMaps];
        SpawnMaps(0);
    }

    void Update()
    {
        if (playerTransform.position.z - safeZone > (mapSpawnZ - numberOfMaps * mapLength))
        {
            SpawnMaps(indexOfLastMap);
            DeleteMap();
        }
    }

    void SpawnMaps(int indexOfFirstMap)
    {
        for (int i = 0; i < numberOfMaps; i++)
        {
            GameObject map = Instantiate(mapPrefabs[Random.Range(0, mapPrefabs.Length)], Vector3.forward * mapSpawnZ, Quaternion.identity);
            activeMaps[indexOfFirstMap + i] = map;
            mapSpawnZ += mapLength;
            indexOfLastMap = (indexOfFirstMap + i) % numberOfMaps;
        }
    }

    void DeleteMap()
    {
        Destroy(activeMaps[indexOfLastMap]);
    }
}

