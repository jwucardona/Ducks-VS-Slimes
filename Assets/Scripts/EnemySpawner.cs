using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public string level;
    public List<Slime> slimes;
    public List<GameObject> slimesPrefabs;
    // list of enemies on the level currently
    // List<GameObject> enemies = new List<GameObject>();

    //[SerializeField] private GameObject tempDestination;
    // [SerializeField] private List<GameObject> path;
    // [SerializeField] private GameObject destination;

    // enemy unit prefabs
    // [SerializeField] private BasicSlime basicSlimePrefab;
    // [SerializeField] private BunnySlime bunnySlimePrefab;
    // [SerializeField] private KnightSlime knightSlimePrefab;
    // [SerializeField] private KingSlime kingSlimePrefab;

    // list of spawn points
    // [SerializeField] GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        // KingSlime newObject = Instantiate(kingSlimePrefab, new Vector3(spawnPoint.transform.position.x, 1f, spawnPoint.transform.position.z), transform.rotation * Quaternion.Euler(0f, 270f, 0f));
        // newObject.setSpawn(new Vector3(spawnPoint.transform.position.x, 1f, spawnPoint.transform.position.z));
        // enemies.Add(newObject.gameObject);
        // newObject.setDestination(destination.transform.position);
        //newObject.Attack();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Slime slime in slimes)
        {
            if (slime.isSpawned == false && slime.spawnTime < Time.time)
            {
                Instantiate(slimesPrefabs[(int)slime.slimeType], new Vector3(transform.GetChild(slime.Spawner).transform.position.x, 1f, transform.GetChild(slime.Spawner).transform.position.z), transform.rotation * Quaternion.Euler(0f, 270f, 0f));
                slime.isSpawned = true;
            }
        }
    }
}
