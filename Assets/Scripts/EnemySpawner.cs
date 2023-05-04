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
    public bool slimesAreDead = false; // if all the slimes are dead, then the level is over
    //private bool spawningDone = false;
    //public List<GameObject> enemies;
    private int enemyCount = 0;

    private static EnemySpawner theEnemySpawner;

    public static EnemySpawner getInstance()
    {
        return theEnemySpawner;
    }

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
        theEnemySpawner = this;
        slimes = new List<Slime>();
        //enemies = new List<GameObject>();
        level = 1;
        // read in from a textfile that holds the slimes based on the level
        // slimes = new List<Slime>();
        // levels
        LoadLevel(level);
        enemyCount = slimes.Count;

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount <= 0 /* && PROGRESS BAR COMPLETE */)
        {
            slimesAreDead = true;
        }
        else
        {
            slimesAreDead = false;
        }


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
                    GameObject tempSlime = slimesPrefabs[(int)slime.slimeType];
                    Instantiate(tempSlime, new Vector3(transform.GetChild(slime.Spawner).transform.position.x, 1f, transform.GetChild(slime.Spawner).transform.position.z), transform.rotation * Quaternion.Euler(0f, 270f, 0f));
                    //enemies.Add(tempSlime);
                    //enemyCount++;
                    slime.isSpawned = true;
                }
            }
        }
    }

    public void deadSlime()
    {
        enemyCount--;
        if (enemyCount <= 0)
        {
            slimesAreDead = true;
        }
        print(enemyCount + " slimes left");
    }

    public bool getSlimesAreDead()
    {
        return slimesAreDead;
    }
}
