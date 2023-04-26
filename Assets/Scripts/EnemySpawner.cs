using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public string level;
    // list of enemies on the level currently
    List<GameObject> enemies = new List<GameObject>();

    // enemy unit prefabs
    public GameObject basicSlimePrefab;
    public GameObject bunnySlimePrefab;
    public GameObject knightSlimePrefab;
    public GameObject kingSlimePrefab;

    // list of spawn points
    [SerializeField] List<GameObject> spawnPoints = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        // get random spawn point
        GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        GameObject newObject = Instantiate(kingSlimePrefab, new Vector3(spawnPoint.transform.position.x, 1.5f, spawnPoint.transform.position.z), transform.rotation * Quaternion.Euler(0f, 270f, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
