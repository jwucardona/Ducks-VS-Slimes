using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    public string level;
    public List<Slime> slimes;
    public List<GameObject> slimesPrefabs;
    // list of enemies on the level currently

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (Slime slime in slimes)
        {
            if (slime.isSpawned == false && slime.spawnTime <= Time.time)
            {
                if (slime.RandomSpawn)
                {
                    slime.Spawner = Random.Range(0, transform.childCount);
                }
                Instantiate(slimesPrefabs[(int)slime.slimeType], new Vector3(transform.GetChild(slime.Spawner).transform.position.x, 1f, transform.GetChild(slime.Spawner).transform.position.z), transform.rotation * Quaternion.Euler(0f, 270f, 0f));
                slime.isSpawned = true;
            }
        }
    }
}
