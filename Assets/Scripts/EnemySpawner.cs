using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class EnemySpawner : MonoBehaviour
{
    public int level;
    public List<Slime> slimes;
    public List<GameObject> slimesPrefabs;
    public string location; // location of the text file that holds the slimes
    // list of enemies on the level currently

    // Start is called before the first frame update

    void LoadLevel(int level)
    {
        location = "Assets/Scripts/Level" + level + ".txt";
        foreach (string line in File.ReadLines(location))
        {
            string[] words = line.Split(' ');
            // print(words[0] + " " + words[1] + " " + words[2] + " " + words[3] + " " + words[4]);
            Slime tempSlime = new Slime(int.Parse(words[0]), int.Parse(words[1]), int.Parse(words[2]), bool.Parse(words[3]), bool.Parse(words[4]));
            slimes.Add(tempSlime);
        }
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    void Start()
    {
        slimes = new List<Slime>();
        level = 1;
        // read in from a textfile that holds the slimes based on the level
        // slimes = new List<Slime>();
        // levels
        LoadLevel(level);

    }

    // Update is called once per frame
    void Update()
    {
        if (slimes != null)
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


}
