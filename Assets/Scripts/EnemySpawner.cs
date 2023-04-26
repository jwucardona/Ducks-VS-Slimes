using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public string level;
    // list of enemies on the level currently
    List<GameObject> enemies = new List<GameObject>();

    [SerializeField] private GameObject tempDestination;

    // enemy unit prefabs
    [SerializeField] private BasicSlime basicSlimePrefab;
    [SerializeField] private BunnySlime bunnySlimePrefab;
    [SerializeField] private KnightSlime knightSlimePrefab;
    [SerializeField] private KingSlime kingSlimePrefab;

    // list of spawn points
    [SerializeField] List<GameObject> spawnPoints = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        // get random spawn point
        // GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        GameObject spawnPoint = spawnPoints[0];
        KingSlime newObject = Instantiate(kingSlimePrefab, new Vector3(spawnPoint.transform.position.x, 1f, spawnPoint.transform.position.z), transform.rotation * Quaternion.Euler(0f, 270f, 0f));
        newObject.setSpawn(new Vector3(spawnPoint.transform.position.x, 1f, spawnPoint.transform.position.z));
        enemies.Add(newObject.gameObject);
        newObject.setDestination(tempDestination.transform.position);
        newObject.Walk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
